using System.Collections.Generic;

namespace Task_Data_.Entities
{
    public class tmessages_group_chat
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<tusers_group_chat> group_chat { get; set; } = new();
        public List<tmessages> messages { get; set; } = new();
    }
}
