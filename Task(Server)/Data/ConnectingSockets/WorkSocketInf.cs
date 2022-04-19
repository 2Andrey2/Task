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
    class WorkSocketInf: WorkSoket
    {
        public WorkSocketInf(int port = 11000)
        {
            CreateSoket(port);
        }
        public object WaitingСonnection(int size, string mode)
        {
            // Назначаем сокет локальной конечной точке и слушаем входящие сокеты
            try
            {
                // Начинаем слушать соединения
                Console.WriteLine("Ожидаем соединение через порт {0}", ipEndPoint);
                // Программа приостанавливается, ожидая входящее соединение
                byte[] bytes = GettingResult(size);
                object data = null;
                switch (mode)
                {
                    case "List<string>":
                        data = JsonSerializer.Deserialize<List<string>>(bytes);
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
            Answer(bytes);
        }
    }
}
