using Xunit;
using Task_Server_.Services.Operations.SystemOperations;
using Task_Server_.Services;
using System.Collections.Generic;

namespace TestTask.TestServer
{
    public class AnalysisTaskTest
    {
        [Fact]
        public void AnalysisTask_authorization_()
        {
            var result = AnalysisTask.Analysis(new List<string> { "authorization authorizationuser","25","List<string>" });
            Assert.Equal(new List<string> { "string" }, result);
        }
        [Fact]
        public void AnalysisTask_getuser_Not()
        {
            var result = AnalysisTask.Analysis(new List<string> { "user getuser external", "25", "List<string>" });
            Assert.Equal(new List<string> { "Недостаточно прав" }, result);
        }
    }
}
