using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Server_.Data.WorkingDatabase.ModelBD;
using Task_Data_.Entities;

namespace Task_Server_.Services.Operations.ExternalOperations
{
    class TaskMessages: Operations, IOperations
    {
        public object running(string task, object massinfo, List<string> parameters = null)
        {
            switch (task)
            {
                case "getusermessages":
                    return GetUserMessages((List<string>)massinfo);
            }
            return null;
        }

        public string gettype(string task)
        {
            switch (task)
            {
                case "getusermessages":
                    return "tmessages[]";
            }
            return "Not";
        }
        private tmessages[] GetUserMessages(List<string> massinfo)
        {
            try
            {
                var messages = db.tmessages.FromSqlRaw("SELECT * FROM `tmessages` WHERE (`host` = {0} || `host` = {1} ) && (`friend` = {0} || `friend` = {1}) && `personal` = 1", Convert.ToInt32(massinfo[0]), Convert.ToInt32(massinfo[1]));
                tmessages[] rezmass = new tmessages[messages.Count()];
                int i = 0;
                foreach (tmessages rez in messages)
                {
                    rezmass[i] = rez;
                    i++;
                }
                return rezmass;
            }
            catch
            {
                return null;
            }
        }
    }
}
