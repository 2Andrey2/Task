using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Client_.Data.Entities;
using Task.Entities;

namespace Task_Client_.Models.Actions
{
    class ActionsChats : Actions
    {
        public bool CreateChat(List<string> info)
        {
            object resultO = SendingRequest(info, "chat createchat internal", "List<string>");
            if (resultO is bool rez)
            {
                return rez;
            }
            return false;
        }

        public tmessages_group_chat GetInfoChat(List<string> info)
        {
            object resultO = SendingRequest(info, "chat getinfochat external", "List<string>");
            if (resultO is tmessages_group_chat rez)
            {
                return rez;
            }
            return null;
        }

        public bool AddChatParticipant(List<tusers_group_chat> info)
        {
            object resultO = SendingRequest(info, "chat addchatparticipant internal", "List<tusers_group_chat>");
            if (resultO is bool rez)
            {
                return rez;
            }
            return false;
        }

        public bool SendMessage(List<string> info)
        {
            object resultO = SendingRequest(info, "chat sendmessage internal", "List<string>");
            if (resultO is bool rez)
            {
                return rez;
            }
            return false;
        }

        public List<tmessages_group_chat> GetChatsUser(List<string> info)
        {
            object resultO = SendingRequest(info, "chat getchatsuser external", "List<string>");
            if (resultO is List<tmessages_group_chat> rez)
            {
                return rez;
            }
            return null;
        }
        public List<tmessages> GetChatUserMessages(List<string> info)
        {
            object resultO = SendingRequest(info, "chat getchatusermessages external", "List<string>");
            if (resultO is List<tmessages> rez)
            {
                return rez;
            }
            return null;
        }
    }
}
