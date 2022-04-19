using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using Task_Server_.Data.WorkingDatabase;
using MySqlConnector;
using Task_Server_.Data.ConnectingSockets;
using Task_Server_.Services;
using System.Collections.Generic;

namespace Task_Server_
{
    class Program
    {
        static void Main(string[] args)
        {
            AnalysisTask analysis = new ();
            WorkSocket workSocket = new ();
            while (true)
            {
                List<string> rezservis = (List<string>)workSocket.WaitingСonnection(0,"List<string>");
                if (rezservis != null)
                {
                    Console.WriteLine("Получен информационный пакет");
                    workSocket.Answer(analysis.Analysis(rezservis));
                    object rez = workSocket.WaitingСonnection(Convert.ToInt32(rezservis[1]), rezservis[2]);
                    Console.WriteLine("Получен пакет данных");
                    workSocket.Answer(analysis.CompletingTask(rezservis[0], rez));
                    Console.WriteLine("Сеанс завершен");
                    Console.WriteLine("--------------");
                }
                else
                {
                    workSocket.Answer(new string[] { "Данные не доставлены" });
                }
            }
            workSocket.Clouse();
        }
    }
}
