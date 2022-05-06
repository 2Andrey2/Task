using Xunit;
using Task_Server_.Services.Operations;
using Task_Server_.Services.Operations.Authorization;
using System.Collections.Generic;

namespace TestTask.TestServer.TestAuthorization
{
    public class AdditionalFunctionsTest
    {
        [Fact]
        public void CheckingRightsTest_registration_()
        {
            AdditionalFunctions functions = new();
            var result = functions.CheckingRights(new string[2] { "", "registration" }, new List<string> { });
            Assert.True(result);
        }
        [Fact]
        public void CheckingRightsTest_authorizationuser_()
        {
            AdditionalFunctions functions = new();
            var result = functions.CheckingRights(new string[2] { "", "authorizationuser" }, new List<string> { });
            Assert.True(result);
        }
        [Fact]
        public void CheckingRightsTest_none_()
        {
            AdditionalFunctions functions = new();
            var result = functions.CheckingRights(new string[2] { "", "none" }, new List<string> { "","","","none" });
            Assert.False(result);
        }
    }
}
