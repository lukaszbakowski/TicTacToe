using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ServerTTT
{
    class ServerCommands
    {
        public ServerCommands()
        {
 
        }



        public void SwitchCommand(int _choice, NetworkStream _stream)
        {
            switch(_choice)
            {
                case 1: //setup nick

                    break;
                case 2: //left join

                    break;
                case 3: //right join
                    break;
                case 4: //players list
                    break;
                case 5: //game handler
                    break;

                default:
                    break;
            }
        }
    }
}
