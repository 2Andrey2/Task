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
    class SearchGroupsPageViewModel
    {
        ActionsGroups actionsGroups = new ActionsGroups();
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _groupName;
        public string groupName
        {
            get { return _groupName; }
            set
            {
                _groupName = value;
            }
        }

        private readonly ObservableCollection<tgroups> _foundGroups = new ObservableCollection<tgroups>();
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


        public ICommand SearchGroup
        {
            get
            {
                return new MyCommand((obj) =>
                {
                    tgroups[] tgroups = actionsGroups.SearchGroup(new List<string> { _groupName });
                    _foundGroups.Clear();
                    if (tgroups != null)
                    {
                        for (int i = 0; i < tgroups.Length; i++)
                        {
                            _foundGroups.Add(new tgroups(tgroups[i].name, tgroups[i].id));
                        }
                    }
                });
            }
        }

        public ICommand JoinGroup
        {
            get
            {
                return new MyCommand((obj) =>
                {
                    if(actionsGroups.JoinGroup(new List<string> { _selectedGroups.id.ToString(), UserNow.Authorized.id.ToString(), "1", "0"}))
                    {
                        MessageBox.Show("Вы вступили в группу" + _selectedGroups.name);
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
