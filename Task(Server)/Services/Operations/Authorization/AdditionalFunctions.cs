using System;
using System.Collections.Generic;
using System.Linq;
using Task_Data_.Entities;

namespace Task_Server_.Services.Operations.Authorization
{
    class AdditionalFunctions : Operations
    {
        string[] withoutAuthorization = new string[] { "registration", "authorizationuser" };
        
        public bool CheckingRights(string[] info, List<string> task)
        {
            try
            {
                if (!withoutAuthorization.Any(str => str == info[1]))
                {
                    var result = db.tauthorized.Where(p => p.keyuser == Convert.ToInt32(task[3]));
                    foreach (tauthorized rez in result)
                    {
                        return true;
                    }
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

    }
}
