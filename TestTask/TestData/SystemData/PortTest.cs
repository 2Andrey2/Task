using System.Collections.Generic;
using System.Drawing;
using Task_Client_.Models.Actions;
using Task_Data_.SystemData;
using Xunit;

namespace TestTask.TestData.SystemData
{
    public class PortTest
    {
        [Fact]
        public void GetPortTest()
        {
            var result = Ports.GetPort();
            Assert.InRange(result, 10000, 11000);
        }
    }
}
