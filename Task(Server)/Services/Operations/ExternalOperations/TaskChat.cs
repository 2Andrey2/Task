using System;
using System.Collections.Generic;
using System.Linq;
using Task_Data_.Entities;

namespace Task_Server_.Services.Operations.ExternalOperations
{
    class TaskChat : Operations, IOperations
    {
        public object running(string task, object massinfo, List<string> parameters = null)
        {
            switch (task)
            {
                case "getinfochat":
                    return GetInfoChat((List<string>)massinfo);
                case "getchatsuser":
                    return GetChatsUser((List<string>)massinfo);
                case "getchatusermessages":
                    return GetChatUserMessages((List<string>)massinfo);
            }
            return null;
        }
        public string gettype(string task)
        {
            if (task == "getinfochat")
            {
                return "tmessages_group_chat";
            }
            if (task == "getchatsuser")
            {
                return "List<tmessages_group_chat>";
            }
            if (task == "getchatusermessages")
            {
                return "List<tmessages>";
            }

            return "Not";
        }

        private tmessages_group_chat GetInfoChat(List<string> massinfo)
        {
            try
            {
                var chat = db.tmessages_group_chat.Where(p => p.name == massinfo[0]).FirstOrDefault();
                if(chat is tmessages_group_chat)
                {
                    return chat;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        private List<tmessages_group_chat> GetChatsUser(List<string> massinfo)
        {
            try
            {
                var user = db.tmessages_group_chat.Join(db.tusers_group_chat,
                    u => u.id,
                    f => f.chat,
                    (u, f) => new
                    {
                        u.id,
                        u.name,
                        f.user,
                        f.chat,
                    }).Where(f => f.user == Convert.ToInt32(massinfo[0])).ToList();
                List<tmessages_group_chat> rezmass = new List<tmessages_group_chat>();
                foreach (var rez in user)
                {
                    rezmass.Add(new tmessages_group_chat() { id = rez.id, name = rez.name });
                }
                return rezmass;
            }
            catch
            {
                return null;
            }
        }

        private List<tmessages> GetChatUserMessages(List<string> massinfo)
        {
            try
            {
                var chat = db.tmessages.Where(p=> p.group_chat == Convert.ToInt32(massinfo[0]) && p.personal == 0 );
                List<tmessages> tmessages = new();
                foreach (tmessages message in chat)
                {
                    tmessages.Add(message);
                }
                return tmessages;
            }
            catch
            {
                return null;
            }
        }
    }
}
