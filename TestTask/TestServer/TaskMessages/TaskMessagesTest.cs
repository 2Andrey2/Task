using System.Collections.Generic;
using Xunit;

namespace TestTask.TestServer.TaskMessages
{
    public class TaskMessagesTest
    {
        [Fact]
        public void ExternalTaskMessagesType_getusermessages_()
        {
            Task_Server_.Services.Operations.ExternalOperations.TaskMessages functions = new();
            var result = functions.gettype("getusermessages");
            Assert.Equal("tmessages[]", result);
        }
        [Fact]
        public void InternalTaskMessagesType_Internal_()
        {
            Task_Server_.Services.Operations.InternalOperations.TaskMessages functions = new();
            List<string> result = new();
            result.Add(functions.gettype("sendmessage"));
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
        public void InternalTaskMessagesType_none_()
        {
            Task_Server_.Services.Operations.InternalOperations.TaskMessages functions = new();
            var result = functions.gettype("none");
            Assert.Equal("Not", result);
        }
        [Fact]
        public void ExternalrunningNull()
        {
            Task_Server_.Services.Operations.ExternalOperations.TaskMessages functions = new();
            var result = functions.running("none", new List<string> { });
            Assert.Null(result);
        }
    }
}
