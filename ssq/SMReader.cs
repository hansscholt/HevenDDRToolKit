using ssqltool;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ssqtool
{
    class SMReader
    {
        public List<ExtraChunk> chunkData { get; set; }
        public List<object[]> chunkDatao { get; set; }
        public List<StepData> stepData { get; set; }
        public List<TimingChunk> timingChunk { get; set; }
        public int iTickRate { get; set; }
        public string sSSQFile { get; set; }
        public float fSampleStart { get; set; }
        public float fSampleLenght { get; set; }
        public string sSampleFile { get; set; }
        public string sBackGroundFile { get; set; }

        public SMReader(string filename, string sShortFilename, int tick_rate = 150)
        {
            sSSQFile = sShortFilename;
            parse(filename);
        }

        void parse(string filename)
        {
            StepStyle ss = StepStyle.DoubleBeginner;
            NoteName[] nm = new NoteName[] { NoteName.P1_Left, NoteName.P1_Down, NoteName.P1_Up, NoteName.P1_Right,
                                            NoteName.P2_Left, NoteName.P2_Down, NoteName.P2_Up, NoteName.P2_Right,};
            iTickRate = 150;
            stepData = new List<StepData>();

            StreamReader sr = new StreamReader(filename);
            string line = null;

            List<float[]> BPM = new List<float[]>();
            List<float[]> STOP = new List<float[]>();
            List<float> TIMES = new List<float>();


            float[] fLastMeasure = new float[] { 0, 0 };
            float[] last_measure_pad = new float[] { 1, 0.25f };

            while ((line = sr.ReadLine()) != null)
            {
                if (line.StartsWith("#BPMS"))
                {
                    string sBPMString = line.Replace("#BPMS:", string.Empty).Trim();
                    if (!sBPMString.Contains(";"))
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            sBPMString += line.Trim();
                            if (line.Contains(";"))
                                break;
                        }
                    }
                    
                    sBPMString = sBPMString.Replace(";", string.Empty);
                    string[] sBPM = sBPMString.Split(',');
                    foreach (var sbpm in sBPM)
                    {
                        if (!string.IsNullOrEmpty(sbpm))
                        {
                            BPM.Add(new float[] { float.Parse(sbpm.Split('=')[0]), float.Parse(sbpm.Split('=')[1]) });
                            TIMES.Add(float.Parse(sbpm.Split('=')[0]));
                        }
                    }
                }
                else if (line.StartsWith("#STOPS"))
                {
                    string sSTOPString = line.Replace("#STOPS:", string.Empty).Trim();
                    if (!sSTOPString.Contains(";"))
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            sSTOPString += line.Trim();
                            if (line.Contains(";"))
                                break;
                        }
                    }
                    sSTOPString = sSTOPString.Replace(";", string.Empty);
                    string[] sSTOP = sSTOPString.Split(',');
                    foreach (var sstop in sSTOP)
                    {
                        if (!string.IsNullOrEmpty(sstop))
                        {
                            STOP.Add(new float[] { float.Parse(sstop.Split('=')[0]), float.Parse(sstop.Split('=')[1]) });
                            TIMES.Add(float.Parse(sstop.Split('=')[0]));
                        }
                    }



                }
                else if (line.StartsWith("#NOTES"))
                {
                    string sStyleDiff = string.Empty;
                    List<NoteData> noteData = new List<NoteData>();

                    //saltar los metadata
                    List<string> sNoteLines = new List<string>();
                    for (int i = 0; i < 5; i++)
                        sNoteLines.Add(sr.ReadLine().Trim());

                    if (sNoteLines[0] == "dance-single:")
                        sStyleDiff = "single";
                    else if (sNoteLines[0] == "dance-double:")
                        sStyleDiff = "double";


                    if (!string.IsNullOrEmpty(sStyleDiff))
                    {
                        ss = StringToStepStyle(sStyleDiff += "-" + sNoteLines[2].ToLower().Replace(":", string.Empty));


                        List<string> sMeasure = new List<string>();
                        //List<int> iMeasureIDX = new List<int>();

                        int iCount = 0;
                        StringBuilder sSteps = new StringBuilder();
                        //desde acá leer hasta el ;
                        while ((line = sr.ReadLine()) != null)
                        {
                            if (!(line.Trim() == "," || string.IsNullOrEmpty(line.Trim()) || line.Trim() == ";" ||
                                line.Contains("measure")))
                            {
                                sSteps.Append("|");
                                sSteps.Append(line);
                            }
                            if (line.StartsWith(","))
                            {
                                sMeasure.Add(sSteps.ToString().Substring(1, sSteps.Length - 1));
                                //sMeasure.Add(sSteps.ToString().Substring(0, sSteps.Length - 3));
                                sSteps = new StringBuilder();
                                //iMeasureIDX.Add(iCount);
                                iCount++;

                            }
                            if (line == ";")
                            {
                                if (sSteps.Length > 0)
                                    sMeasure.Add(sSteps.ToString().Substring(1, sSteps.Length - 1));
                                break;
                            }
                        }

                        for (int i = 0; i < sMeasure.Count; i++)
                        {
                            int measure_offset = i * 4096;
                            string[] beat = sMeasure[i].Split('|');

                            for (int b = 0; b < beat.Length; b++)
                            {
                                string sBeat = beat[b];
                                if (string.IsNullOrEmpty(sBeat.Replace("0", string.Empty)))
                                    continue;

                                List<NoteName> nt = new List<NoteName>();
                                float fBeatPadding = (float)b / beat.Length;

                                if (MineLayer(sBeat))
                                    nt.Add(NoteName.ShockArrow);
                                else
                                    for (int s = 0; s < sBeat.Length; s++)
                                    {
                                        string c = sBeat[s].ToString();
                                        if (c == "1" || c == "2" || c == "3" || c == "4")
                                        {
                                            NoteName n = nm[s];

                                            if (c == "3")
                                                noteData.Add(new NoteData { iMeasure = i, fBeatPadding = fBeatPadding, sNotes = new List<NoteName> { n }, bFreezeEnd = true });
                                            else
                                                nt.Add(n);
                                        }
                                    }

                                if (nt.Count > 0)
                                    noteData.Add(new NoteData { iMeasure = i, fBeatPadding = fBeatPadding, sNotes = nt, bFreezeEnd = false });

                                //if (bMeasureExtra || nt.Count > 0)
                                {
                                    if (((i) + fBeatPadding) > (fLastMeasure[0] + fLastMeasure[1]))
                                        fLastMeasure = new float[] { i, fBeatPadding };
                                }
                            }
                        }


                        StepData sd = new StepData();
                        sd.sStepStyle = ss;
                        sd.NoteData = noteData;
                        stepData.Add(sd);
                    }
                }
                else if (line.ToUpper().StartsWith("#SAMPLESTART"))
                    fSampleStart = float.Parse(line.Split(':')[1].Replace(";", string.Empty));
                else if (line.ToUpper().StartsWith("#SAMPLELENGTH"))
                    fSampleLenght = float.Parse(line.Split(':')[1].Replace(";", string.Empty));
                else if (line.ToUpper().StartsWith("#MUSIC"))
                    sSampleFile = line.Split(':')[1].Replace(";", string.Empty);
                else if (line.ToUpper().StartsWith("#BACKGROUND"))
                    sBackGroundFile = line.Split(':')[1].Replace(";", string.Empty);
            }
            TIMES = TIMES.Distinct().ToList();
            TIMES.Sort();

            timingChunk = new List<TimingChunk>();
            //timing = new List<object[]>();

            for (int t = 0; t < TIMES.Count; t++)
            {
                for (int b = 0; b < BPM.Count; b++)
                    if (BPM[b][0] == TIMES[t])
                    {
                        timingChunk.Add(new TimingChunk { timingType = TimingType.BPM, fValue = BPM[b][1], dTime = TIMES[t] });
                        //timing.Add(new object[] { "bpm", BPM[b][1], TIMES[t], 0, 0, 0 });
                    }
                for (int s = 0; s < STOP.Count; s++)
                    if (STOP[s][0] == TIMES[t])
                    {
                        //como siempre agrego primero los bpms reviso en esta lista si es que existe un change adicional para este stop
                        bool bExist = false;
                        float fLastSeenBPM = 0;
                        for (int i = 0; i < timingChunk.Count; i++)
                        {
                            if (timingChunk[i].timingType == TimingType.BPM)
                            {
                                fLastSeenBPM = timingChunk[i].fValue;
                                if (TIMES[t] == timingChunk[i].dTime)
                                {
                                    bExist = true;
                                    break;
                                }
                            }
                            else
                                continue;

                        }
                        //si no existe agregar el change adicional antes del stop
                        if (!bExist)
                            timingChunk.Add(new TimingChunk { timingType = TimingType.BPM, fValue = fLastSeenBPM, dTime = TIMES[t] });
                        //timing.Add(new object[] { "stop", STOP[s][1], TIMES[t], 0, 0, 0 });

                        timingChunk.Add(new TimingChunk { timingType = TimingType.STOP, fValue = STOP[s][1], dTime = TIMES[t] });
                    }
            }

            double last_timestamp = 0;
            double last_beat = 0;
            double last_bpm = 0;

            for (int e = 0; e < timingChunk.Count; e++)
            {
                double dBeat = timingChunk[e].dTime;
                float fMeasure = (int)(dBeat * 1024);
                float m = (int)(fMeasure / 4096);
                float n = (fMeasure - (m * 4096)) / 4096;

                double temptimestamp = 0;
                if (timingChunk[e].timingType == TimingType.BPM)
                {
                    if (dBeat != 0)
                        temptimestamp = (((1.0d / (last_bpm / 60000.0d)) * (dBeat - last_beat)) / 1000.0d) + last_timestamp;
                    else
                        temptimestamp = 0;

                    last_bpm = timingChunk[e].fValue;
                }
                else
                    temptimestamp = last_timestamp + (((dBeat - last_beat) / last_bpm) * 60) + timingChunk[e].fValue;

                last_timestamp = temptimestamp;
                last_beat = dBeat;


                timingChunk[e].dTime = temptimestamp;
                timingChunk[e].fOffset = (m + n) * 4096;

                //if (timingChunk[e].timingType == TimingType.BPM)
                //{
                //    Console.WriteLine(temptimestamp + " | BPM");
                //}
                //else if (timingChunk[e].timingType == TimingType.STOP)
                //{
                //    Console.WriteLine(temptimestamp + " | STOp");
                //}
                //else
                //{
                //    Console.WriteLine(temptimestamp + " | NONE");
                //}
                
            }

            double timestamp = 0;
            if (fLastMeasure[0] > 0)
            {
                float[] fMeasure = new float[] { fLastMeasure[0] + last_measure_pad[0], fLastMeasure[1] + last_measure_pad[1] };
                float beat = ((fMeasure[0] + fMeasure[1]) * 4096) / 1024;
                timestamp = (((1 / (last_bpm / 60000)) * (beat - last_beat)) / 1000) + last_timestamp;

                timingChunk.Add(new TimingChunk { timingType = TimingType.None, fValue = 0, dTime = timestamp, fOffset = (fMeasure[0] + fMeasure[1]) * 4096 });
                //Console.WriteLine(timestamp + " | NONE");
            }

            chunkData = new List<ExtraChunk>();
            //chunkDatao = new List<object[]>();

            chunkData.Add(new ExtraChunk { timingSegment = TimingSegment.None, iData = 0x0401, fOffset = 0 });
            chunkData.Add(new ExtraChunk { timingSegment = TimingSegment.None, iData = 0x0102, fOffset = 0 });
            chunkData.Add(new ExtraChunk { timingSegment = TimingSegment.SongStart, iData = 0x202, fOffset = 1 });
            chunkData.Add(new ExtraChunk { timingSegment = TimingSegment.None, iData = 0x0502, fOffset = 1 });
            chunkData.Add(new ExtraChunk { timingSegment = TimingSegment.SongEnd, iData = 0x302, fOffset = fLastMeasure[0] + last_measure_pad[0] + fLastMeasure[1] });
            chunkData.Add(new ExtraChunk { timingSegment = TimingSegment.SongClear, iData = 0x402, fOffset = fLastMeasure[0] + last_measure_pad[0] + fLastMeasure[1] + last_measure_pad[1] });

            SSQWriter sSQWriter = new SSQWriter(this);
            //Console.ReadKey();
        }

        bool MineLayer(string sBeat)
        {
            for (int i = 0; i < sBeat.Length; i++)
                if (sBeat[i].ToString().ToUpper() != "M")
                    return false;
            return true;
        }

        StepStyle StringToStepStyle(string ss)
        {
            switch (ss)
            {
                case "single-beginner": return StepStyle.SingleBeginner;
                case "single-easy": return StepStyle.SingleBasic;
                case "single-medium": return StepStyle.SingleDifficult;
                case "single-hard": return StepStyle.SingleExpert;
                case "single-challenge": return StepStyle.SingleChallenge;
                case "double-beginner": return StepStyle.DoubleBeginner;
                case "double-easy": return StepStyle.DoubleBasic;
                case "double-medium": return StepStyle.DoubleDifficult;
                case "double-hard": return StepStyle.DoubleExpert;
                case "double-challenge": return StepStyle.DoubleChallenge;
                default: return StepStyle.SingleBasic;
            }
        }
    }
}
