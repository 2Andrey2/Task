using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Task_Data_.Entities;

namespace Task_Server_.Services.Operations.ExternalOperations
{
    public class TaskGroups : Operations, IOperations
    {
        public object running(string task, object massinfo, List<string> parameters = null)
        {
            switch (task)
            {
                case "searchgroup":
                    return SearchGroup((List<string>)massinfo);
                case "usergroups":
                    return UserGroups((List<string>)massinfo);
                case "getinfogroups":
                    return GetInfoGroups((List<string>)massinfo);
                case "getpost":
                    return GetPost((List<string>)massinfo);
                case "getthematics":
                    return GetThematics();
                case "getsubscribers":
                    return GetSubscribers((List<string>)massinfo);
            }
            return null;
        }
        public string gettype(string task)
        {
            if (task == "searchgroup" || task == "usergroups")
            {
                return "tgroups[]";
            }
            if (task == "getinfogroups")
            {
                return "tgroups";
            }
            if (task == "getpost")
            {
                return "List<tgroups_post>";
            }
            if (task == "getthematics")
            {
                return "tgroups_thematics[]";
            }
            if (task == "getsubscribers")
            {
                return "List<members_group>";
            }
            return "Not";
        }

        private tgroups[] SearchGroup(List<string> massinfo)
        {
            try
            {
                var user = db.tgroups.Where(p => p.name == massinfo[0]);
                tgroups[] rezmass = new tgroups[user.Count()];
                int i = 0;
                foreach (tgroups rez in user)
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

        private tgroups[] UserGroups(List<string> massinfo)
        {
            try
            {
                var groups = db.tgroups.FromSqlRaw("SELECT `tgroups`.* FROM `tgroups_members` LEFT JOIN `tgroups` ON `tgroups_members`.`group` = `tgroups`.`id` WHERE `tgroups_members`.`user` = {0}", Convert.ToInt32(massinfo[0]));
                tgroups[] rezmass = new tgroups[groups.Count()];
                int i = 0;
                foreach (tgroups rez in groups)
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

        private tgroups GetInfoGroups(List<string> massinfo)
        {
            try
            {
                var groups = db.tgroups.FromSqlRaw("SELECT * FROM `tgroups` WHERE `id` = {0}", Convert.ToInt32(massinfo[0]));
                tgroups rezmass = new tgroups();
                foreach (tgroups rez in groups)
                {
                    rezmass = rez;
                }
                return rezmass;
            }
            catch
            {
                return null;
            }
        }

        private List<tgroups_post> GetPost(List<string> massinfo)
        {
            try
            {
                var posts = db.tgroups_post.FromSqlRaw("SELECT * FROM `tgroups_post` WHERE `group` = {0} ORDER BY `date` LIMIT {1}", Convert.ToInt32(massinfo[0]), Convert.ToInt32(massinfo[1]));
                List<tgroups_post> rezmass = new ();
                foreach (tgroups_post rez in posts)
                {
                    rezmass.Add(rez);
                }
                return rezmass;
            }
            catch
            {
                return null;
            }
        }

        private tgroups_thematics[] GetThematics()
        {
            try
            {
                var posts = db.tgroups_thematics.FromSqlRaw("SELECT * FROM `tgroups_thematics`");
                tgroups_thematics[] rezmass = new tgroups_thematics[posts.Count()];
                int i = 0;
                foreach (tgroups_thematics rez in posts)
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

        private List<members_group> GetSubscribers(List<string> massinfo)
        {
                var subscribers = db.members_group.FromSqlRaw("SELECT `tusers`.`id`, `tusers`.`surname`, `tusers`.`name`, `tusers`.`middle_name`, `tgroups_members_status`.`name` as `status`, `tgroups_members`.`status` as `status_id` ,`tgroups_members`.block, `tgroups_members`.date  FROM `tusers` LEFT JOIN `tgroups_members` ON `tusers`.`id` = `tgroups_members`.`user` LEFT JOIN `tgroups_members_status` ON `tgroups_members_status`.`id` = `tgroups_members`.`status` WHERE `tgroups_members`.`group` = {0}", massinfo[0]);
                List<members_group> rezmass = new ();
                foreach (members_group rez in subscribers)
                {
                    rezmass.Add(rez);
                }
                return rezmass;
        }
    }
}
