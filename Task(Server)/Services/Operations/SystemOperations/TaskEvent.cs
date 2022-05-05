using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Task_Data_.Entities;
using Task_Server_.Data.ConnectingSockets;

namespace Task_Server_.Services.Operations.SystemOperations
{
    class TaskEvent : Operations
    {
        public void CheckEvents ()
        {
            var events = db.tevent.Where(p => p.result == 0).ToList();
            foreach (tevent eventt in events)
            {
                List<tauthorized> user = db.tauthorized.Where(p => p.user == eventt.user).ToList();
                if (user.Count != 0 && user[0].user_port != 0)
                {
                    WorkSoket soket = new();
                    try {
                        soket.CreateSoketSend(user[0].user_port);
                        soket.Answer(JsonSerializer.SerializeToUtf8Bytes(new List<string> { eventt.type.ToString() }));
                        eventt.result = 1;
                    }
                    catch
                    {
                        Console.WriteLine("Попытка отправить событие не удалась");
                        eventt.result = 2;
                    }
                    db.tevent.Update(eventt);
                    db.SaveChanges();
                }
            }
        }
    }
}
