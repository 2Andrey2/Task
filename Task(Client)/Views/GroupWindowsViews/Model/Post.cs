using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Client_.Views.GroupWindowsViews.Model
{
    class Post
    {
        public Post()
        {
            
        }
        public Post(string _title, string _text, string _teg, int _date)
        {
            title = _title;
            text = _text;
            teg = _teg;
            date = _date;
        }
        public string title { get; set; }
        public string text { get; set; }
        public string teg { get; set; }
        public int group { get; set; }
        public int user { get; set; }
        public string image { get; set; }
        public int date { get; set; }
        public int views { get; set; }
        public int comments { get; set; }
    }
}
