using Xunit;
using Task_Server_.Services.Operations;
using Task_Server_.Services.Operations.Authorization;
using System.Collections.Generic;
using System;

namespace TestTask.TestServer.TestAuthorization
{
    public class AuthorizationTest
    {
        [Fact]
        public void runningNull()
        {
            Authorization functions = new();
            var result = functions.running("none",new List<string> { });
            Assert.Null(result);
        }
        [Fact]
        public void gettype_authorizationuser_()
        {
            Authorization functions = new();
            var result = functions.gettype("authorizationuser");
            Assert.Equal("string",result);
        }
        [Fact]
        public void gettypeNone()
        {
            Authorization functions = new();
            var result = functions.gettype("none");
            Assert.Equal("Not", result);
        }
    }
}
