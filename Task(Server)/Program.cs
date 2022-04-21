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
            Task<List<string>> informationpackage = null;
            Task<List<string>> datapackage = null;
            WorkSocketInf workSocket = new();
            informationpackage = new Task<List<string>>(InformationPackage, workSocket);
            informationpackage.Start();
            while (true)
            {
                if (informationpackage != null && informationpackage.Status == TaskStatus.RanToCompletion)
                {
                    datapackage = new Task<List<string>>(DataPackage, informationpackage.Result);
                    informationpackage = new Task<List<string>>(InformationPackage, workSocket);
                    informationpackage.Start();
                    datapackage.Start();
                }
            }
        }

        private static List<string> InformationPackage (object workSocketOBJ)
        {
            WorkSocketInf workSocket =  (WorkSocketInf)workSocketOBJ;
            List<string> rezservis = (List<string>)workSocket.WaitingСonnection(0, "List<string>");
            Console.WriteLine("Получен информационный пакет");
            List<string> answer = AnalysisTask.Analysis(rezservis);
            answer.Add("11001");
            Console.WriteLine("Отправлен информационный пакет " + rezservis[0] + " : " + rezservis[1]);
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
            workSocket.Clouse();
            Console.WriteLine("Отправлен пакет данных" + rez);
            return new List<string> { "OK" };
        }
    }
}
