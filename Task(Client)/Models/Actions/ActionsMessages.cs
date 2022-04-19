using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Client_.Data.Entities;
using Task.Entities;

namespace Task_Client_.Models.Actions
{
    class ActionsMessages: Actions
    {
        public bool SendMessage(List<string> info)
        {
            info.Add(UserNow.key);
            object resultO = SendingRequest(info, "messages sendmessage internal", "List<string>");
            if (resultO is bool)
            {
                return (bool)resultO;
            }
            return false;
        }

        public tmessages[] GetUserMessages(List<string> info)
        {
            info.Add(UserNow.key);
            object resultO = SendingRequest(info, "messages getusermessages external", "List<string>");
            if (resultO is tmessages[])
            {
                return (tmessages[])resultO;
            }
            return new tmessages[0];
        }
    }
}
