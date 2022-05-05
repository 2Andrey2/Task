using System.Net;
using System.Net.Sockets;

namespace Task_Data_.SystemData
{
    public class Ports
    {
        public static int GetPort()
        {
            int portMin = 10000;
            int portMax = 11000;
            int port = portMin;
            IPAddress ipAddress = Dns.GetHostEntry("localhost").AddressList[0];
            while (true)
            {
                try
                {
                    TcpListener tcpListener = new TcpListener(ipAddress, port);
                    tcpListener.Start();
                    tcpListener.Stop();
                    return port;
                }
                catch (SocketException ex)
                {
                    if (port <= portMax)
                    {
                        port++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return 0;
        }
    }
}
