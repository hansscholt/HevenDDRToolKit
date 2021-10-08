using ssqltool;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ssqtool
{
	class SSQWriter
	{
		public SSQWriter(SMReader smreader)
		{
			List<byte> byteOut = new List<byte>();
			List<byte> Chunk1 = new List<byte>();
			List<byte> Chunk2 = new List<byte>();
			List<byte> Chunk3 = new List<byte>();

			/////////////////////chunk1
			{
				Chunk1.AddRange(SHORT2LE(0x01));
				Chunk1.AddRange(SHORT2LE(smreader.iTickRate));
				Chunk1.AddRange(SHORT2LE(smreader.timingChunk.Count));
				Chunk1.AddRange(SHORT2LE(0x00));

				List<byte> ChunkOffsets = new List<byte>();
				List<byte> ChunkTimes = new List<byte>();

				foreach (TimingChunk timing in smreader.timingChunk)
				{
					float fOffset = (timing.fOffset);
					ChunkOffsets.AddRange(INT2LE((int)fOffset));
					//Console.WriteLine((int)fOffset);
					int intTimes = (int)(timing.dTime * smreader.iTickRate);
					ChunkTimes.AddRange(INT2LE(intTimes));
				}

				PadChunk(ref ChunkOffsets, 4);
				PadChunk(ref ChunkTimes, 4);

				Chunk1.AddRange(ChunkOffsets);
				Chunk1.AddRange(ChunkTimes);
			}

			/////////////////////chunk2
			{
				Chunk2.AddRange(SHORT2LE(0x02));
				Chunk2.AddRange(SHORT2LE(1));
				Chunk2.AddRange(SHORT2LE(smreader.chunkData.Count));
				Chunk2.AddRange(SHORT2LE(0));

				List<byte> ChunkOffsets = new List<byte>();
				List<byte> ChunkDatas = new List<byte>();

				foreach (ExtraChunk extra in smreader.chunkData)
				{
					float fOffset = extra.fOffset * 4096;
					ChunkOffsets.AddRange(INT2LE((int)fOffset));
					ChunkDatas.AddRange(SHORT2LE(extra.iData));
				}

				PadChunk(ref ChunkOffsets, 4);
				PadChunk(ref ChunkDatas, 4);

				Chunk2.AddRange(ChunkOffsets);
				Chunk2.AddRange(ChunkDatas);
			}

			////////////////////chunk3
			{
				smreader.stepData = OrdenarData(smreader);  

				foreach (StepData sd in smreader.stepData)
				{
					if (sd == null)
						continue;

					List<byte> tempChunk3 = new List<byte>();

					int iDiff = 0x0414;
					switch (sd.sStepStyle)
					{
						case ssqltool.StepStyle.SingleBeginner:
							iDiff = 0x0414;		break;
						case ssqltool.StepStyle.SingleBasic:
							iDiff = 0x0114;		break;
						case ssqltool.StepStyle.SingleDifficult:
							iDiff = 0x0214;		break;
						case ssqltool.StepStyle.SingleExpert:
							iDiff = 0x0314;		break;
						case ssqltool.StepStyle.SingleChallenge:
							iDiff = 0x0614;		break;
						case ssqltool.StepStyle.DoubleBeginner:
							iDiff = 0x0418;		break;
						case ssqltool.StepStyle.DoubleBasic:
							iDiff = 0x0118;		break;
						case ssqltool.StepStyle.DoubleDifficult:
							iDiff = 0x0218;		break;
						case ssqltool.StepStyle.DoubleExpert:
							iDiff = 0x0318;		break;
						case ssqltool.StepStyle.DoubleChallenge:
							iDiff = 0x0618;		break;
					}

					tempChunk3.AddRange(SHORT2LE(0x03));
					tempChunk3.AddRange(SHORT2LE(iDiff));
					tempChunk3.AddRange(SHORT2LE(sd.NoteData.Count));
					tempChunk3.AddRange(SHORT2LE(0));


					List<byte> ChunkOffsets = new List<byte>();
					List<byte> ChunkDatas = new List<byte>();
					List<byte> ChunkExtras = new List<byte>();

					//ordenar freezes y flechas normales
					List<NoteData> noteNormal = new List<NoteData>();
					List<NoteData> noteFreeze = new List<NoteData>();

					foreach (NoteData ob in sd.NoteData)
					{
						if (ob.bFreezeEnd)
							noteFreeze.Add(ob);
						else
							noteNormal.Add(ob);
					}


					for (int f = 0; f < noteFreeze.Count; f++)
					{
						bool found = false;
						for (int n = 0; n < noteNormal.Count; n++)
						{
							found = false;
							float sum1 = (float)(noteNormal[n].iMeasure) + noteNormal[n].fBeatPadding;
							float sum2 = (float)(noteFreeze[f].iMeasure) + noteFreeze[f].fBeatPadding;
							if (sum1 > sum2)
							{

								//int iStart = n;
								while (n > 0)
								{
									//Console.WriteLine("N:" + n);
									n--;

									bool auxBool = false;

									List<NoteName> noteListNormal = noteNormal[n].sNotes;
									for (int no = 0; no < noteListNormal.Count; no++)
									{
										List<NoteName> noteListFreeze = noteFreeze[f].sNotes;
										for (int nf = 0; nf < noteListFreeze.Count; nf++)
										{
											if (noteListNormal[no] == noteListFreeze[nf])
											{
												auxBool = true;
												break;
											}
										}
									}
									if (auxBool)
									{
										noteNormal.Insert(n + 1, noteFreeze[f]);
										found = true;
										break;
									}
								}
							}
							if (found)
								break;
						}
						if (!found)
							noteNormal.Add(noteFreeze[f]);

					}
					//sd.NoteData = noteNormal;
					foreach (NoteData ob in noteNormal)
					{
						float fOffset = (((float)(ob.iMeasure) + ob.fBeatPadding) * 4096);
						ChunkOffsets.AddRange(INT2LE((int)fOffset));

						//Console.WriteLine((int)fOffset);
						byte note = 0;

						List<NoteName> noteList = ob.sNotes;
						int[] byteArray = getByteArray(noteList);
						for (int j = 0; j < byteArray.Length; j++)
						{
							note = (byte)((note << 1) & 0xff);
							if (byteArray[j] == 1)
								note++;
						}

						foreach (NoteName item in noteList)
						{
							//ctm
							if (item == NoteName.ShockArrow)
							{
								note = 255;
								break;
							}
						}


						if (ob.bFreezeEnd)
						{
							ChunkDatas.AddRange(SHORT2LE1BYTE(0));
							ChunkExtras.AddRange(SHORT2LE1BYTE(note));
							ChunkExtras.AddRange(SHORT2LE1BYTE(0x01));
						}
						else
						{
							ChunkDatas.AddRange(SHORT2LE1BYTE(note));
						}
					}
					tempChunk3.AddRange(ChunkOffsets);
					PadChunk(ref tempChunk3, 4);

					tempChunk3.AddRange(ChunkDatas);
					PadChunk(ref tempChunk3, 2);

					tempChunk3.AddRange(ChunkExtras);
					PadChunk(ref tempChunk3, 4);

					Chunk3.AddRange(INT2LE(tempChunk3.Count + 4));
					Chunk3.AddRange(tempChunk3);

				}
			}

			byteOut.AddRange(INT2LE(Chunk1.Count + 4));
			byteOut.AddRange(Chunk1);
			byteOut.AddRange(INT2LE(Chunk2.Count + 4));
			byteOut.AddRange(Chunk2);
			///////////////byteOut.AddRange(INT2LE(Chunk3.Count + 4));
			byteOut.AddRange(Chunk3);

			byteOut.AddRange(INT2LE(0));


			File.WriteAllBytes(Path.Combine("OUT", Path.ChangeExtension(smreader.sSSQFile, ".ssq")), byteOut.ToArray());
		}

		int[] getByteArray(List<NoteName> noteList)
		{
			int[] byteArray = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };

			foreach (NoteName sNote in noteList)
			{
                switch (sNote)
                {
                    case NoteName.P1_Left:	byteArray[7] = 1;	break;
                    case NoteName.P1_Down:	byteArray[6] = 1; break;
					case NoteName.P1_Up:	byteArray[5] = 1; break;
					case NoteName.P1_Right: byteArray[4] = 1; break;
					case NoteName.P2_Left:	byteArray[3] = 1; break;
					case NoteName.P2_Down:	byteArray[2] = 1; break;
					case NoteName.P2_Up:	byteArray[1] = 1; break;
					case NoteName.P2_Right: byteArray[0] = 1; break;
                    default:
                        break;
                }
			}


			return byteArray;
		}
		void PadChunk(ref List<byte> chunk, int padding)
		{
			int i = chunk.Count % padding;
			if (i != padding && i != 0)
				for (int c = 0; c < (padding - i); c++)
					chunk.Add(0x00);
		}

		byte[] INT2LE(int data)
		{
			byte[] b = new byte[4];
			b[0] = (byte)data;
			b[1] = (byte)(((uint)data >> 8) & 0xFF);
			b[2] = (byte)(((uint)data >> 16) & 0xFF);
			b[3] = (byte)(((uint)data >> 24) & 0xFF);
			return b;
		}
		byte[] SHORT2LE(short data)
		{
			byte[] b = new byte[2];
			b[0] = (byte)data;
			b[1] = (byte)(((uint)data >> 8) & 0xFF);
			return b;
		}
		byte[] SHORT2LE(int data)
		{
			byte[] b = new byte[2];
			b[0] = (byte)data;
			b[1] = (byte)(((uint)data >> 8) & 0xFF);
			return b;
		}

		byte[] SHORT2LE1BYTE(int data)
		{
			byte[] b = new byte[1];
			b[0] = (byte)data;
			return b;
		}
		List<StepData> OrdenarData(SMReader smreader)
		{
			StepData[] tempStepData = new StepData[10];
			foreach (StepData sd in smreader.stepData)
			{
				List<byte> tempChunk3 = new List<byte>();

				switch (sd.sStepStyle)
				{
					case ssqltool.StepStyle.SingleBeginner: tempStepData[6] = sd; break;
					case ssqltool.StepStyle.SingleBasic: tempStepData[0] = sd; break;
					case ssqltool.StepStyle.SingleDifficult: tempStepData[2] = sd; break;
					case ssqltool.StepStyle.SingleExpert: tempStepData[4] = sd; break;
					case ssqltool.StepStyle.SingleChallenge: tempStepData[8] = sd; break;
					case ssqltool.StepStyle.DoubleBeginner: tempStepData[7] = sd; break;
					case ssqltool.StepStyle.DoubleBasic: tempStepData[1] = sd; break;
					case ssqltool.StepStyle.DoubleDifficult: tempStepData[3] = sd; break;
					case ssqltool.StepStyle.DoubleExpert: tempStepData[5] = sd; break;
					case ssqltool.StepStyle.DoubleChallenge: tempStepData[9] = sd; break;
				}
			}
			return tempStepData.ToList();
		}
	}
}
