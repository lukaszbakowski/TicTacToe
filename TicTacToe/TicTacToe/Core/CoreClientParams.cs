using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Core
{
    public class CoreClientParams
    {
        private static string _messageReceived;

        public static string MessageReceived
        {
            get
            {
                return _messageReceived;
            }

            set
            {
                _messageReceived = value;

                OnMessageReceivedChanged(EventArgs.Empty);
            }
        }


        #region "static event handler"
        // Declare a static event representing changes to your static property
        public static event EventHandler MessageReceivedChanged;

        // Raise the change event through this static method
        protected static void OnMessageReceivedChanged(EventArgs e)
        {
            MessageReceivedChanged?.Invoke(null, e);
        }

        static CoreClientParams()
        {
            // Set up an empty event handler
            MessageReceivedChanged += (sender, e) => { return; };
        }
        #endregion
    }
}
