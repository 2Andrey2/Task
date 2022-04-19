using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.Json;
using Task_Client_.Data.Entities;
using Task_Client_.Models.ConnectingSockets;
using Task;
using Task.Entities;
using Task.Media;

namespace Task_Client_.Models.Actions
{
    class Actions
    {
        protected WorkSoket connect;
        public Actions()
        {
            connect = new WorkSoket();
        }
        protected byte[] SerializationString(object data)
        {
            if(data is string[])
            {
                data = Encryption.EncodeDecryptMass((string[])data);
                return JsonSerializer.SerializeToUtf8Bytes(data);
            }
            if(data is tusers)
            {
                return JsonSerializer.SerializeToUtf8Bytes((tusers)data);
            }
            if (data is List<string>)
            {
                return JsonSerializer.SerializeToUtf8Bytes((List<string>)data);
            }
            if (data is List<tusers_group_chat>)
            {
                return JsonSerializer.SerializeToUtf8Bytes((List<tusers_group_chat>)data);
            }
            if (data is Image)
            {
                return WorkingImages.ImageEncoding((Image)data);
            }
            return null;
        }
        protected object SendingRequest(object data, string task, string dataType)
        {
            byte[] massdata = SerializationString(data);
            List<string> infoData = null;
            if (UserNow.key != null)
            {
                infoData = new List<string> { task, massdata.Length.ToString(), dataType, UserNow.key };
            }
            else
            {
                infoData = new List<string> { task, massdata.Length.ToString(), dataType};
            }
            string resultS = (string)connect.DataPreparation(SerializationString(infoData), "string");
            if (resultS != "Not")
            {
                return connect.DataPreparation(massdata, resultS);
            }
            return null;
        }
    }
}
