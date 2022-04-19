namespace Task_Data_.Entities
{
    public class friends
    {
        public friends()
        {

        }
        public friends(int _id, string _login, string _surname, string _name, string _middle_name, string _status)
        {
            id = _id;
            surname = _surname;
            name = _name;
            middle_name = _middle_name;
            status = _status;
            login = _login;
        }
        public friends(string _surname, string _name, string _middle_name, string _status)
        {
            surname = _surname;
            name = _name;
            middle_name = _middle_name;
            status = _status;
        }
        public int id { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string middle_name { get; set; }
        public string status { get; set; }
        public string login { get; set; }
    }
}
