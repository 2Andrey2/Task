using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Task_Client_.Data.Entities;
using Task_Client_.Models.Actions;
using Task_Client_.ViewModels.Command;

namespace Task_Client_.ViewModels.ModelWindows.MainWindow.Groups
{
    class CreatePostWindowViewModel
    {
        ActionsGroups actionsGroups = new ActionsGroups();
        int id_group;
        public CreatePostWindowViewModel()
        {

        }
        public CreatePostWindowViewModel(int group)
        {
            id_group = group;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _title;
        public string title
        {
            get { return _title; }
            set
            {
                _title = value;
            }
        }

        private string _text;
        public string text
        {
            get { return _text; }
            set
            {
                _text = value;
            }
        }

        private string _teg;
        public string teg
        {
            get { return _teg; }
            set
            {
                _teg = value;
            }
        }

        public ICommand CreatePost
        {
            get
            {
                return new MyCommand((obj) =>
                {
                    if(actionsGroups.CreatePost(new List<string> { _title, _text, _teg, id_group.ToString(), UserNow.Authorized.id.ToString() }))
                    {
                        MessageBox.Show("Запись размещена");
                    }
                    else
                    {
                        MessageBox.Show("Ошибка запись не размещена");
                    }
                });
            }
        }
    }
}
