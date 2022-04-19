using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Server_.Data.ConnectingSockets;
using Task_Server_.Services;

namespace Task_Server_
{
    class Program
    {
        static void Main(string[] args)
        {
            Task packetprocessing = new Task(PacketProcessing);
            packetprocessing.Start();
            packetprocessing.Wait();
        }

        private static void PacketProcessing ()
        {
            Task<List<string>> informationpackage = new Task<List<string>>(InformationPackage);
            informationpackage.Start();
            while (true)
            {
                if (informationpackage.Status == TaskStatus.RanToCompletion)
                {
                    Task<List<string>> datapackage = new Task<List<string>>(DataPackage, informationpackage.Result);
                    informationpackage = new Task<List<string>>(InformationPackage);
                    informationpackage.Start();
                    datapackage.Start();
                    Console.WriteLine("Сеанс завершен");
                    Console.WriteLine("--------------");
                }
            }
        }

        private static List<string> InformationPackage ()
        {
            WorkSocketInf workSocket = new();
            List<string> rezservis = (List<string>)workSocket.WaitingСonnection(0, "List<string>");
            Console.WriteLine("Получен информационный пакет");
            List<string> answer = AnalysisTask.Analysis(rezservis);
            answer.Add("11001");
            workSocket.AnswerObject(answer);
            return rezservis;
        }

        private static List<string> DataPackage(object rezservisOBJ)
        {
            List<string> rezservis = (List<string>)rezservisOBJ;
            WorkSocketData workSocket = new(11001);
            object rez = workSocket.WaitingСonnection(Convert.ToInt32(rezservis[1]), rezservis[2]);
            Console.WriteLine("Получен пакет данных");
            workSocket.AnswerObject(AnalysisTask.CompletingTask(rezservis[0], rez));
            return new List<string> { "OK" };
        }
    }
}
