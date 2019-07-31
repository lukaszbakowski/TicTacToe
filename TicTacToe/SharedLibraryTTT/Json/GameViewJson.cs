using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibraryTTT.Json
{
    public class GameViewJson
    {
        public string[] Content { get; set; }
        public bool[] Button { get; set; }
        public GameViewJson()
        {
            Content = new string[9];
            Button = new bool[9];
            for (int i = 0; i < 9;i++)
            {
                Content[i] = "";
                Button[i] = false;
            }

        }
    }
}
