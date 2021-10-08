using ssqltool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ssqtool
{
    class TimingChunk
    {
        public TimingType timingType { get; set; }
        public float fValue { get; set; }
        public double dTime { get; set; }
        public float fOffset { get; set; }
    }
}
