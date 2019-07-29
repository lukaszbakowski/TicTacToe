using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibraryTTT.Json
{
    public class GameViewJson
    {
        public string[,] GameBoard { get; set; }
        GameViewJson()
        {
            GameBoard = new string[3, 3];
            for (int i = 0; i < GameBoard.Length;i++)
            {
                for(int j = 0; j < GameBoard.Length;j++)
                {
                    GameBoard[i,j] = "";
                }
            }
        }
    }
}
