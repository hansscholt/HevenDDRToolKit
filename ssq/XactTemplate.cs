﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ssqtool
{
    class XactTemplate
    {
        public StringBuilder sXactTemplate { get; set; }

        public XactTemplate()
        {
            sXactTemplate = new StringBuilder();
            sXactTemplate.AppendLine("Signature = XACT2;");
            sXactTemplate.AppendLine("Version = 16;");
            sXactTemplate.AppendLine("Content Version = 43;");
            sXactTemplate.AppendLine("Release = August 2007;");
            sXactTemplate.AppendLine();
            sXactTemplate.AppendLine("Options");
            sXactTemplate.AppendLine("{");
            sXactTemplate.AppendLine("\tVerbose Report = 0;");
            sXactTemplate.AppendLine("\tGenerate C/C++ Headers = 1;");
            sXactTemplate.AppendLine("}");
            sXactTemplate.AppendLine();
            sXactTemplate.AppendLine("Global Settings");
            sXactTemplate.AppendLine("{");
            sXactTemplate.AppendLine("\tXbox File = Xbox\\@.xgs;");
            sXactTemplate.AppendLine("\tWindows File = Win\\@.xgs;");
            sXactTemplate.AppendLine("\tHeader File = @.h;");
            sXactTemplate.AppendLine("\tExclude Category Names = 0;");
            sXactTemplate.AppendLine("\tExclude Variable Names = 0;");
            sXactTemplate.AppendLine("\tLast Modified Low = 30486394;");
            sXactTemplate.AppendLine("\tLast Modified High = 3053922010;");
            sXactTemplate.AppendLine();
            sXactTemplate.AppendLine("\tCategory");
            sXactTemplate.AppendLine("\t{");
            sXactTemplate.AppendLine("\t\tName = Global;");
            sXactTemplate.AppendLine("\t\tPublic = 1;");
            sXactTemplate.AppendLine("\t\tBackground Music = 0;");
            sXactTemplate.AppendLine("\t\tVolume = 0;");
            sXactTemplate.AppendLine();
            sXactTemplate.AppendLine("\t\tCategory Entry");
            sXactTemplate.AppendLine("\t\t{");
            sXactTemplate.AppendLine("\t\t}");
            sXactTemplate.AppendLine();
            sXactTemplate.AppendLine("\t\tInstance Limit");
            sXactTemplate.AppendLine("\t\t{");
            sXactTemplate.AppendLine("\t\t\tMax Instances = 255;");
            sXactTemplate.AppendLine("\t\t\tBehavior = 0;");
            sXactTemplate.AppendLine();
            sXactTemplate.AppendLine("\t\t\tCrossfade");
            sXactTemplate.AppendLine("\t\t\t{");
            sXactTemplate.AppendLine("\t\t\t\tFade In = 0;");
            sXactTemplate.AppendLine("\t\t\t\tFade Out = 0;");
            sXactTemplate.AppendLine("\t\t\t\tCrossfade Type = 0;");
            sXactTemplate.AppendLine("\t\t\t}");
            sXactTemplate.AppendLine("\t\t}");
            sXactTemplate.AppendLine("\t}");
            sXactTemplate.AppendLine();
            sXactTemplate.AppendLine("\tCategory");
            sXactTemplate.AppendLine("\t{");
            sXactTemplate.AppendLine("\t\tName = Default;");
            sXactTemplate.AppendLine("\t\tPublic = 1;");
            sXactTemplate.AppendLine("\t\tBackground Music = 0;");
            sXactTemplate.AppendLine("\t\tVolume = 0;");
            sXactTemplate.AppendLine();
            sXactTemplate.AppendLine("\t\tCategory Entry");
            sXactTemplate.AppendLine("\t\t{");
            sXactTemplate.AppendLine("\t\t\tName = Global;");
            sXactTemplate.AppendLine("\t\t}");
            sXactTemplate.AppendLine();
            sXactTemplate.AppendLine("\t\tInstance Limit");
            sXactTemplate.AppendLine("\t\t{");
            sXactTemplate.AppendLine("\t\t\tMax Instances = 255;");
            sXactTemplate.AppendLine("\t\t\tBehavior = 0;");
            sXactTemplate.AppendLine();
            sXactTemplate.AppendLine("\t\t\tCrossfade");
            sXactTemplate.AppendLine("\t\t\t{");
            sXactTemplate.AppendLine("\t\t\t\tFade In = 0;");
            sXactTemplate.AppendLine("\t\t\t\tFade Out = 0;");
            sXactTemplate.AppendLine("\t\t\t\tCrossfade Type = 0;");
            sXactTemplate.AppendLine("\t\t\t}");
            sXactTemplate.AppendLine("\t\t}");
            sXactTemplate.AppendLine("\t}");
            sXactTemplate.AppendLine();
            sXactTemplate.AppendLine("\tCategory");
            sXactTemplate.AppendLine("\t{");
            sXactTemplate.AppendLine("\t\tName = Music;");
            sXactTemplate.AppendLine("\t\tPublic = 1;");
            sXactTemplate.AppendLine("\t\tBackground Music = 1;");
            sXactTemplate.AppendLine("\t\tVolume = 0;");
            sXactTemplate.AppendLine();
            sXactTemplate.AppendLine("\t\tCategory Entry");
            sXactTemplate.AppendLine("\t\t{");
            sXactTemplate.AppendLine("\t\t\tName = Global;");
            sXactTemplate.AppendLine("\t\t}");
            sXactTemplate.AppendLine();
            sXactTemplate.AppendLine("\t\tInstance Limit");
            sXactTemplate.AppendLine("\t\t{");
            sXactTemplate.AppendLine("\t\t\tMax Instances = 255;");
            sXactTemplate.AppendLine("\t\t\tBehavior = 0;");
            sXactTemplate.AppendLine();
            sXactTemplate.AppendLine("\t\t\tCrossfade");
            sXactTemplate.AppendLine("\t\t\t{");
            sXactTemplate.AppendLine("\t\t\t\tFade In = 0;");
            sXactTemplate.AppendLine("\t\t\t\tFade Out = 0;");
            sXactTemplate.AppendLine("\t\t\t\tCrossfade Type = 0;");
            sXactTemplate.AppendLine("\t\t\t}");
            sXactTemplate.AppendLine("\t\t}");
            sXactTemplate.AppendLine("\t}");
            sXactTemplate.AppendLine();
            sXactTemplate.AppendLine("\tVariable");
            sXactTemplate.AppendLine("\t{");
            sXactTemplate.AppendLine("\t\tName = OrientationAngle;");
            sXactTemplate.AppendLine("\t\tPublic = 1;");
            sXactTemplate.AppendLine("\t\tGlobal = 0;");
            sXactTemplate.AppendLine("\t\tInternal = 0;");
            sXactTemplate.AppendLine("\t\tExternal = 0;");
            sXactTemplate.AppendLine("\t\tMonitored = 1;");
            sXactTemplate.AppendLine("\t\tReserved = 1;");
            sXactTemplate.AppendLine("\t\tRead Only = 0;");
            sXactTemplate.AppendLine("\t\tTime = 0;");
            sXactTemplate.AppendLine("\t\tValue = 0.000000;");
            sXactTemplate.AppendLine("\t\tInitial Value = 0.000000;");
            sXactTemplate.AppendLine("\t\tMin = -180.000000;");
            sXactTemplate.AppendLine("\t\tMax = 180.000000;");
            sXactTemplate.AppendLine("\t}");
            sXactTemplate.AppendLine();
            sXactTemplate.AppendLine("\tVariable");
            sXactTemplate.AppendLine("\t{");
            sXactTemplate.AppendLine("\t\tName = DopplerPitchScalar;");
            sXactTemplate.AppendLine("\t\tPublic = 1;");
            sXactTemplate.AppendLine("\t\tGlobal = 0;");
            sXactTemplate.AppendLine("\t\tInternal = 0;");
            sXactTemplate.AppendLine("\t\tExternal = 0;");
            sXactTemplate.AppendLine("\t\tMonitored = 1;");
            sXactTemplate.AppendLine("\t\tReserved = 1;");
            sXactTemplate.AppendLine("\t\tRead Only = 0;");
            sXactTemplate.AppendLine("\t\tTime = 0;");
            sXactTemplate.AppendLine("\t\tValue = 1.000000;");
            sXactTemplate.AppendLine("\t\tInitial Value = 1.000000;");
            sXactTemplate.AppendLine("\t\tMin = 0.000000;");
            sXactTemplate.AppendLine("\t\tMax = 4.000000;");
            sXactTemplate.AppendLine("\t}");
            sXactTemplate.AppendLine();
            sXactTemplate.AppendLine("\tVariable");
            sXactTemplate.AppendLine("\t{");
            sXactTemplate.AppendLine("\t\tName = SpeedOfSound;");
            sXactTemplate.AppendLine("\t\tPublic = 1;");
            sXactTemplate.AppendLine("\t\tGlobal = 1;");
            sXactTemplate.AppendLine("\t\tInternal = 0;");
            sXactTemplate.AppendLine("\t\tExternal = 0;");
            sXactTemplate.AppendLine("\t\tMonitored = 1;");
            sXactTemplate.AppendLine("\t\tReserved = 1;");
            sXactTemplate.AppendLine("\t\tRead Only = 0;");
            sXactTemplate.AppendLine("\t\tTime = 0;");
            sXactTemplate.AppendLine("\t\tValue = 343.500000;");
            sXactTemplate.AppendLine("\t\tInitial Value = 343.500000;");
            sXactTemplate.AppendLine("\t\tMin = 0.000000;");
            sXactTemplate.AppendLine("\t\tMax = 1000000.000000;");
            sXactTemplate.AppendLine("\t}");
            sXactTemplate.AppendLine();
            sXactTemplate.AppendLine("\tVariable");
            sXactTemplate.AppendLine("\t{");
            sXactTemplate.AppendLine("\t\tName = ReleaseTime;");
            sXactTemplate.AppendLine("\t\tPublic = 1;");
            sXactTemplate.AppendLine("\t\tGlobal = 0;");
            sXactTemplate.AppendLine("\t\tInternal = 1;");
            sXactTemplate.AppendLine("\t\tExternal = 1;");
            sXactTemplate.AppendLine("\t\tMonitored = 1;");
            sXactTemplate.AppendLine("\t\tReserved = 1;");
            sXactTemplate.AppendLine("\t\tRead Only = 1;");
            sXactTemplate.AppendLine("\t\tTime = 1;");
            sXactTemplate.AppendLine("\t\tValue = 0.000000;");
            sXactTemplate.AppendLine("\t\tInitial Value = 0.000000;");
            sXactTemplate.AppendLine("\t\tMin = 0.000000;");
            sXactTemplate.AppendLine("\t\tMax = 15.000001;");
            sXactTemplate.AppendLine("\t}");
            sXactTemplate.AppendLine();
            sXactTemplate.AppendLine("\tVariable");
            sXactTemplate.AppendLine("\t{");
            sXactTemplate.AppendLine("\t\tName = AttackTime;");
            sXactTemplate.AppendLine("\t\tPublic = 1;");
            sXactTemplate.AppendLine("\t\tGlobal = 0;");
            sXactTemplate.AppendLine("\t\tInternal = 1;");
            sXactTemplate.AppendLine("\t\tExternal = 1;");
            sXactTemplate.AppendLine("\t\tMonitored = 1;");
            sXactTemplate.AppendLine("\t\tReserved = 1;");
            sXactTemplate.AppendLine("\t\tRead Only = 1;");
            sXactTemplate.AppendLine("\t\tTime = 1;");
            sXactTemplate.AppendLine("\t\tValue = 0.000000;");
            sXactTemplate.AppendLine("\t\tInitial Value = 0.000000;");
            sXactTemplate.AppendLine("\t\tMin = 0.000000;");
            sXactTemplate.AppendLine("\t\tMax = 15.000001;");
            sXactTemplate.AppendLine("\t}");
            sXactTemplate.AppendLine();
            sXactTemplate.AppendLine("\tVariable");
            sXactTemplate.AppendLine("\t{");
            sXactTemplate.AppendLine("\t\tName = NumCueInstances;");
            sXactTemplate.AppendLine("\t\tPublic = 1;");
            sXactTemplate.AppendLine("\t\tGlobal = 0;");
            sXactTemplate.AppendLine("\t\tInternal = 1;");
            sXactTemplate.AppendLine("\t\tExternal = 1;");
            sXactTemplate.AppendLine("\t\tMonitored = 1;");
            sXactTemplate.AppendLine("\t\tReserved = 1;");
            sXactTemplate.AppendLine("\t\tRead Only = 1;");
            sXactTemplate.AppendLine("\t\tTime = 0;");
            sXactTemplate.AppendLine("\t\tValue = 0.000000;");
            sXactTemplate.AppendLine("\t\tInitial Value = 0.000000;");
            sXactTemplate.AppendLine("\t\tMin = 0.000000;");
            sXactTemplate.AppendLine("\t\tMax = 1024.000000;");
            sXactTemplate.AppendLine("\t}");
            sXactTemplate.AppendLine();
            sXactTemplate.AppendLine("\tVariable");
            sXactTemplate.AppendLine("\t{");
            sXactTemplate.AppendLine("\t\tName = Distance;");
            sXactTemplate.AppendLine("\t\tPublic = 1;");
            sXactTemplate.AppendLine("\t\tGlobal = 0;");
            sXactTemplate.AppendLine("\t\tInternal = 0;");
            sXactTemplate.AppendLine("\t\tExternal = 0;");
            sXactTemplate.AppendLine("\t\tMonitored = 1;");
            sXactTemplate.AppendLine("\t\tReserved = 1;");
            sXactTemplate.AppendLine("\t\tRead Only = 0;");
            sXactTemplate.AppendLine("\t\tTime = 0;");
            sXactTemplate.AppendLine("\t\tValue = 0.000000;");
            sXactTemplate.AppendLine("\t\tInitial Value = 0.000000;");
            sXactTemplate.AppendLine("\t\tMin = 0.000000;");
            sXactTemplate.AppendLine("\t\tMax = 1000000.000000;");
            sXactTemplate.AppendLine("\t}");
            sXactTemplate.AppendLine();
            sXactTemplate.AppendLine("\tCompression Preset");
            sXactTemplate.AppendLine("\t{");
            sXactTemplate.AppendLine("\t\tName = @;");
            sXactTemplate.AppendLine("\t\tXbox Format Tag = 357;");
            sXactTemplate.AppendLine("\t\tTarget Sample Rate = 48000;");
            sXactTemplate.AppendLine("\t\tQuality = 60;");
            sXactTemplate.AppendLine("\t\tFind Best Quality = 0;");
            sXactTemplate.AppendLine("\t\tHigh Freq Cut = 0;");
            sXactTemplate.AppendLine("\t\tLoop = 0;");
            sXactTemplate.AppendLine("\t\tPC Format Tag = 2;");
            sXactTemplate.AppendLine("\t\tSamples Per Block = 128;");
            sXactTemplate.AppendLine("\t}");
            sXactTemplate.AppendLine("}");
            sXactTemplate.AppendLine();
            sXactTemplate.AppendLine("Wave Bank");
            sXactTemplate.AppendLine("{");
            sXactTemplate.AppendLine("\tName = @;");
            sXactTemplate.AppendLine("\tXbox File = Xbox\\@.xwb;");
            sXactTemplate.AppendLine("\tWindows File = Win\\@.xwb;");
            sXactTemplate.AppendLine("\tXbox Bank Path Edited = 0;");
            sXactTemplate.AppendLine("\tWindows Bank Path Edited = 0;");
            sXactTemplate.AppendLine("\tStreaming = 1;");
            sXactTemplate.AppendLine("\tEntry Names = 1;");
            sXactTemplate.AppendLine("\tSeek Tables = 1;");
            sXactTemplate.AppendLine("\tCompression Preset Name = @;");
            sXactTemplate.AppendLine("\tXbox Bank Last Modified Low = 0;");
            sXactTemplate.AppendLine("\tXbox Bank Last Modified High = 0;");
            sXactTemplate.AppendLine("\tPC Bank Last Modified Low = 3053942007;");
            sXactTemplate.AppendLine("\tPC Bank Last Modified High = 30486394;");
            sXactTemplate.AppendLine("\tHeader Last Modified Low = 0;");
            sXactTemplate.AppendLine("\tHeader Last Modified High = 0;");
            sXactTemplate.AppendLine("\tBank Last Revised Low = 3308305416;");
            sXactTemplate.AppendLine("\tBank Last Revised High = 30486089;");
            sXactTemplate.AppendLine();
            sXactTemplate.AppendLine("\tWave");
            sXactTemplate.AppendLine("\t{");
            sXactTemplate.AppendLine("\t\tName = @;");
            sXactTemplate.AppendLine("\t\tFile = @.wav;");
            sXactTemplate.AppendLine("\t\tBuild Settings Last Modified Low = 3149326346;");
            sXactTemplate.AppendLine("\t\tBuild Settings Last Modified High = 30486089;");
            sXactTemplate.AppendLine();
            sXactTemplate.AppendLine("\t\tCache");
            sXactTemplate.AppendLine("\t\t{");
            sXactTemplate.AppendLine("\t\t\tFormat Tag = 0;");
            sXactTemplate.AppendLine("\t\t\tChannels = 2;");
            sXactTemplate.AppendLine("\t\t\tSampling Rate = 44100;");
            sXactTemplate.AppendLine("\t\t\tBits Per Sample = 1;");
            sXactTemplate.AppendLine("\t\t\tPlay Region Offset = 44;");
            sXactTemplate.AppendLine("\t\t\tPlay Region Length = 14112640;");
            sXactTemplate.AppendLine("\t\t\tLoop Region Offset = 0;");
            sXactTemplate.AppendLine("\t\t\tLoop Region Length = 0;");
            sXactTemplate.AppendLine("\t\t\tFile Type = 1;");
            sXactTemplate.AppendLine("\t\t\tLast Modified Low = 1942547820;");
            sXactTemplate.AppendLine("\t\t\tLast Modified High = 30486089;");
            sXactTemplate.AppendLine("\t\t}");
            sXactTemplate.AppendLine("\t}");
            sXactTemplate.AppendLine();
            sXactTemplate.AppendLine("\tWave");
            sXactTemplate.AppendLine("\t{");
            sXactTemplate.AppendLine("\t\tName = @_s;");
            sXactTemplate.AppendLine("\t\tFile = @_s.wav;");
            sXactTemplate.AppendLine("\t\tBuild Settings Last Modified Low = 3308295410;");
            sXactTemplate.AppendLine("\t\tBuild Settings Last Modified High = 30486089;");
            sXactTemplate.AppendLine();
            sXactTemplate.AppendLine("\t\tCache");
            sXactTemplate.AppendLine("\t\t{");
            sXactTemplate.AppendLine("\t\t\tFormat Tag = 0;");
            sXactTemplate.AppendLine("\t\t\tChannels = 2;");
            sXactTemplate.AppendLine("\t\t\tSampling Rate = 44100;");
            sXactTemplate.AppendLine("\t\t\tBits Per Sample = 1;");
            sXactTemplate.AppendLine("\t\t\tPlay Region Offset = 44;");
            sXactTemplate.AppendLine("\t\t\tPlay Region Length = 2646392;");
            sXactTemplate.AppendLine("\t\t\tLoop Region Offset = 0;");
            sXactTemplate.AppendLine("\t\t\tLoop Region Length = 0;");
            sXactTemplate.AppendLine("\t\t\tFile Type = 1;");
            sXactTemplate.AppendLine("\t\t\tLast Modified Low = 2100978975;");
            sXactTemplate.AppendLine("\t\t\tLast Modified High = 30486089;");
            sXactTemplate.AppendLine("\t\t}");
            sXactTemplate.AppendLine("\t}");
            sXactTemplate.AppendLine("}");
            sXactTemplate.AppendLine();
            sXactTemplate.AppendLine("Sound Bank");
            sXactTemplate.AppendLine("{");
            sXactTemplate.AppendLine("\tName = @;");
            sXactTemplate.AppendLine("\tXbox File = Xbox\\@.xsb;");
            sXactTemplate.AppendLine("\tWindows File = Win\\@.xsb;");
            sXactTemplate.AppendLine("\tXbox Bank Path Edited = 0;");
            sXactTemplate.AppendLine("\tWindows Bank Path Edited = 0;");
            sXactTemplate.AppendLine("\tHeader Last Modified High = 0;");
            sXactTemplate.AppendLine("\tHeader Last Modified Low = 0;");
            sXactTemplate.AppendLine();
            sXactTemplate.AppendLine("\tSound");
            sXactTemplate.AppendLine("\t{");
            sXactTemplate.AppendLine("\t\tName = @;");
            sXactTemplate.AppendLine("\t\tVolume = 0;");
            sXactTemplate.AppendLine("\t\tPitch = 0;");
            sXactTemplate.AppendLine("\t\tPriority = 0;");
            sXactTemplate.AppendLine();
            sXactTemplate.AppendLine("\t\tCategory Entry");
            sXactTemplate.AppendLine("\t\t{");
            sXactTemplate.AppendLine("\t\t\tName = Default;");
            sXactTemplate.AppendLine("\t\t}");
            sXactTemplate.AppendLine();
            sXactTemplate.AppendLine("\t\tTrack");
            sXactTemplate.AppendLine("\t\t{");
            sXactTemplate.AppendLine("\t\t\tVolume = 0;");
            sXactTemplate.AppendLine();
            sXactTemplate.AppendLine("\t\t\tPlay Wave Event");
            sXactTemplate.AppendLine("\t\t\t{");
            sXactTemplate.AppendLine("\t\t\t\tBreak Loop = 0;");
            sXactTemplate.AppendLine("\t\t\t\tUse Speaker Position = 0;");
            sXactTemplate.AppendLine("\t\t\t\tUse Center Speaker = 1;");
            sXactTemplate.AppendLine("\t\t\t\tNew Speaker Position On Loop = 1;");
            sXactTemplate.AppendLine("\t\t\t\tSpeaker Position Angle = 0.000000;");
            sXactTemplate.AppendLine("\t\t\t\tSpeaer Position Arc = 0.000000;");
            sXactTemplate.AppendLine();
            sXactTemplate.AppendLine("\t\t\t\tEvent Header");
            sXactTemplate.AppendLine("\t\t\t\t{");
            sXactTemplate.AppendLine("\t\t\t\t    Timestamp = 0;");
            sXactTemplate.AppendLine("\t\t\t\t    Relative = 0;");
            sXactTemplate.AppendLine("\t\t\t\t    Random Recurrence = 0;");
            sXactTemplate.AppendLine("\t\t\t\t    Random Offset = 0;");
            sXactTemplate.AppendLine("\t\t\t\t}");
            sXactTemplate.AppendLine();
            sXactTemplate.AppendLine("\t\t\t\tWave Entry");
            sXactTemplate.AppendLine("\t\t\t\t{");
            sXactTemplate.AppendLine("\t\t\t\t    Bank Name = @;");
            sXactTemplate.AppendLine("\t\t\t\t    Bank Index = 0;");
            sXactTemplate.AppendLine("\t\t\t\t    Entry Name = @;");
            sXactTemplate.AppendLine("\t\t\t\t    Entry Index = 0;");
            sXactTemplate.AppendLine("\t\t\t\t    Weight = 255;");
            sXactTemplate.AppendLine("\t\t\t\t    Weight Min = 0;");
            sXactTemplate.AppendLine("\t\t\t\t}");
            sXactTemplate.AppendLine("\t\t\t}");
            sXactTemplate.AppendLine("\t\t}");
            sXactTemplate.AppendLine("\t}");
            sXactTemplate.AppendLine();
            sXactTemplate.AppendLine("\tSound");
            sXactTemplate.AppendLine("\t{");
            sXactTemplate.AppendLine("\t\tName = @_s;");
            sXactTemplate.AppendLine("\t\tVolume = 0;");
            sXactTemplate.AppendLine("\t\tPitch = 0;");
            sXactTemplate.AppendLine("\t\tPriority = 0;");
            sXactTemplate.AppendLine();
            sXactTemplate.AppendLine("\t\tCategory Entry");
            sXactTemplate.AppendLine("\t\t{");
            sXactTemplate.AppendLine("\t\t\tName = Default;");
            sXactTemplate.AppendLine("\t\t}");
            sXactTemplate.AppendLine();
            sXactTemplate.AppendLine("\t\tTrack");
            sXactTemplate.AppendLine("\t\t{");
            sXactTemplate.AppendLine("\t\t\tVolume = 0;");
            sXactTemplate.AppendLine();
            sXactTemplate.AppendLine("\t\t\tPlay Wave Event");
            sXactTemplate.AppendLine("\t\t\t{");
            sXactTemplate.AppendLine("\t\t\t\tLoop Count = 255;");
            sXactTemplate.AppendLine("\t\t\t\tBreak Loop = 0;");
            sXactTemplate.AppendLine("\t\t\t\tUse Speaker Position = 0;");
            sXactTemplate.AppendLine("\t\t\t\tUse Center Speaker = 1;");
            sXactTemplate.AppendLine("\t\t\t\tNew Speaker Position On Loop = 1;");
            sXactTemplate.AppendLine("\t\t\t\tSpeaker Position Angle = 0.000000;");
            sXactTemplate.AppendLine("\t\t\t\tSpeaer Position Arc = 0.000000;");
            sXactTemplate.AppendLine();
            sXactTemplate.AppendLine("\t\t\t\tEvent Header");
            sXactTemplate.AppendLine("\t\t\t\t{");
            sXactTemplate.AppendLine("\t\t\t\t    Timestamp = 0;");
            sXactTemplate.AppendLine("\t\t\t\t    Relative = 0;");
            sXactTemplate.AppendLine("\t\t\t\t    Random Recurrence = 0;");
            sXactTemplate.AppendLine("\t\t\t\t    Random Offset = 0;");
            sXactTemplate.AppendLine("\t\t\t\t}");
            sXactTemplate.AppendLine();
            sXactTemplate.AppendLine("\t\t\t\tWave Entry");
            sXactTemplate.AppendLine("\t\t\t\t{");
            sXactTemplate.AppendLine("\t\t\t\t    Bank Name = @;");
            sXactTemplate.AppendLine("\t\t\t\t    Bank Index = 0;");
            sXactTemplate.AppendLine("\t\t\t\t    Entry Name = @_s;");
            sXactTemplate.AppendLine("\t\t\t\t    Entry Index = 1;");
            sXactTemplate.AppendLine("\t\t\t\t    Weight = 255;");
            sXactTemplate.AppendLine("\t\t\t\t    Weight Min = 0;");
            sXactTemplate.AppendLine("\t\t\t\t}");
            sXactTemplate.AppendLine("\t\t\t}");
            sXactTemplate.AppendLine("\t\t}");
            sXactTemplate.AppendLine("\t}");
            sXactTemplate.AppendLine();
            sXactTemplate.AppendLine("\tCue");
            sXactTemplate.AppendLine("\t{");
            sXactTemplate.AppendLine("\t\tName = @;");
            sXactTemplate.AppendLine();
            sXactTemplate.AppendLine("\t\tVariation");
            sXactTemplate.AppendLine("\t\t{");
            sXactTemplate.AppendLine("\t\t\tVariation Type = 3;");
            sXactTemplate.AppendLine("\t\t\tVariation Table Type = 1;");
            sXactTemplate.AppendLine("\t\t\tNew Variation on Loop = 0;");
            sXactTemplate.AppendLine("\t\t}");
            sXactTemplate.AppendLine();
            sXactTemplate.AppendLine("\t\tSound Entry");
            sXactTemplate.AppendLine("\t\t{");
            sXactTemplate.AppendLine("\t\t\tName = @;");
            sXactTemplate.AppendLine("\t\t\tIndex = 0;");
            sXactTemplate.AppendLine("\t\t\tWeight Min = 0;");
            sXactTemplate.AppendLine("\t\t\tWeight Max = 255;");
            sXactTemplate.AppendLine("\t\t}");
            sXactTemplate.AppendLine("\t}");
            sXactTemplate.AppendLine();
            sXactTemplate.AppendLine("\tCue");
            sXactTemplate.AppendLine("\t{");
            sXactTemplate.AppendLine("\t\tName = @_s;");
            sXactTemplate.AppendLine();
            sXactTemplate.AppendLine("\t\tVariation");
            sXactTemplate.AppendLine("\t\t{");
            sXactTemplate.AppendLine("\t\t\tVariation Type = 3;");
            sXactTemplate.AppendLine("\t\t\tVariation Table Type = 1;");
            sXactTemplate.AppendLine("\t\t\tNew Variation on Loop = 0;");
            sXactTemplate.AppendLine("\t\t}");
            sXactTemplate.AppendLine();
            sXactTemplate.AppendLine("\t\tSound Entry");
            sXactTemplate.AppendLine("\t\t{");
            sXactTemplate.AppendLine("\t\t\tName = @_s;");
            sXactTemplate.AppendLine("\t\t\tIndex = 1;");
            sXactTemplate.AppendLine("\t\t\tWeight Min = 0;");
            sXactTemplate.AppendLine("\t\t\tWeight Max = 255;");
            sXactTemplate.AppendLine("\t\t}");
            sXactTemplate.AppendLine("\t}");
            sXactTemplate.AppendLine("}");
            sXactTemplate.AppendLine();

        }
    }
}
