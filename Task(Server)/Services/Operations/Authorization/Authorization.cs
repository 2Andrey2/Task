using System.Collections.Generic;
using System.Linq;
using Task;
using Task_Server_.Data.WorkingDatabase.ModelBD;
using Task.Entities;

namespace Task_Server_.Services.Operations.Authorization
{
    class Authorization: AdditionalFunctions, IOperations
    {
        public object running(string task, object massinfo, List<string> parameters = null)
        {
            switch (task)
            {
                case "authorizationuser":
                    return AuthorizationUser((List<string>)massinfo);
            }
            return null;
        }
        public string gettype(string task)
        {
            switch (task)
            {
                case "authorizationuser":
                    return "string";
            }
            return "Not";
        }
        public string AuthorizationUser(List<string> info)
        {
            try
            {
                var user = db.tusers.Where(p => p.login == Encryption.EncodeDecryptString(info[0]) && p.password == Encryption.EncodeDecryptString(info[1])).ToList();
                tauthorized key = new tauthorized();
                foreach (tusers rez in user)
                {
                    key.user = rez.id;
                    key.keyuser = KeyGeneration();
                    db.tauthorized.AddRange(key);
                    db.SaveChanges();
                }
                return key.keyuser.ToString();
            }
            catch
            {
                return "0";
            }
        }
    }
}
