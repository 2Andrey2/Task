using System;
using System.Collections.Generic;
using System.Linq;
using Task_Data_.Entities;

namespace Task_Server_.Services.Operations.InternalOperations
{
    public class TaskChat : Operations, IOperations
    {
        public object running(string task, object massinfo, List<string> parameters = null)
        {
            switch (task)
            {
                case "createchat":
                    return CreateChat((List<string>)massinfo);
                case "sendmessage":
                    return SendMessage((List<string>)massinfo);
                case "addchatparticipant":
                    return AddChatParticipant((List<tusers_group_chat>)massinfo);
            }
            return null;
        }
        public string gettype(string task)
        {
            if (task == "createchat" || task == "addchatparticipant" || task == "sendmessage")
            {
                return "bool";
            }
            return "Not";
        }

        private bool CreateChat(List<string> massinfo)
        {
            try
            {
                if (db.tmessages_group_chat.Where(p => p.name == massinfo[0]).Count() == 0)
                {
                    tmessages_group_chat chat = new tmessages_group_chat();
                    chat.name = massinfo[0];
                    db.tmessages_group_chat.AddRange(chat);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        private bool AddChatParticipant(List<tusers_group_chat> massinfo)
        {
            try
            {
                foreach (tusers_group_chat users in massinfo)
                {
                    if (db.tusers_group_chat.Where(p => p.chat == users.chat && p.user == users.user).Count() == 0)
                    {
                        db.tusers_group_chat.AddRange(users);
                    }
                }
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool SendMessage(List<string> massinfo)
        {
            try
            {
                tmessages messages = new tmessages();
                messages.host = Convert.ToInt32(massinfo[0]);
                messages.friend = Convert.ToInt32(massinfo[0]);
                messages.group_chat = Convert.ToInt32(massinfo[1]);
                messages.message = massinfo[2];
                messages.personal = 0;
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
