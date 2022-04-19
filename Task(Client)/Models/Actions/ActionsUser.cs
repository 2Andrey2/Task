using System.Collections.Generic;
using System.Drawing;
using Task_Data_.Entities;
using Task_Client_.Data.Entities;

namespace Task_Client_.Models.Actions
{
    class ActionsUser: Actions
    {
        public bool Registration(tusers user)
        {
            object resultO = SendingRequest(user, "user registration internal", "User");
            if (resultO is bool)
            {
                return (bool)resultO;
            }
            return false;
        }

        public string Authorization(List<string> info)
        {
            object resultO = SendingRequest(info, "authorization authorizationuser", "List<string>");
            if (resultO is string)
            {
                if ((string)resultO != "0")
                {
                    UserNow.key = (string)resultO;
                    info.Add(UserNow.key);
                    GetUser(info);
                    UserNow.Friends = GetFroendsUser(new List<string> { UserNow.Authorized.id.ToString() });
                }
                return (string)resultO;
            }
            return "0";
        }

        public bool GetUser(List<string> info)
        {
            info.Add(UserNow.key);
            object resultO = SendingRequest(info, "user getuser external", "List<string>");
            if (resultO is tusers)
            {
                UserNow.Authorized = (tusers)resultO;
                return true;
            }
            return false;
        }


        public tusers[] SearchUser(List<string> info)
        {
            info.Add(UserNow.key);
            object resultO = SendingRequest(info, "user searchuser external", "List<string>");
            if (resultO is tusers[])
            {
                return (tusers[])resultO;
            }
            return new tusers[0];
        }

        public bool AddFriend(List<string> info)
        {
            info.Add(UserNow.key);
            object resultO = SendingRequest(info, "user addfriend internal", "List<string>");
            if (resultO is bool)
            {
                return (bool)resultO;
            }
            return false;
        }


        public friends[] GetFroendsUser(List<string> info)
        {
            object resultO = SendingRequest(info, "user getfroendsUser external", "List<string>");
            if (resultO is friends[])
            {
                return (friends[])resultO;
            }
            return new friends[0];
        }

        public bool UploadingImage (Image info)
        {
            object resultO = SendingRequest(info, "user uploadingimage internal " + UserNow.Authorized.id, "Image");
            if (resultO is bool)
            {
                return (bool)resultO;
            }
            return false;
        }

        public Image GetAvatar(List<string> info)
        {
            object resultO = SendingRequest(info, "user getavatar external", "List<string>");
            if (resultO is Image)
            {
                return (Image)resultO;
            }
            return null;
        }

    }
}
