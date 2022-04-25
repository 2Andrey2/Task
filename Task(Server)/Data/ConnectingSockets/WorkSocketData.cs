using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using Task_Data_;
using Task_Data_.Entities;
using Task_Data_.Media;

namespace Task_Server_.Data.ConnectingSockets
{
    class WorkSocketData: WorkSoket
    {
        public WorkSocketData(int port = 11000)
        {
            CreateSoketAccept(port);
        }

        public object WaitingСonnection(int size, string mode)
        {
            // Назначаем сокет локальной конечной точке и слушаем входящие сокеты
            try
            {
                // Начинаем слушать соединения
                Console.WriteLine("Ожидаем соединение через порт данных {0}", ipEndPoint);
                // Программа приостанавливается, ожидая входящее соединение
                byte[] bytes = GettingResult(size);
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

        public void AnswerObject(object text)
        {
            byte[] bytes;
            if (text is string[]) { text = Encryption.EncodeDecryptMass((string[])text); }
            bytes = JsonSerializer.SerializeToUtf8Bytes(text);
            if (text is Image) { bytes = WorkingImages.ImageEncoding((Image)text); }
            Answer(bytes);
        }
    }
}
