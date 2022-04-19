using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Task_Data_.Entities;
using Task_Client_.Data.Entities;
using Task_Client_.Models.Actions;
using Task_Client_.ViewModels.Command;
using Task_Client_.Views.MainWindowViews.Model;

namespace Task_Client_.ViewModels.ModelWindows.MainWindow
{
    class ChatsPageViewModel
    {
        List<tmessages_group_chat> userChats = new List<tmessages_group_chat>();
        ActionsChats actionsChats = new ActionsChats();
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private tmessages_group_chat _selectedChat;
        public tmessages_group_chat selectedChat
        {
            get { return _selectedChat; }
            set
            {
                if (value != null)
                {
                    _selectedChatText = value.name;
                }
                OnPropertyChanged("selectedChatText");
                _selectedChat = value;
                DrawMessages(GetMessages());
            }
        }
        private readonly ObservableCollection<tmessages_group_chat> _group_chat = new ObservableCollection<tmessages_group_chat>();
        public ObservableCollection<tmessages_group_chat> group_chat
        {
            get { return _group_chat; }
        }

        //Чат
        private string _selectedChatText;
        public string selectedChatText
        {
            get { return _selectedChatText; }
            set
            {
                _selectedChatText = value;
            }
        }
        public ObservableCollection<MessageBase> _messages = new ObservableCollection<MessageBase>();
        public ObservableCollection<MessageBase> messages
        {
            get { return _messages; }
        }
        private string _messageUser;
        public string messageUser
        {
            get { return _messageUser; }
            set
            {
                _messageUser = value;
            }
        }

        public ICommand SendMessage
        {
            get
            {
                return new MyCommand((obj) =>
                {
                    actionsChats.SendMessage(new List<string> { UserNow.Authorized.id.ToString(), _selectedChat.id.ToString(), _messageUser });
                    _messageUser = "";
                    DrawMessages(GetMessages());
                });
            }
        }

        public ICommand Syncing
        {
            get
            {
                return new MyCommand((obj) =>
                {
                    userChats = actionsChats.GetChatsUser(new List<string> { UserNow.Authorized.id.ToString() });
                    UpdateList();
                    DrawMessages(GetMessages());
                });
            }
        }

        private List<tmessages> GetMessages()
        {
            if (_selectedChat != null)
            {
                List<tmessages> rez = actionsChats.GetChatUserMessages(new List<string> { _selectedChat.id.ToString() });
                if (rez == null)
                {
                    return null;
                }
                return rez;
            }
            return null;
        }

        private void DrawMessages(List<tmessages> messages)
        {
            if (messages != null)
            {
                _messages.Clear();
                foreach (tmessages message in messages)
                {
                    if (message.host == UserNow.Authorized.id)
                    {
                        _messages.Add(new MyMessage(message.message));
                    }
                    else
                    {
                        _messages.Add(new CustomMessage(message.message));
                    }

                }
            }
        }

        private void UpdateList()
        {
            group_chat.Clear();
            foreach(tmessages_group_chat chat in userChats)
            {
                group_chat.Add(chat);
            }
        }
    }
}
