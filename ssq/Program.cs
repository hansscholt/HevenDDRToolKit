using Concentus.Oggfile;
using Concentus.Structs;
using NAudio.Wave;
using ssqtool;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ssqltool
{
    enum StepStyle
    {
        SingleBeginner,
        SingleBasic,
        SingleDifficult,
        SingleExpert,
        SingleChallenge,

        DoubleBeginner,
        DoubleBasic,
        DoubleDifficult,
        DoubleExpert,
        DoubleChallenge,

    }
    enum TimingSegment
    {
        SongStart,
        SongEnd,
        SongClear,
        None
    }
    enum TimingType
    {
        BPM,
        STOP,
        None
    }
    enum NoteName
    {
        P1_Left,
        P1_Down,
        P1_Up,
        P1_Right,
        P2_Left,
        P2_Down,
        P2_Up,
        P2_Right,
        ShockArrow
    }
    class Program
    {
        float fSampleStart;
        float fSampleLenght;
        string sSampleFile;
        string sBackGroundFile;

        static void Main(string[] args)
        {
            Program p = new Program();
            p.NonStatic(args);
            //p.NonStatic(new string[] { "step.sm" });
            //p.TestRaw();
        }
        void NonStatic(string[] args)
        {
            char[] s1 = { '-', '-', '-', 'h', 'e', 'v', 'e', 'n', ' ', 'D', 'D', 'R', ' ', 'T', 'O', 'O', 'L', 'K', 'I', 'T', '-', '-', '-' };
            //char[] s2 = { '-', '-', 'b', 'y', ' ', 'r', 'o', 'l', 'i', 't', 'o', ' ', 'h', 'o', 'a', 'x', ' ', 't', 'e', 'a', 'm', '-', '-' };
            Console.WriteLine(new string(s1));
            //Console.WriteLine(new string(s2));
            Console.WriteLine();
            if (args.Length > 1)
            {
                Console.WriteLine("usage: ssqtool smfile.sm");
                return;
            }
            string sFileName;
            string sShortFileName;
            if (args.Length > 0)
            {
                //Console.WriteLine(">nombre del SM:" + args[0]);
                Console.Write("enter song short name:");
                sFileName = args[0];
                sShortFileName = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("usage: ssqtool smfile.sm");
                return;
            }


            if (!File.Exists(sFileName))
            {
                Console.WriteLine("can't find the sm file");
                return;
            }

            Directory.CreateDirectory("OUT");

            ParseStep(sFileName, sShortFileName);
            ParseAudio(sShortFileName);
            ParseImage(sShortFileName);

            Directory.CreateDirectory("OUT/Win");

            using (StreamWriter sw = new StreamWriter(Path.Combine("OUT",sShortFileName + ".xap"), false))
                sw.Write(new XactTemplate().sXactTemplate.ToString().Replace("@", sShortFileName));

            Console.WriteLine("ready!");
            Console.ReadKey();
        }

        void ParseStep(string sFileName, string sShortFileName)
        {
            Console.WriteLine("proccesing steps");

            SMReader sm = new SMReader(sFileName, sShortFileName);
            fSampleStart = sm.fSampleStart;
            fSampleLenght = sm.fSampleLenght;
            sSampleFile = sm.sSampleFile;
            sBackGroundFile = sm.sBackGroundFile;

            return;
        }


        void TestRaw()
        {
            var filePath = $@"C:\Users\hancs\Documents\Visual Studio 2019\Projects\ssq\ssq\bin\Debug\";
            var fileOgg = "2test.ogg";
            var fileWav = "testAudio.wav";

            using (FileStream fileIn = new FileStream($"{filePath}{fileOgg}", FileMode.Open))
            using (MemoryStream pcmStream = new MemoryStream())
            {
                OpusDecoder decoder = OpusDecoder.Create(48000, 1);
                OpusOggReadStream oggIn = new OpusOggReadStream(decoder, fileIn);
                while (oggIn.HasNextPacket)
                {
                    short[] packet = oggIn.DecodeNextPacket();
                    if (packet != null)
                    {
                        for (int i = 0; i < packet.Length; i++)
                        {
                            var bytes = BitConverter.GetBytes(packet[i]);
                            pcmStream.Write(bytes, 0, bytes.Length);
                        }
                    }
                }
                pcmStream.Position = 0;
                var wavStream = new RawSourceWaveStream(pcmStream, new WaveFormat(48000, 1));
                var sampleProvider = wavStream.ToSampleProvider();
                WaveFileWriter.CreateWaveFile16($"{filePath}{fileWav}", sampleProvider);

            }
        }


        void ParseAudio(string sFileName)
        {
            if (Path.GetExtension(sSampleFile).ToLower() != ".ogg")
            {
                Console.WriteLine("just OGG files are working");
                Console.WriteLine("skipping WAV convertion");
                return;
            }

            if (!File.Exists(sSampleFile))
            {
                Console.WriteLine("can't find #MUSIC file");
                Console.WriteLine("skipping WAV convertion");
                return;
            }

            Console.WriteLine("proccesing WAV");
            TimeSpan totalTime = TimeSpan.Zero;


            {
                string sTemp = Path.Combine(Path.GetTempPath(), "ogg.exe");

                using (FileStream fsDst = new FileStream(sTemp, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    byte[] bytes = ssqtool.Properties.Resources.GetSubExe_oggdec();
                    fsDst.Write(bytes, 0, bytes.Length);
                }

                StringBuilder sCommand = new StringBuilder();
                sCommand.AppendLine(sTemp + @" """ + sSampleFile + @""" -w ""OUT/" + sFileName + @".wav"" -quiet");
                //sCommand.AppendLine(sTemp +  " " + sSampleFile + " -w OUT/" + sFileName);
                Process cmd = new Process();
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.UseShellExecute = false;

                cmd.Start();

                cmd.StandardInput.WriteLine(sCommand.ToString());
                cmd.StandardInput.Flush();

                //Console.WriteLine("DEC>" + lFileName[i]);

                cmd.StandardInput.Close();
                cmd.StandardOutput.ReadToEnd();
            }

            TimeSpan spanStart = TimeSpan.FromSeconds((double)(new decimal(fSampleStart)));
            TimeSpan spanLenght = TimeSpan.FromSeconds((double)(new decimal(fSampleLenght)));
            TrimWavFile("OUT/" + sFileName + ".wav", "OUT/" + sFileName + "_s.wav", spanStart, spanLenght);
        }

        void ParseImage(string sShortFileName)
        {
            if (!File.Exists(sBackGroundFile))
            {
                Console.WriteLine("can't find #BACKGROUND file");
                Console.WriteLine("skipping DDS convertion");
                return;
            }

            Console.WriteLine("proccesing DDS");

            string sTemp = Path.Combine(Path.GetTempPath(), "tex.exe");

            using (FileStream fsDst = new FileStream(sTemp, FileMode.OpenOrCreate, FileAccess.Write))
            {
                byte[] bytes = ssqtool.Properties.Resources.GetSubExe_ddsdec();
                fsDst.Write(bytes, 0, bytes.Length);
            }

            StringBuilder sCommand = new StringBuilder();
            sCommand.AppendLine(sTemp + @" -w 512 -h 512 -f B8G8R8A8_UNORM -y -m 1 """ + sBackGroundFile + @""" -sx _jk -l -o OUT");
            sCommand.AppendLine(sTemp + @" -w 192 -h 192 -f BC1_UNORM -y -m 1 """ + sBackGroundFile + @""" -sx _tn -l -o OUT");
            sCommand.AppendLine("cd OUT");
            sCommand.AppendLine(@"ren """ + Path.GetFileNameWithoutExtension(sBackGroundFile) + @"_jk.dds"" """ + sShortFileName + @"_jk.dds""");
            sCommand.AppendLine(@"ren """ + Path.GetFileNameWithoutExtension(sBackGroundFile) + @"_tn.dds"" """ + sShortFileName + @"_tn.dds""");
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;

            cmd.Start();

            cmd.StandardInput.WriteLine(sCommand.ToString());
            cmd.StandardInput.Flush();

            //Console.WriteLine("DEC>" + lFileName[i]);

            cmd.StandardInput.Close();
            cmd.StandardOutput.ReadToEnd();
        }
        public static void TrimWavFile(string inPath, string outPath, TimeSpan cutFromStart, TimeSpan cutFromEnd)
        {
            Console.WriteLine("generating demo WAV");

            using (WaveFileReader reader = new WaveFileReader(inPath))
            {
                TimeSpan cutTime = reader.TotalTime - cutFromStart - cutFromEnd;
                using (WaveFileWriter writer = new WaveFileWriter(outPath, reader.WaveFormat))
                {
                    int bytesPerMillisecond = reader.WaveFormat.AverageBytesPerSecond / 1000;

                    int startPos = (int)cutFromStart.TotalMilliseconds * bytesPerMillisecond;
                    startPos = startPos - startPos % reader.WaveFormat.BlockAlign;

                    int endBytes = (int)cutTime.TotalMilliseconds * bytesPerMillisecond;
                    endBytes = endBytes - endBytes % reader.WaveFormat.BlockAlign;
                    int endPos = (int)reader.Length - endBytes;

                    TrimWavFile(reader, writer, startPos, endPos);
                }
            }
        }

        private static void TrimWavFile(WaveFileReader reader, WaveFileWriter writer, int startPos, int endPos)
        {
            reader.Position = startPos;
            byte[] buffer = new byte[1024];
            while (reader.Position < endPos)
            {
                int bytesRequired = (int)(endPos - reader.Position);

                if (bytesRequired <= 0)
                    break;

                if (bytesRequired > 0)
                {
                    int bytesToRead = Math.Min(bytesRequired, buffer.Length);
                    int bytesRead = reader.Read(buffer, 0, bytesToRead);
                    if (bytesRead == 0)
                        break;

                    if (bytesRead > 0)
                    {
                        writer.Write(buffer, 0, bytesRead);
                    }
                }
            }
        }
    }
}
