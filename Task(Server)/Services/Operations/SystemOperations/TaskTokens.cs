using System;
using System.Collections.Generic;
using System.Text.Json;
using Task_Data_.Entities;
using Task_Server_.Data.ConnectingSockets;

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
                    if (keys.user_port != 0)
                    {
                        WorkSoket soket = new();
                        try
                        {
                            soket.CreateSoketSend(keys.user_port);
                            int token = KeyGeneration();
                            soket.Answer(JsonSerializer.SerializeToUtf8Bytes(new List<string> { "TokenUpdate", token.ToString() }));
                            List<string> answer = JsonSerializer.Deserialize<List<string>>(soket.GettingResult());
                            if (answer[0] == "1")
                            {
                                keys.keyuser = token;
                                db.tauthorized.Update(keys);
                            }
                            else
                            {
                                db.tauthorized.Remove(keys);
                            }
                        } catch {
                            db.tauthorized.Remove(keys);
                        }
                    }
                    else
                    {
                        db.tauthorized.Remove(keys);
                    }
                }
            }
            db.SaveChanges();
        }

        public tauthorized AddUserToken (int id, int port = 0 )
        {
            tauthorized key = new();
            key.user = id;
            key.keyuser = KeyGeneration();
            key.date = DateTimeOffset.Now.ToUnixTimeSeconds();
            if (port != 0)
            {
                key.user_port = port;
            }
            return key;
        }

        private int KeyGeneration()
        {
            Random random = new();
            return random.Next(1000, 100000);
        }
    }
}
