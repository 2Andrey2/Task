using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Task_Client_.Data.Entities;
using Task_Client_.Models.Actions;
using Task_Client_.ViewModels.Command;
using Task_Data_;
using Task_Data_.Entities;

namespace Task_Client_.ViewModels.ModelWindows.MainWindow
{
    class SearchPageViewModel : INotifyPropertyChanged
    {
        ActionsUser actionsuser = new ActionsUser();

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //Поиск друзей
        private string _searchSearch;
        public string searchSearch
        {
            get { return _searchSearch; }
            set
            {
                _searchSearch = value;
            }
        }
        private friends _selectedSearch;
        public friends selectedSearch
        {
            get { return _selectedSearch; }
            set
            {
                _selectedSearch = value;
            }
        }
        private readonly ObservableCollection<friends> _foundUser = new ObservableCollection<friends>();
        public ObservableCollection<friends> foundUser
        {
            get { return _foundUser; }
        }

        public ICommand SearchB
        {
            get
            {
                return new MyCommand((obj) =>
                {
                    tusers[] result = actionsuser.SearchUser(new List<string> { _searchSearch });
                    _foundUser.Clear();
                    int flag = 0;
                    for (int i = 0; i < result.Length; i++)
                    {
                        foreach(friends user in UserNow.Friends)
                        {
                            if (user.id == result[i].id)
                            {
                                flag = 1;
                                break;
                            }
                        }
                        if (flag == 0)
                        {
                            result[i].login = Encryption.EncodeDecryptString(result[i].login);
                            _foundUser.Add(new friends(result[i].id, result[i].login, result[i].surname, result[i].name, result[i].middle_name, "0"));
                        }
                        flag = 0;
                    }
                });
            }
        }
        public ICommand AddFriendB
        {
            get
            {
                return new MyCommand((obj) =>
                {
                    if (actionsuser.AddFriend(new List<string> { _selectedSearch.id.ToString(), UserNow.Authorized.id.ToString(), "1" }))
                    {
                        MessageBox.Show("Вы добавили нового друга " + _selectedSearch.name);
                    }
                    else
                    {
                        MessageBox.Show("Ошибка(Пользователь не добавлен)");
                    }
                });
            }
        }
    }
}
