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
        public MsgViewJson MsgSon { get; set; }
        public MenuViewJson MenuSon { get; set; }
        public GameViewJson GameSon { get; set; }
        public ClientStructures()
        {
            SlotSon = new SlotViewJson();
            MsgSon = new MsgViewJson();
            MenuSon = new MenuViewJson();
            GameSon = new GameViewJson();
        }
    }
}
