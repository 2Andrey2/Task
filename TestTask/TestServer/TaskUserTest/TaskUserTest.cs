using System.Collections.Generic;
using Xunit;

namespace TestTask.TestServer.TaskUserTest
{
    public class TaskUserTest
    {
        [Fact]
        public void ExternalTaskUserType_getuser_()
        {
            Task_Server_.Services.Operations.ExternalOperations.TaskUser functions = new();
            var result = functions.gettype("getuser");
            Assert.Equal("tusers", result);
        }
        [Fact]
        public void ExternalTaskUserType_searchuser_()
        {
            Task_Server_.Services.Operations.ExternalOperations.TaskUser functions = new();
            var result = functions.gettype("searchuser");
            Assert.Equal("tusers[]", result);
        }
        [Fact]
        public void ExternalTaskUserType_getfroendsUser_()
        {
            Task_Server_.Services.Operations.ExternalOperations.TaskUser functions = new();
            var result = functions.gettype("getfroendsUser");
            Assert.Equal("friends[]", result);
        }
        [Fact]
        public void ExternalTaskUserType_getavatar_()
        {
            Task_Server_.Services.Operations.ExternalOperations.TaskUser functions = new();
            var result = functions.gettype("getavatar");
            Assert.Equal("Image", result);
        }
        [Fact]
        public void InternalTaskUserType_Internal_()
        {
            Task_Server_.Services.Operations.InternalOperations.TaskUser functions = new();
            List<string> result = new();
            result.Add(functions.gettype("registration"));
            result.Add(functions.gettype("addfriend"));
            result.Add(functions.gettype("uploadingimage"));
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
        public void InternalTaskUserType_none_()
        {
            Task_Server_.Services.Operations.InternalOperations.TaskUser functions = new();
            var result = functions.gettype("none");
            Assert.Equal("Not", result);
        }
        [Fact]
        public void ExternalrunningNull()
        {
            Task_Server_.Services.Operations.ExternalOperations.TaskUser functions = new();
            var result = functions.running("none", new List<string> { });
            Assert.Null(result);
        }
    }
}
