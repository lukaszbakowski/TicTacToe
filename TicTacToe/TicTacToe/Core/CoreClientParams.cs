using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Core
{
    public class CoreClientParams
    {

        static CoreClientParams()
        {
            MessageReceivedChanged += (sender, e) => { return; };
            NickListChanged += (sender, e) => { return; };
        }

        #region
        #endregion

        #region "NickList"

        private static string _nickList;
        public static string NickList
        {
            get
            {
                return _nickList;
            }
            set
            {
                _nickList = value;

                OnNickListChanged(EventArgs.Empty);
            }
        }

        // Declare a static event representing changes to your static property
        public static event EventHandler NickListChanged;

        // Raise the change event through this static method
        protected static void OnNickListChanged(EventArgs e)
        {
            NickListChanged?.Invoke(null, e);
        }
        #endregion
        #region "MessageReceived"
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


        
        // Declare a static event representing changes to your static property
        public static event EventHandler MessageReceivedChanged;

        // Raise the change event through this static method
        protected static void OnMessageReceivedChanged(EventArgs e)
        {
            MessageReceivedChanged?.Invoke(null, e);
        }

        #endregion
    }
}
