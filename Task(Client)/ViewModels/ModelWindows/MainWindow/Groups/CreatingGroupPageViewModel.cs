using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Task_Client_.Data.Entities;
using Task_Client_.Models.Actions;
using Task_Client_.ViewModels.Command;
using Task.Entities;

namespace Task_Client_.ViewModels.ModelWindows.MainWindow.Groups
{
    class CreatingGroupPageViewModel
    {
        ActionsGroups actionsGroups = new ActionsGroups();
        public CreatingGroupPageViewModel()
        {
            _massThematics = actionsGroups.GetThematics();
            foreach (tgroups_thematics thematics in _massThematics)
            {
                _listThematics.Add(thematics.name);
            }
        }

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
        private int _thematics;
        public int thematics
        {
            get { return _thematics; }
            set
            {
                _thematics = value;
            }
        }
        private string _website;
        public string website
        {
            get { return _website; }
            set
            {
                _website = value;
            }
        }
        private string _type;
        public string type
        {
            get { return _type; }
            set
            {
                _type = value;
            }
        }


        private tgroups_thematics[] _massThematics;
        private readonly ObservableCollection<string> _listThematics = new ObservableCollection<string>();
        public ObservableCollection<string> listThematics
        {
            get { return _listThematics; }
        }

        public ICommand CreateGroup
        {
            get
            {
                return new MyCommand((obj) =>
                {
                    if(actionsGroups.CreatingGroup(new List<string> { _groupName, _massThematics[_thematics].id.ToString(), _website, _type, UserNow.Authorized.id.ToString() }))
                    {
                        MessageBox.Show("Группа создана");
                        tgroups[] group = actionsGroups.SearchGroup(new List<string> { _groupName });
                        if(actionsGroups.JoinGroup(new List<string> { group[0].id.ToString(), UserNow.Authorized.id.ToString(), "3", "0" }))
                        {
                            MessageBox.Show("Вы назначены администратором группы");
                        }
                        else
                        {
                            MessageBox.Show("Не удалось назначить администратором группы");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при создании группы");
                    }
                });
            }
        }
    }
}
