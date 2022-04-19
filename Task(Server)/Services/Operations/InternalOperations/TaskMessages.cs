using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Server_.Data.WorkingDatabase.ModelBD;
using Task.Entities;

namespace Task_Server_.Services.Operations.InternalOperations
{
    class TaskMessages: Operations, IOperations
    {
        public object running(string task, object massinfo, List<string> parameters = null)
        {
            switch (task)
            {
                case "sendmessage":
                    return SendMessage((List<string>)massinfo);
            }
            return null;
        }
        public string gettype(string task)
        {
            if (task == "sendmessage")
            {
                return "bool";
            }
            return "Not";
        }
        private bool SendMessage(List<string> massinfo)
        {
            try
            {
                tmessages messages = new tmessages();
                messages.host = Convert.ToInt32(massinfo[0]);
                messages.friend = Convert.ToInt32(massinfo[1]);
                messages.message = massinfo[2];
                messages.personal = 1;
                db.tmessages.AddRange(messages);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
