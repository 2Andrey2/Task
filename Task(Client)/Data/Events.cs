using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading.Tasks;

namespace Task_Client_.Data
{
    static class Events
    {
        public static event Action<List<string>> OnSendServer;   

        public static Task events = new Task(RunObservationEvents, 10000);

        private static void RunObservationEvents (object port)
        {
            Socket sListener;
            IPEndPoint ipEndPoint;
            Socket handler;
            // Устанавливаем для сокета локальную конечную точку
            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddr = ipHost.AddressList[0];
            ipEndPoint = new IPEndPoint(ipAddr, Convert.ToInt32(port));

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

                OnSendServer?.Invoke(rez);
            }
        }
    }
}
