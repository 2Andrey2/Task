using System.Collections.Generic;
using System.ComponentModel;
using Task_Client_.Models.Actions;
using Task_Client_.Data.Entities;
using Task_Client_.ViewModels.Command;
using System.Windows.Input;
using System.Windows;
using Task_Client_.ViewModels.ModelWindows.MainWindow.Groups;
using System.Collections.ObjectModel;
using Task_Client_.Views.GroupWindowsViews.Model;
using Task_Data_.Entities;

namespace Task_Client_.ViewModels.ModelWindows.GroupWindow
{
    class MainGroupPageViewModel : INotifyPropertyChanged
    {
        ActionsGroups actionsGroups = new();
        public event PropertyChangedEventHandler PropertyChanged;
        public MainGroupPageViewModel()
        {
            if (UserNow.status_groups == 3 || UserNow.status_groups == 2)
            {
                _vis_stat = "Visible";
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _groupName = "Группа";
        public string groupName
        {
            get { return _groupName; }
            set
            {
                _groupName = value;
            }
        }
        private string _website = "www";
        public string website
        {
            get { return _website; }
            set
            {
                _website = value;
            }
        }

        private string _participants;
        public string participants
        {
            get { return _participants; }
            set
            {
                _participants = value;
            }
        }

        private string _vis_stat = "Collapsed";
        public string vis_stat
        {
            get { return _vis_stat; }
            set
            {
                _vis_stat = value;
            }
        }

        public ICommand CreatePost
        {
            get
            {
                return new MyCommand((obj) =>
                {
                    var displayRootRegistry = (Application.Current as App).displayRootRegistry;
                    var CreatePostWindowViewModel = new CreatePostWindowViewModel(UserNow.groups);
                    displayRootRegistry.ShowPresentation(CreatePostWindowViewModel);
                });
            }
        }

        public ICommand Syncing
        {
            get
            {
                return new MyCommand((obj) =>
                {
                    tgroups tgroups = actionsGroups.GetInfoGroups(new List<string> { UserNow.groups.ToString() });
                    _groupName = tgroups.name;
                    _website = tgroups.website;
                    _participants = UserNow.userMass.Count.ToString();
                    OnPropertyChanged("participants");
                    OnPropertyChanged("groupName");
                    OnPropertyChanged("website");
                    List<tgroups_post> posts = actionsGroups.GetPost(new List<string> { UserNow.groups.ToString(), "10" });
                    _posts.Clear();
                    foreach (tgroups_post post in posts)
                    {
                        _posts.Add(new Post(post.title, post.text, post.teg, post.date));
                    }
                });
            }
        }

        //Посты

        public ObservableCollection<Post> _posts = new();
        public ObservableCollection<Post> posts
        {
            get { return _posts; }
        }
    }
}
