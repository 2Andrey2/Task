using System;
using System.Collections.Generic;
using System.Linq;
using Task_Data_.Entities;

namespace Task_Server_.Services.Operations.InternalOperations
{
    class TaskGroups : Operations, IOperations
    {
        public object running(string task, object massinfo, List<string> parameters = null)
        {
            switch (task)
            {
                case "creatinggroup":
                    return CreatingGroup((List<string>)massinfo);
                case "joingroup":
                    return JoinGroup((List<string>)massinfo);
                case "createpost":
                    return CreatePost((List<string>)massinfo);
                case "excludegroup":
                    return ExcludeGroup((List<string>)massinfo);
                case "deletegroup":
                    return DeleteGroup((List<string>)massinfo);
                case "moderator":
                    return Moderator((List<string>)massinfo);
            }
            return null;
        }
        public string gettype(string task)
        {
            if (task == "creatinggroup" || task == "joingroup" || task == "createpost" || task == "excludegroup" || task == "deletegroup" || task == "moderator")
            {
                return "bool";
            }
            return "Not";
        }

        private bool CreatingGroup(List<string> massinfo)
        {
            try
            {
                if (db.tgroups.Where(p => p.name == massinfo[0]).Count() == 0)
                {
                    tgroups group = new tgroups();
                    group.name = massinfo[0];
                    group.thematics = Convert.ToInt32(massinfo[1]);
                    group.website = massinfo[2];
                    group.type = Convert.ToInt32(massinfo[3]);
                    db.tgroups.AddRange(group);
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

        private bool JoinGroup(List<string> massinfo)
        {
            try
            {
                if (db.tgroups_members.Where(p=>p.group == Convert.ToInt32(massinfo[0]) && p.user == Convert.ToInt32(massinfo[1])).Count() == 0)
                {
                    tgroups_members members = new tgroups_members();
                    members.group = Convert.ToInt32(massinfo[0]);
                    members.user = Convert.ToInt32(massinfo[1]);
                    members.status = Convert.ToInt32(massinfo[2]);
                    members.block = Convert.ToInt32(massinfo[3]);
                    members.date = Convert.ToInt32(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
                    db.tgroups_members.AddRange(members);
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

        private bool CreatePost(List<string> massinfo)
        {
            try
            {
                tgroups_post post = new tgroups_post();
                post.title = massinfo[0];
                post.text = massinfo[1];
                post.teg = massinfo[2];
                post.group = Convert.ToInt32(massinfo[3]);
                post.user = Convert.ToInt32(massinfo[4]);
                post.date = Convert.ToInt32(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
                db.tgroups_post.AddRange(post);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool ExcludeGroup(List<string> massinfo)
        {
            try
            {
                var user = db.tgroups_members.Where(p => p.group == Convert.ToInt32(massinfo[0]) && p.user == Convert.ToInt32(massinfo[1])).FirstOrDefault();
                db.tgroups_members.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool DeleteGroup(List<string> massinfo)
        {
            try
            {
                var group = db.tgroups.Where(p => p.id == Convert.ToInt32(massinfo[0])).FirstOrDefault();
                db.tgroups.Remove(group);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool Moderator(List<string> massinfo)
        {
            try
            {
                var user = db.tgroups_members.Where(p => p.group == Convert.ToInt32(massinfo[0]) && p.user == Convert.ToInt32(massinfo[1])).FirstOrDefault();
                user.status = 2;
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
