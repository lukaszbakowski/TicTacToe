using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibraryTTT.Json;

namespace ServerTTT
{
    public class ClientStructures
    {
        public SlotViewJson SlotSon { get; set; }
        public ClientStructures()
        {
            SlotSon = new SlotViewJson();
        }
    }
}
