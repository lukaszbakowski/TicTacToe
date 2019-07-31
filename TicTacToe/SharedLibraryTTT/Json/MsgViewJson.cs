using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibraryTTT.Json
{
    public class MsgViewJson
    {
        public string Message { get; set; }
        public List<string> Nick { get; set; }

        public MsgViewJson()
        {
            Message = "";
            Nick = new List<string>();
        }
    }
}
