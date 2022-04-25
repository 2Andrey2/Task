using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Data_.Entities
{
    public class tgroups_post_comments
    {
        public int id { get; set; }
        public int post { get; set; }
        public int user { get; set; }
        public string text { get; set; }
        public int date { get; set; }
    }
}
