using System.Collections.Generic;

namespace Task_Data_.Entities
{
    public class tgroups_thematics
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<tgroups> groups { get; set; } = new ();
    }
}
