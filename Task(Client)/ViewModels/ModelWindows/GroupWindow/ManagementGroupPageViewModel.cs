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

namespace Task_Client_.ViewModels.ModelWindows.GroupWindow
{
    class ManagementGroupPageViewModel : INotifyPropertyChanged
    {
        ActionsGroups actionsGroups = new();

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private members_group _selectedParticipants;
        public members_group selectedParticipants
        {
            get { return _selectedParticipants; }
            set
            {
                _selectedParticipants = value;
            }
        }
        private readonly ObservableCollection<members_group> _participants = new ();
        public ObservableCollection<members_group> participants
        {
            get { return _participants; }
        }

        public ICommand Syncing
        {
            get
            {
                return new MyCommand((obj) =>
                {
                    List<members_group> userMass = actionsGroups.GetSubscribers(new List<string> { UserNow.groups.ToString() });
                    _participants.Clear();
                    for (int i = 0; i < userMass.Count; i++)
                    {
                        _participants.Add(userMass[i]);
                    }
                });
            }
        }

        public ICommand Exclude
        {
            get
            {
                return new MyCommand((obj) =>
                {
                    if(actionsGroups.ExcludeGroup(new List<string> { UserNow.groups.ToString(), _selectedParticipants.id.ToString() }))
                    {
                        MessageBox.Show("Пользователь исключен");
                    }
                    else
                    {
                        MessageBox.Show("Ошибка");
                    }
                });
            }
        }

        public ICommand Moderator
        {
            get
            {
                return new MyCommand((obj) =>
                {
                    if(actionsGroups.Moderator(new List<string> { UserNow.groups.ToString(), _selectedParticipants.id.ToString() }))
                    {
                        MessageBox.Show("Пользователь назначен модератором");
                    }
                    else
                    {
                        MessageBox.Show("Ошибка");
                    }
                });
            }
        }
        public ICommand Delete_group
        {
            get
            {
                return new MyCommand((obj) =>
                {
                    if(actionsGroups.DeleteGroup(new List<string> { UserNow.groups.ToString() }))
                    {
                        MessageBox.Show("Группа удалена");
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
