using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibraryTTT.Json
{
    public class MenuViewJson
    {
        public bool Start { get; set; }
        public bool Surrender { get; set; }
        public MenuViewJson()
        {
            Start = false;
            Surrender = false;
        }
    }
}
