using System.Collections.Generic;
using Xunit;

namespace TestTask.TestServer.TaskChatTest
{
    public class TaskChatTest
    {
        [Fact]
        public void ExternalTaskChatType_tmessages_group_chat_()
        {
            Task_Server_.Services.Operations.ExternalOperations.TaskChat functions = new();
            var result = functions.gettype("getinfochat");
            Assert.Equal("tmessages_group_chat", result);
        }
        [Fact]
        public void ExternalTaskChatType_getchatsuser_()
        {
            Task_Server_.Services.Operations.ExternalOperations.TaskChat functions = new();
            var result = functions.gettype("getchatsuser");
            Assert.Equal("List<tmessages_group_chat>", result);
        }
        [Fact]
        public void ExternalTaskChatType_getchatusermessages_()
        {
            Task_Server_.Services.Operations.ExternalOperations.TaskChat functions = new();
            var result = functions.gettype("getchatusermessages");
            Assert.Equal("List<tmessages>", result);
        }
        [Fact]
        public void ExternalTaskChatType_none_()
        {
            Task_Server_.Services.Operations.ExternalOperations.TaskChat functions = new();
            var result = functions.gettype("none");
            Assert.Equal("Not", result);
        }
        [Fact]
        public void InternalTaskChatType_createchat_()
        {
            Task_Server_.Services.Operations.InternalOperations.TaskChat functions = new();
            var result = functions.gettype("createchat");
            Assert.Equal("bool", result);
        }
        [Fact]
        public void InternalTaskChatType_addchatparticipant_()
        {
            Task_Server_.Services.Operations.InternalOperations.TaskChat functions = new();
            var result = functions.gettype("addchatparticipant");
            Assert.Equal("bool", result);
        }
        [Fact]
        public void InternalTaskChatType_sendmessage_()
        {
            Task_Server_.Services.Operations.InternalOperations.TaskChat functions = new();
            var result = functions.gettype("sendmessage");
            Assert.Equal("bool", result);
        }
        [Fact]
        public void ExternalrunningNull()
        {
            Task_Server_.Services.Operations.ExternalOperations.TaskChat functions = new();
            var result = functions.running("none", new List<string> { });
            Assert.Null(result);
        }
        [Fact]
        public void InternalTaskChatType_none_()
        {
            Task_Server_.Services.Operations.InternalOperations.TaskChat functions = new();
            var result = functions.gettype("none");
            Assert.Equal("Not", result);
        }
    }
}
