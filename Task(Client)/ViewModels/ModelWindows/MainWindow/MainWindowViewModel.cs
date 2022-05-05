using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using Task_Client_.Data;
using Task_Client_.Data.Entities;
using Task_Client_.ViewModels.Command;
using Task_Data_.Entities;

namespace Task_Client_.ViewModels.ModelWindows.MainWindow
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        static Dispatcher dispatcher = Application.Current.MainWindow.Dispatcher;
        public MainWindowViewModel()
        {
            if (Events.events.Status == System.Threading.Tasks.TaskStatus.Created && UserNow.listen_port != 0)
            {
                Events.events.Start();
                Events.OnSendServer += Events_OnSendServer;
            }
        }

        private int _numberNotifications = 0;
        public int numberNotifications
        {
            get { return _numberNotifications; }
            set
            {
                _numberNotifications = value;
            }
        }

        public ObservableCollection<tevent_type> _events = new ObservableCollection<tevent_type>();
        public ObservableCollection<tevent_type> events
        {
            get { return _events; }
        }
        private tevent_type _eventt;
        public tevent_type eventt
        {
            get { return _eventt; }
            set
            {
                _eventt = value;
            }
        }
        private string _vis_event = "Collapsed";
        public string vis_event
        {
            get { return _vis_event; }
            set
            {
                _vis_event = value;
            }
        }

        public void Events_OnSendServer(System.Collections.Generic.List<string> obj)
        {
            dispatcher.Invoke(() =>
            {
                //_events.Add(new tevent_type(obj[0]));
                _events.Add(new tevent_type("Новое сообщение!"));
                _numberNotifications++;
                OnPropertyChanged("numberNotifications");
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand Notifications
        {
            get
            {
                return new MyCommand((obj) =>
                {
                    if (_vis_event == "Collapsed")
                    {
                        _vis_event = "Visible";
                    } 
                    else
                    {
                        _vis_event = "Collapsed";
                        _events.Clear();
                    }
                    _numberNotifications = 0;
                    OnPropertyChanged("numberNotifications");
                    OnPropertyChanged("vis_event");
                });
            }
        }

    }
}
