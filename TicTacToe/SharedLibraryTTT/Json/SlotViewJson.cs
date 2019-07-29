using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibraryTTT.Json
{
    public class SlotViewJson
    {
        public Join LeftJoin { get; set; }
        public Join RightJoin { get; set; }
        public SlotViewJson()
        {
            LeftJoin = new Join();
            RightJoin = new Join();
            LeftJoin.Nick = "X";
            RightJoin.Nick = "O";
        }
        public class Join
        {

            public string Nick { get; set; }
            public bool Button { get; set; }
            public Join()
            {
                Button = true;
            }
        }
    }
}
