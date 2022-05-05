using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Data_.Entities
{
    public class tevent_type
    {
        public tevent_type (string _name, int _id = 0)
        {
            name = _name;
        }
        public int id { get; set; }
        public string name { get; set; }
    }
}
