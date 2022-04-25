using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Task_Data_.Entities;
using Task_Client_.Data.Entities;
using Task_Client_.Models.Actions;
using Task_Client_.ViewModels.Command;

namespace Task_Client_.ViewModels.ModelWindows.MainWindow.Groups
{
    class MyGroupPageViewModel
    {
        ActionsGroups actionsGroups = new ();
        public event PropertyChangedEventHandler PropertyChanged;
        public MyGroupPageViewModel()
        {
            updateList();
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private readonly ObservableCollection<tgroups> _foundGroups = new ();
        public ObservableCollection<tgroups> foundGroups
        {
            get { return _foundGroups; }
        }
        private tgroups _selectedGroups;
        public tgroups selectedGroups
        {
            get { return _selectedGroups; }
            set
            {
                _selectedGroups = value;
            }
        }
        public ICommand Entrance
        {
            get
            {
                return new MyCommand((obj) =>
                {
                if (UserNow.groups == 0)
                {
                    UserNow.groups = _selectedGroups.id;
                    var displayRootRegistry = (Application.Current as App).displayRootRegistry;
                    var GroupWindowsViewModel = new GroupWindowsViewModel();
                    displayRootRegistry.ShowPresentation(GroupWindowsViewModel);
                }
                else
                {
                    MessageBox.Show("Группа уже открыта");
                }
                });
            }
        }

        public ICommand Syncing
        {
            get
            {
                return new MyCommand((obj) =>
                {
                    updateList();
                });
            }
        }

        private void updateList()
        {
            tgroups[] tgroups = actionsGroups.UserGroups(new List<string> { UserNow.Authorized.id.ToString() });
            if (tgroups != null)
            {
                _foundGroups.Clear();
                for (int i = 0; i < tgroups.Length; i++)
                {
                    _foundGroups.Add(new tgroups(tgroups[i].name, tgroups[i].id));
                }
            }
        }
    }
}
