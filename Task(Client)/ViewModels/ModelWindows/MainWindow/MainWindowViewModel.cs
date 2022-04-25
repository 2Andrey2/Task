using System.ComponentModel;
using Task_Client_.Data;

namespace Task_Client_.ViewModels.ModelWindows.MainWindow
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            if (Events.events.Status == System.Threading.Tasks.TaskStatus.Created)
            {
                Events.events.Start();
                Events.OnSendServer += Events_OnSendServer;
            }
        }

        private void Events_OnSendServer(System.Collections.Generic.List<string> obj)
        {
            throw new System.NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
