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
        public Player LeftPlayer { get; set; }
        public Player RightPlayer { get; set; }
        public MenuViewJson()
        {
            Start = false;
            Surrender = false;
            LeftPlayer = new Player();
            RightPlayer = new Player();

        }
        public class Player
        {
            public bool Accept { get; set; }
            public Player()
            {
                Accept = false;
            }
        }
    }
}
