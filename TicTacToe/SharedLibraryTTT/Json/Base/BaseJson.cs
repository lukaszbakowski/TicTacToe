using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.Serialization.Json;

namespace SharedLibraryTTT.Json.Base
{
    public class BaseJson<TYPE> where TYPE : class
    {
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
        public TYPE Deserializer(string _data)
        {
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(_data)))
            {
                DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(TYPE));
                TYPE SlotSon = (TYPE)deserializer.ReadObject(ms);
                ms.Close();
                return SlotSon;
            }
        }
    }
}
