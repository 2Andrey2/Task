using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Server_.Data.WorkingDatabase;

namespace Task_Server_.Services.Operations
{
    public class Operations
    {
        public DBMySQLUtils db;

        public Operations()
        {
            db = new DBMySQLUtils();
        }
    }
}
