namespace Task_Data_.Entities
{
    public class tgroups
    {
        public tgroups()
        {

        }
        public tgroups(string name_, int id_)
        {
            name = name_;
            id = id_;
        }
        public int id { get; set; }
        public string name { get; set; }
        public int thematics { get; set; }
        public string website { get; set; }
        public int type { get; set; }
}
}
