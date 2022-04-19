namespace Task.Entities
{
    public class tmessages
    {
        public int id { get; set; }
        public int host { get; set; }
        public int friend { get; set; }
        public string message { get; set; }
        public int? group_chat { get; set; }
        public int personal { get; set; }
    }
}
