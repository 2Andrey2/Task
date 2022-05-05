using System.Collections.Generic;
using System.Linq;
using Task_Data_;
using Task_Data_.Entities;
using System;
using Task_Server_.Services.Operations.SystemOperations;

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
                tauthorized key = new ();
                foreach (tusers rez in user)
                {
                    var auth = db.tauthorized.Where(p => p.user == rez.id).ToList();
                    TaskTokens tokens = new();
                    if (auth.Count != 0)
                    {
                        foreach (tauthorized tauthorized in auth)
                        {
                            db.tauthorized.Remove(tauthorized);
                        }
                    }
                    if (info.Count >= 3)
                    {
                        key = tokens.AddUserToken(rez.id, Convert.ToInt32(info[2]));
                    }
                    else
                    {
                        key = tokens.AddUserToken(rez.id);
                    }
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
