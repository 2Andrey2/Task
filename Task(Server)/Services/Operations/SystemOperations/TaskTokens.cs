using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Data_.Entities;

namespace Task_Server_.Services.Operations.SystemOperations
{
    class TaskTokens : Operations
    {
        public void TokenVerification ()
        {
            foreach (tauthorized keys in db.tauthorized)
            {
                if (keys.date + 1800 < DateTimeOffset.Now.ToUnixTimeSeconds())
                {
                    db.tauthorized.Remove(keys);
                }
            }
            db.SaveChanges();
        }
    }
}
