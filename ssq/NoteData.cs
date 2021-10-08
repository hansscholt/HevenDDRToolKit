using ssqltool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ssqtool
{
    class NoteData
    {
        public int iMeasure { get; set; }
        public float fBeatPadding { get; set; }
        public List<NoteName> sNotes { get; set; }
        public bool bFreezeEnd { get; set; }
    }
}
