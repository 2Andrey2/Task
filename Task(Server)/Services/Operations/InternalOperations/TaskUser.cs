using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Task_Data_;
using Task_Data_.Entities;
using Task_Data_.Media;

namespace Task_Server_.Services.Operations.InternalOperations
{
    class TaskUser: Operations, IOperations
    {
        public object running(string task, object massinfo, List<string> parameters = null)
        {
            switch (task)
            {
                case "registration":
                    return Registration((tusers)massinfo);
                case "addfriend":
                    return AddFriend((List<string>)massinfo);
                case "uploadingimage":
                    return UploadingImage((Bitmap)massinfo, parameters);
            }
            return null;
        }
        public string gettype(string task)
        {
            if(task == "registration" || task == "addfriend" || task == "uploadingimage")
            {
                return "bool";
            }
            return "Not";
        }
        public bool AddFriend(List<string> massinfo)
        {
            try
            {
                if (db.tfriends.Where(p => p.friend == Convert.ToInt32(massinfo[0]) && p.host == Convert.ToInt32(massinfo[1])).Count() == 0)
                {
                    tfriends friends = new tfriends();
                    friends.friend = Convert.ToInt32(massinfo[0]);
                    friends.host = Convert.ToInt32(massinfo[1]);
                    friends.status = Convert.ToInt32(massinfo[2]);
                    db.tfriends.AddRange(friends);
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

        public bool Registration(tusers massinfo)
        {
            try
            {
                if (db.tusers.Where(p => p.login == Encryption.EncodeDecryptString(massinfo.login)).Count() == 0)
                {
                    massinfo.login = Encryption.EncodeDecryptString(massinfo.login);
                    massinfo.password = Encryption.EncodeDecryptString(massinfo.password);
                    massinfo.surname = massinfo.surname;
                    massinfo.name = massinfo.name;
                    massinfo.middle_name = massinfo.middle_name;
                    massinfo.position = massinfo.position;
                    db.tusers.AddRange(massinfo);
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

        public bool UploadingImage(Image massinfo, List<string> parameters)
        {
            try
            {
                if (Media.CheckingUsersFolder(parameters[0]))
                {
                    if (massinfo != null)
                    {
                        massinfo.Save("users/" + parameters[0] + "/avatar.png", System.Drawing.Imaging.ImageFormat.Png);
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
