using System;

namespace Task.Entities
{
    [Serializable]
    public class tusers
    {
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string middle_name { get; set; }
        public int position { get; set; }
        public string image { get; set; }
    }
}
