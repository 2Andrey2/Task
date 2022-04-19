using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Client_.Data.Entities;
using Task_Data_.Entities;

namespace Task_Client_.Models.Actions
{
    class ActionsGroups : Actions
    {
        public bool CreatingGroup(List<string> info)
        {
            object resultO = SendingRequest(info, "group creatinggroup internal", "List<string>");
            return resultO is bool ? (bool)resultO : false;
        }

        public tgroups[] SearchGroup(List<string> info)
        {
            object resultO = SendingRequest(info, "group searchgroup external", "List<string>");
            return resultO is tgroups[]? (tgroups[])resultO : null;
        }

        public bool JoinGroup(List<string> info)
        {
            object resultO = SendingRequest(info, "group joingroup internal", "List<string>");
            if (resultO is bool res)
            {
                return res;
            }
            return false;
        }

        public tgroups[] UserGroups(List<string> info)
        {
            object resultO = SendingRequest(info, "group usergroups external", "List<string>");
            if (resultO is tgroups[])
            {
                return (tgroups[])resultO;
            }
            return null;
        }

        public tgroups GetInfoGroups(List<string> info)
        {
            object resultO = SendingRequest(info, "group getinfogroups external", "List<string>");
            if (resultO is tgroups)
            {
                return (tgroups)resultO;
            }
            return null;
        }

        public bool CreatePost(List<string> info)
        {
            object resultO = SendingRequest(info, "group createpost internal", "List<string>");
            if (resultO is bool rez)
            {
                return rez;
            }
            return false;
        }

        public List<tgroups_post> GetPost(List<string> info)
        {
            object resultO = SendingRequest(info, "group getpost external", "List<string>");
            return resultO is List<tgroups_post>? (List<tgroups_post>)resultO : null;
        }
        public tgroups_thematics[] GetThematics()
        {
            object resultO = SendingRequest(new List<string> { "0" }, "group getthematics external", "List<string>");
            return resultO is tgroups_thematics[]? (tgroups_thematics[])resultO : null;
        }
        public List<members_group> GetSubscribers(List<string> info)
        {
            object resultO = SendingRequest(info, "group getsubscribers external", "List<string>");
            if (resultO is List<members_group>)
            {
                return (List<members_group>)resultO;
            }
            return null;
        }

        public bool ExcludeGroup(List<string> info)
        {
            object resultO = SendingRequest(info, "group excludegroup internal", "List<string>");
            if (resultO is bool )
            {
                return (bool)resultO;
            }
            return false;
        }

        public bool Moderator(List<string> info)
        {
            object resultO = SendingRequest(info, "group moderator internal", "List<string>");
            if (resultO is bool)
            {
                return (bool)resultO;
            }
            return false;
        }

        public bool DeleteGroup(List<string> info)
        {
            object resultO = SendingRequest(info, "group deletegroup internal", "List<string>");
            if (resultO is bool)
            {
                return (bool)resultO;
            }
            return false;
        }
    }
}
