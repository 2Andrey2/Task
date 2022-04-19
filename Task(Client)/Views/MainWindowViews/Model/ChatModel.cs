using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Client_.Views.MainWindowViews.Model
{
    public abstract class MessageBase
    {
        protected MessageBase(string text, string date)
        {
            Text = text;
            Date = date;
        }

        public virtual string Text { get; protected set; }
        public virtual string Date { get; protected set; }
    }

    public class MyMessage : MessageBase
    {
        public MyMessage(string text)
            : base(text, "01.01.2021") { }
}

    public class CustomMessage : MessageBase
    {
        public CustomMessage(string text)
            : base(text, "01.01.2021") { }
    }
}
