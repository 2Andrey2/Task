using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Task_Data_;
using Task_Data_.Entities;
using Task_Data_.Media;

namespace Task_Server_.Services.Operations.ExternalOperations
{
    public class TaskUser: Operations, IOperations
    {
        public object running(string task, object massinfo, List<string> parameters = null)
        {
            switch (task)
            {
                case "getuser":
                    return GetUser((List<string>)massinfo);
                case "searchuser":
                    return Search((List<string>)massinfo);
                case "getfroendsUser":
                    return GetFrirndsUser((List<string>)massinfo);
                case "getavatar":
                    return GetAvatar((List<string>)massinfo);
            }
            return null;
        }

        public string gettype(string task)
        {
            switch (task)
            {
                case "getuser":
                    return "tusers";
                case "searchuser":
                    return "tusers[]";
                case "getfroendsUser":
                    return "friends[]";
                case "getavatar":
                    return "Image";
            }
            return "Not";
        }
        public tusers GetUser(List<string> massinfo)
        {
            try
            {
                IQueryable<tusers> user = null;
                if (massinfo.Count >= 2)
                {
                    user = db.tusers.Where(p => p.id == Convert.ToInt32(Encryption.EncodeDecryptString(massinfo[0])));
                }
                if (massinfo.Count >= 3)
                {
                    user = db.tusers.Where(p => p.login == Encryption.EncodeDecryptString(massinfo[0]) && p.password == Encryption.EncodeDecryptString(massinfo[1]));
                }
                foreach (tusers rez in user)
                {
                    return rez;
                }
                return new tusers();
            }
            catch
            {
                return null;
            }
        }
        public tusers[] Search(List<string> massinfo)
        {
            try
            {
                var user = db.tusers.Where(p => EF.Functions.Like(p.login, "%"+ Encryption.EncodeDecryptString(massinfo[0]) + "%") || EF.Functions.Like(p.surname, "%" + Encryption.EncodeDecryptString(massinfo[0]) + "%") || EF.Functions.Like(p.name, "%" + Encryption.EncodeDecryptString(massinfo[0]) + "%") || EF.Functions.Like(p.middle_name, "%" + Encryption.EncodeDecryptString(massinfo[0]) + "%"));
                tusers[] rezmass = new tusers[user.Count()];
                int i = 0;
                foreach (tusers rez in user)
                {
                    rezmass[i] = rez;
                    i++;
                }
                return rezmass;
            }
            catch
            {
                return null;
            }
        }
        private friends[] GetFrirndsUser(List<string> id)
        {
            try
            {
                var user = db.tfriends.Join(db.tusers,
                    u => u.friend,
                    f => f.id,
                    (u, f) => new
                    {
                        f.id,
                        f.surname,
                        f.name,
                        f.login,
                        u.status,
                        u.host
                    }).Where(f => f.host == Convert.ToInt32(id[0]));
                friends[] rezmass = new friends[user.Count()];
                int i = 0;
                foreach (var rez in user)
                {
                    rezmass[i] = new friends();
                    rezmass[i].id = rez.id;
                    rezmass[i].login = rez.login;
                    rezmass[i].surname = rez.surname;
                    rezmass[i].name = rez.name;
                    rezmass[i].status = rez.status.ToString();
                    i++;
                }
                return rezmass;
            }
            catch
            {
                return null;
            }
        }

        public Image GetAvatar(List<string> massinfo)
        {
            try
            {
                if (Media.CheckingUsersAvatar(massinfo[0]))
                {
                    Image image = Image.FromFile(Media.PathFolderUser + "/" + massinfo[0] + "/" + Media.NameAvatar);
                    return image;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
