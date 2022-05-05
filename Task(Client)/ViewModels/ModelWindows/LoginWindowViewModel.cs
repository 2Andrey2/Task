using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Task_Client_.Data.Entities;
using Task_Client_.Models.Actions;
using Task_Client_.ViewModels.Command;
using Task_Client_.ViewModels.ModelWindows.MainWindow;
using Task_Data_.SystemData;

namespace Task_Client_.ViewModels.ModelWindows
{
    class LoginWindowViewModel : INotifyPropertyChanged
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
        public ICommand OpenRegistrationWindow
        {
            get
            {
                return new MyCommand((obj) =>
                {
                    var displayRootRegistry = (Application.Current as App).displayRootRegistry;
                    var registrationWindowViewModel = new RegistrationWindowViewModel();
                    displayRootRegistry.ShowPresentation(registrationWindowViewModel);
                });
            }
        }

        public ICommand AuthorizationUser
        {
            get
            {
                return new MyCommand((obj) =>
                {
                    UserNow.listen_port = Ports.GetPort();
                    if (actionsuser.Authorization(new List<string> { _login, _password, UserNow.listen_port.ToString() }) != "0")
                    {
                        actionsuser.GetUser(new List<string> { _login, _password });
                        UserNow.Friends = actionsuser.GetFroendsUser(new List<string> { UserNow.Authorized.id.ToString() });
                        var displayRootRegistry = (Application.Current as App).displayRootRegistry;
                        var MainWindowViewModel = new MainWindowViewModel();
                        displayRootRegistry.ShowPresentation(MainWindowViewModel);
                        Application.Current.MainWindow.Close();
                    }
                    else
                    {
                        MessageBox.Show("Пользователь не найден");
                    }
                });
            }
        }

        public void DialogResult()
        {
            
        }
    }
}
