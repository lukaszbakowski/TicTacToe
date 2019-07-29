using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using TicTacToe.ViewModels;
using TicTacToe.Core;
using TicTacToe.Service;
using System.Runtime.Serialization.Json;

namespace TicTacToe.ViewModels.Base
{
    public class BaseUserConnect<TYPE> : BaseUserControl where TYPE : class
    {

        
        public BaseUserConnect()
        {

        }
        #region "JSON Serialization"
        public string Serializer(TYPE _obj)
        {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(TYPE));
            MemoryStream msObj = new MemoryStream();
            js.WriteObject(msObj, _obj);
            msObj.Position = 0;
            StreamReader sr = new StreamReader(msObj);
  
            string json = sr.ReadToEnd();

            sr.Close();
            msObj.Close();

            return json;
        }
        #endregion


    }
}
