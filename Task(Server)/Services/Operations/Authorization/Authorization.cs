﻿using System.Collections.Generic;
using System.Linq;
using Task_Data_;
using Task_Data_.Entities;
using System;

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
                    key.user = rez.id;
                    key.keyuser = KeyGeneration();
                    key.date = DateTimeOffset.Now.ToUnixTimeSeconds();
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
