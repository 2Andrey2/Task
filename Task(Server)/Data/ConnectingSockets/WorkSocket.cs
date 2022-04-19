using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using Task;
using Task.Entities;
using Task.Media;

namespace Task_Server_.Data.ConnectingSockets
{
    class WorkSocket
    {
        Socket sListener;
        IPEndPoint ipEndPoint;
        Socket handler;
        public WorkSocket()
        {
            // Устанавливаем для сокета локальную конечную точку
            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddr = ipHost.AddressList[0];
            ipEndPoint = new IPEndPoint(ipAddr, 11000);

            // Создаем сокет Tcp/Ip
            sListener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            sListener.Bind(ipEndPoint);
            sListener.Listen(10);
        }

        public object WaitingСonnection(int size, string mode)
        {
            // Назначаем сокет локальной конечной точке и слушаем входящие сокеты
            try
            {
                // Начинаем слушать соединения
                Console.WriteLine("Ожидаем соединение через порт {0}", ipEndPoint);
                // Программа приостанавливается, ожидая входящее соединение
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
                object data = null;
                switch (mode)
                {
                    case "User":
                        data = JsonSerializer.Deserialize<tusers>(bytes);
                        break;
                    case "string[]":
                        data = JsonSerializer.Deserialize<string[]>(bytes);
                        data = (string[])Encryption.EncodeDecryptMass((string[])data);
                        break;
                    case "List<string>":
                        data = JsonSerializer.Deserialize<List<string>>(bytes);
                        break;
                    case "List<tusers_group_chat>":
                        data = JsonSerializer.Deserialize<List<tusers_group_chat>>(bytes);
                        break;
                    case "Image":
                        data = WorkingImages.ImageDecoding(bytes);
                        break;
                }
                Console.WriteLine("Данные типа {0} получены успешно", mode);
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        public void Clouse()
        {
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
        }

        public void Answer(object text)
        {
            byte[] bytes;
            if (text is string[]) { text = Encryption.EncodeDecryptMass((string[])text); }
            bytes = JsonSerializer.SerializeToUtf8Bytes(text);
            if (text is Image) { bytes = WorkingImages.ImageEncoding((Image)text); }
            Console.WriteLine("Отправка результатов выполнения операции");
            handler.Send(bytes);
        }
    }
}
