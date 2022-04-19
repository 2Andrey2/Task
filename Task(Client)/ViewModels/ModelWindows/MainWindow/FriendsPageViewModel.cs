using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Task;
using Task.Entities;
using Task_Client_.Data.Entities;
using Task_Client_.Models.Actions;
using Task_Client_.ViewModels.Command;
using Task_Client_.Views.MainWindowViews.Model;

namespace Task_Client_.ViewModels.ModelWindows.MainWindow
{
    class FriendsPageViewModel : INotifyPropertyChanged
    {
        ActionsMessages actionsMessages = new ActionsMessages();
        ActionsUser actionsUser = new ActionsUser();
        public FriendsPageViewModel()
        {
            UpdateList();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //Меню друзей
        private friends _selectedFriends;
        public friends selectedFriends
        {
            get { return _selectedFriends; }
            set
            {
                if (value != null)
                {
                    _selectedFriendsText = value.surname;
                }
                OnPropertyChanged("selectedFriendsText");
                _selectedFriends = value;
                DrawMessages(GetMessages());
            }
        }
        private readonly ObservableCollection<friends> _foundFriends = new ObservableCollection<friends>();
        public ObservableCollection<friends> foundFriends
        {
            get { return _foundFriends; }
        }

        //Чат
        private string _selectedFriendsText;
        public string selectedFriendsText
        {
            get { return _selectedFriendsText; }
            set
            {
                _selectedFriendsText = value;
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
                    actionsMessages.SendMessage(new List<string> { UserNow.Authorized.id.ToString(), _selectedFriends.id.ToString(), _messageUser });
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
                    UserNow.Friends = actionsUser.GetFroendsUser(new List<string> { UserNow.Authorized.id.ToString() });
                    UpdateList();
                    DrawMessages(GetMessages());
                });
            }
        }

        private tmessages[] GetMessages()
        {
            if (_selectedFriends != null)
            {
                tmessages[] rez = actionsMessages.GetUserMessages(new List<string> { UserNow.Authorized.id.ToString(), _selectedFriends.id.ToString() });
                if (rez == null)
                {
                    return null;
                }
                return rez;
            }
            return null;
        }

        private void DrawMessages(tmessages[] messages)
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
                    if (message.host == _selectedFriends.id)
                    {
                        _messages.Add(new CustomMessage(message.message));
                    }
                }
            }
        }

        private void UpdateList()
        {
            foundFriends.Clear();
            for (int i = 0; i < UserNow.Friends.Length; i++)
            {
                UserNow.Friends[i].login = Encryption.EncodeDecryptString(UserNow.Friends[i].login);
                foundFriends.Add(UserNow.Friends[i]);
            }
        }
    }
}
