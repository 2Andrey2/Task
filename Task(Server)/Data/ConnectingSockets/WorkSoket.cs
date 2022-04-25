using System.Net;
using System.Net.Sockets;

namespace Task_Server_.Data.ConnectingSockets
{
    class WorkSoket
    {
        protected Socket sListener;
        protected IPEndPoint ipEndPoint;
        protected Socket handler;

        protected IPHostEntry ipHost;
        protected IPAddress ipAddr;

        public void CreateSoketAccept(int port)
        {
            // Устанавливаем для сокета локальную конечную точку
            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddr = ipHost.AddressList[0];
            ipEndPoint = new IPEndPoint(ipAddr, port);

            // Создаем сокет Tcp/Ip
            sListener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            sListener.Bind(ipEndPoint);
            sListener.Listen(10);
        }

        public void CreateSoketSend(int port)
        {
            ipHost = Dns.GetHostEntry("localhost");
            ipAddr = ipHost.AddressList[0];
            ipEndPoint = new IPEndPoint(ipAddr, port);
            handler = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            handler.Connect(ipEndPoint);
        }

        public void Clouse()
        {
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
            sListener.Close();
        }

        protected byte[] GettingResult (int size = 0)
        {
            handler = sListener.Accept();
            byte[] bytes;
            if (size == 0)
            {
                bytes = new byte[handler.Available];
                handler.Receive(bytes);
            }
            else
            {
                bytes = new byte[size];
                while (true)
                {
                    if (handler.Available != 0)
                    {
                        handler.Receive(bytes);
                    }
                    if (bytes.Length == size)
                    {
                        break;
                    }
                }
            }
            return bytes;
        }

        public void Answer(byte[] bytes)
        {
            handler.Send(bytes);
        }
    }
}
