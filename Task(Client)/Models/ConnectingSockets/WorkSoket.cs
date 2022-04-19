using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using Task_Client_.Data.Entities;
using Task_Data_;
using Task_Data_.Entities;
using Task_Data_.Media;

namespace Task_Client_.Models.ConnectingSockets
{
    class WorkSoket
    {
        IPEndPoint ipEndPoint;
        IPHostEntry ipHost;
        IPAddress ipAddr;
        Socket sendermy;
        public WorkSoket()
        {
            
        }

        public object DataPreparation(byte[] datamass, List<string> type)
        {
            byte[] rezmass;
            if (type.Count == 2)
            {
                rezmass = SendingData(datamass, Convert.ToInt32(type[1]));
            }
            else
            {
                rezmass = SendingData(datamass);
            }
            if (rezmass == null) { return null; }
            object rezobject = null;
            switch (type[0])
            {
                case "string":
                    rezobject = JsonSerializer.Deserialize<string>(rezmass);
                    break;
                case "string[]":
                    rezobject = JsonSerializer.Deserialize<string[]>(rezmass);
                    rezobject = Encryption.EncodeDecryptMass((string[])rezobject);
                    break;
                case "tusers":
                    rezobject = JsonSerializer.Deserialize<tusers>(rezmass);
                    break;
                case "tusers[]":
                    rezobject = JsonSerializer.Deserialize<tusers[]>(rezmass);
                    break;
                case "friends[]":
                    rezobject = JsonSerializer.Deserialize<friends[]>(rezmass);
                    break;
                case "tmessages[]":
                    rezobject = JsonSerializer.Deserialize<tmessages[]>(rezmass);
                    break;
                case "tgroups[]":
                    rezobject = JsonSerializer.Deserialize<tgroups[]>(rezmass);
                    break;
                case "tgroups":
                    rezobject = JsonSerializer.Deserialize<tgroups>(rezmass);
                    break;
                case "tgroups_post[]":
                    rezobject = JsonSerializer.Deserialize<tgroups_post[]>(rezmass);
                    break;
                case "tgroups_thematics[]":
                    rezobject = JsonSerializer.Deserialize<tgroups_thematics[]>(rezmass);
                    break;
                case "members_group[]":
                    rezobject = JsonSerializer.Deserialize<members_group[]>(rezmass);
                    break;
                case "tmessages_group_chat":
                    rezobject = JsonSerializer.Deserialize<tmessages_group_chat>(rezmass);
                    break;
                case "List<string>":
                    rezobject = JsonSerializer.Deserialize<List<string>>(rezmass);
                    break;
                case "List<tmessages_group_chat>":
                    rezobject = JsonSerializer.Deserialize<List<tmessages_group_chat>>(rezmass);
                    break;
                case "List<tmessages>":
                    rezobject = JsonSerializer.Deserialize<List<tmessages>>(rezmass);
                    break;
                case "List<members_group>":
                    rezobject = JsonSerializer.Deserialize<List<members_group>>(rezmass);
                    break;
                case "List<tgroups_post>":
                    rezobject = JsonSerializer.Deserialize<List<tgroups_post>>(rezmass);
                    break;
                case "Image":
                    rezobject = WorkingImages.ImageDecoding(rezmass);
                    break;
                default:
                    rezobject = JsonSerializer.Deserialize<bool>(rezmass);
                    break;
            }

            return rezobject;
        }
        public byte[] SendingData (byte[] bytes, int port = 11000)
        {
            try
            {
                ipHost = Dns.GetHostEntry("localhost");
                ipAddr = ipHost.AddressList[0];
                ipEndPoint = new IPEndPoint(ipAddr, port);
                sendermy = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                sendermy.Connect(ipEndPoint);
                int bytesSent = sendermy.Send(bytes);

                // Ждем ответ
                int temp = sendermy.Available;
                while (true)
                {
                    if (sendermy.Available == temp && sendermy.Available != 0) { break; }
                    temp = sendermy.Available;
                }
                byte[] bytesrez = new byte[sendermy.Available];
                sendermy.Receive(bytesrez);
                sendermy.Shutdown(SocketShutdown.Both);
                sendermy.Close();

                return bytesrez;
            }
            catch
            {
                return null;
            }
        }
    }
}
