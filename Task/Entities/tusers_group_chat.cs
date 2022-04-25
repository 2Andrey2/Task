namespace Task_Data_.Entities
{
    public class tusers_group_chat
    {
        public int id { get; set; }
        public int user { get; set; }
        public int chat { get; set; }
        public int status { get; set; }
        public tmessages_group_chat messages_group_chat { get; set; }
    }
}
