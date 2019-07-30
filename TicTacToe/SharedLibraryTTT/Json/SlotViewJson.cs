using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibraryTTT.Json
{
    public class SlotViewJson
    {
        public Slot Left { get; set; }
        public Slot Right { get; set; }
        public SlotViewJson()
        {
            Left = new Slot();
            Right = new Slot();
            Left.Nick = "X";
            Right.Nick = "O";
        }
        public class Slot
        {

            public string Nick { get; set; }
            public bool Button { get; set; }
            public Slot()
            {
                Button = true;
            }
        }
    }
}
