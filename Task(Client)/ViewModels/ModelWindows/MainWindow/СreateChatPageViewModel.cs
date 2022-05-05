using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Task_Data_.Entities;
using Task_Client_.Data.Entities;
using Task_Client_.Models.Actions;
using Task_Client_.ViewModels.Command;

namespace Task_Client_.ViewModels.ModelWindows.MainWindow
{
    class СreateChatPageViewModel
    {
        ActionsChats actions = new ActionsChats();

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _nameChat;
        public string nameChat
        {
            get { return _nameChat; }
            set
            {
                _nameChat = value;
            }
        }

        private friends _selectedFriends;
        public friends selectedFriends
        {
            get { return _selectedFriends; }
            set
            {
                _selectedFriends = value;
            }
        }

        private readonly ObservableCollection<friends> _foundFriends = new ObservableCollection<friends>();
        public ObservableCollection<friends> foundFriends
        {
            get { return _foundFriends; }
        }

        private friends _selectedChats;
        public friends selectedChats
        {
            get { return _selectedChats; }
            set
            {
                _selectedChats = value;
            }
        }

        private readonly ObservableCollection<friends> _foundChats = new ObservableCollection<friends>();
        public ObservableCollection<friends> foundChats
        {
            get { return _foundChats; }
        }

        private void UpdateList()
        {
            foundFriends.Clear();
            for (int i = 0; i < UserNow.Friends.Length; i++)
            {
                foundFriends.Add(UserNow.Friends[i]);
            }
        }

        public ICommand AddChat
        {
            get
            {
                return new MyCommand((obj) =>
                {
                    _foundChats.Add(_selectedFriends);
                });
            }
        }

        public ICommand ExcludeChat
        {
            get
            {
                return new MyCommand((obj) =>
                {
                    _foundChats.Remove(_selectedChats);
                });
            }
        }

        public ICommand Syncing
        {
            get
            {
                return new MyCommand((obj) =>
                {
                    UpdateList();
                });
            }
        }

        public ICommand CreateChat
        {
            get
            {
                return new MyCommand((obj) =>
                {
                    if(actions.CreateChat(new List<string> { _nameChat }))
                    {
                        List<tusers_group_chat> info = new List<tusers_group_chat>();
                        tmessages_group_chat id = actions.GetInfoChat(new List<string> { _nameChat });
                        info.Add(new tusers_group_chat { chat = id.id, user = UserNow.Authorized.id });
                        foreach (friends friend in _foundChats)
                        {
                            info.Add(new tusers_group_chat { chat = id.id, user = friend.id });
                        }
                        if (actions.AddChatParticipant(info))
                        {
                            MessageBox.Show("Чат создан, пользователи добавлены");
                        }
                        else
                        {
                            MessageBox.Show("Чат создан, пользователей добавить не удалось");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ошибка создания чата");
                    }

                });
            }
        }
    }
}
