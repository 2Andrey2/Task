using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Server_.Services.Operations
{
    interface IOperations
    {
        public object running(string task, object massinfo, List<string> parameters);
        public string gettype(string task);
    }
}
