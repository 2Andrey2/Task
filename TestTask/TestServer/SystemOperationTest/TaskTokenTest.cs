using Xunit;
using Task_Server_.Services.Operations.SystemOperations;
using Task_Data_.Entities;

namespace TestTask.TestServer.SystemOperationTest
{
    public class TaskTokenTest
    {
        [Fact]
        public void AddUserTokenId()
        {
            TaskTokens functions = new();
            var result = functions.AddUserToken(999);
            Assert.Equal(999,result.user);
        }
        [Fact]
        public void AddUserTokenPort()
        {
            TaskTokens functions = new();
            var result = functions.AddUserToken(999,1000);
            Assert.Equal(1000, result.user_port);
        }
    }
}
