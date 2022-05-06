using System.Collections.Generic;
using Xunit;

namespace TestTask.TestServer.TaskGroupsTest
{
    public class TaskGroupsTest
    {
        [Fact]
        public void ExternalTaskGroupsType_searchgroup_()
        {
            Task_Server_.Services.Operations.ExternalOperations.TaskGroups functions = new();
            var result = functions.gettype("searchgroup");
            Assert.Equal("tgroups[]", result);
        }
        [Fact]
        public void ExternalTaskGroupsType_usergroups_()
        {
            Task_Server_.Services.Operations.ExternalOperations.TaskGroups functions = new();
            var result = functions.gettype("usergroups");
            Assert.Equal("tgroups[]", result);
        }
        [Fact]
        public void ExternalTaskGroupsType_getinfogroups_()
        {
            Task_Server_.Services.Operations.ExternalOperations.TaskGroups functions = new();
            var result = functions.gettype("getinfogroups");
            Assert.Equal("tgroups", result);
        }
        [Fact]
        public void ExternalTaskGroupsType_getpost_()
        {
            Task_Server_.Services.Operations.ExternalOperations.TaskGroups functions = new();
            var result = functions.gettype("getpost");
            Assert.Equal("List<tgroups_post>", result);
        }
        [Fact]
        public void ExternalTaskGroupsType_getthematics_()
        {
            Task_Server_.Services.Operations.ExternalOperations.TaskGroups functions = new();
            var result = functions.gettype("getthematics");
            Assert.Equal("tgroups_thematics[]", result);
        }
        [Fact]
        public void ExternalTaskGroupsType_getsubscribers_()
        {
            Task_Server_.Services.Operations.ExternalOperations.TaskGroups functions = new();
            var result = functions.gettype("getsubscribers");
            Assert.Equal("List<members_group>", result);
        }
        [Fact]
        public void ExternalTaskGroupsType_none_()
        {
            Task_Server_.Services.Operations.ExternalOperations.TaskGroups functions = new();
            var result = functions.gettype("none");
            Assert.Equal("Not", result);
        }
        [Fact]
        public void InternalTaskGroupsType_Internal_()
        {
            Task_Server_.Services.Operations.InternalOperations.TaskGroups functions = new();
            List<string> result = new();
            result.Add(functions.gettype("creatinggroup"));
            result.Add(functions.gettype("joingroup"));
            result.Add(functions.gettype("createpost"));
            result.Add(functions.gettype("excludegroup"));
            result.Add(functions.gettype("deletegroup"));
            result.Add(functions.gettype("moderator"));
            int rez = 1;
            foreach (string temp in result)
            {
                if (temp != "bool")
                {
                    rez = 0;
                }
            }
            Assert.Equal(1, rez);
        }
        [Fact]
        public void InternalTaskGroupsType_none_()
        {
            Task_Server_.Services.Operations.InternalOperations.TaskGroups functions = new();
            var result = functions.gettype("none");
            Assert.Equal("Not", result);
        }
        [Fact]
        public void ExternalrunningNull()
        {
            Task_Server_.Services.Operations.ExternalOperations.TaskGroups functions = new();
            var result = functions.running("none", new List<string> { });
            Assert.Null(result);
        }
    }
}
