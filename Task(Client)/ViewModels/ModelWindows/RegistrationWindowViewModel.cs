using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Task_Client_.Data.Entities;
using Task_Client_.Models.Actions;
using Task_Client_.Models.ConnectingSockets;
using Task_Client_.ViewModels.Command;
using Task.Entities;

namespace Task_Client_.ViewModels.ModelWindows
{
    class RegistrationWindowViewModel : INotifyPropertyChanged
    {
        ActionsUser actionsuser = new ActionsUser();

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string _login;
        public string login
        {
            get { return _login; }
            set
            {
                _login = value;
            }
        }
        private string _password;
        public string password
        {
            get { return _password; }
            set
            {
                _password = value;
            }
        }
        private string _surname;
        public string surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
            }
        }
        private string _name;
        public string name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }
        private string _middle_name;
        public string middle_name
        {
            get { return _middle_name; }
            set
            {
                _middle_name = value;
            }
        }
        private string _position;
        public string Position
        {
            get { return _position; }
            set
            {
                _position = value;
            }
        }
        public ICommand RegisterNowB
        {
            get
            {
                return new MyCommand((obj) =>
                {
                    tusers user = new tusers();
                    user.login = _login; user.password = _password; user.surname = _surname; user.name = _name; user.middle_name = _middle_name; user.position = 1;
                    if(actionsuser.Registration(user))
                    {
                        MessageBox.Show("Пользователь зарегистрирован");
                    }
                    else
                    {
                        MessageBox.Show("Ошибка");
                    }
                });
            }
        }
    }
}
