using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading.Tasks;
using Task_Client_.Data.Entities;

namespace Task_Client_.Data
{
    static class Events
    {
        public static event Action<List<string>> OnSendServer;   

        public static Task events = new Task(RunObservationEvents);

        private static void RunObservationEvents ()
        {
            Socket sListener;
            IPEndPoint ipEndPoint;
            Socket handler;
            // Устанавливаем для сокета локальную конечную точку
            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddr = ipHost.AddressList[0];
            ipEndPoint = new IPEndPoint(ipAddr, Convert.ToInt32(UserNow.listen_port));

            // Создаем сокет Tcp/Ip
            sListener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            sListener.Bind(ipEndPoint);
            sListener.Listen(10);

            while (true)
            {
                handler = sListener.Accept();

                byte[] bytes;
                bytes = new byte[handler.Available];
                handler.Receive(bytes);

                List<string> rez = JsonSerializer.Deserialize<List<string>>(bytes);
                switch (rez[0])
                {
                    case "TokenUpdate":
                        UserNow.key = rez[1];
                        handler.Send(JsonSerializer.SerializeToUtf8Bytes(new List<string> { "1" }));
                        break;
                    default:
                        OnSendServer?.Invoke(rez);
                        break;
                }
            }
        }
    }
}
