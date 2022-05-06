using Xunit;
using Task_Server_.Services.Operations;

namespace TestTask.TestServer
{
    public class TestDatabase
    {
        [Fact]
        public void ConnectBD()
        {
            Operations db = new ();
            Assert.NotNull(db.db);
        }
    }
}
