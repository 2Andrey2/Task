using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Task_Data_.Media;
using Task_Client_.Data.Entities;
using Task_Client_.Models.Actions;
using Task_Client_.ViewModels.Command;

namespace Task_Client_.ViewModels.ModelWindows.MainWindow
{
    class UserPageViewModel
    {
        public UserPageViewModel()
        {
            FirstName = UserNow.Authorized.name;
            LastName = UserNow.Authorized.surname;
            MiddleName = UserNow.Authorized.middle_name;
            if (Media.CheckingUsersFolder(UserNow.Authorized.id.ToString()))
            {
                if (Media.CheckingUsersAvatar(UserNow.Authorized.id.ToString()))
                {
                    _PathImage = "/" + Media.PathFolderUser + "/" + UserNow.Authorized.id + "/" + Media.NameAvatar;
                }
                else
                {
                    Image img = actionsUser.GetAvatar(new List<string> { UserNow.Authorized.id.ToString() });
                    if (img != null)
                    {
                        img.Save(Media.PathFolderUser + "/" + UserNow.Authorized.id + "/" + Media.NameAvatar);
                        _PathImage = "/" + Media.PathFolderUser + "/" + UserNow.Authorized.id + "/" + Media.NameAvatar;
                    }
                }
            }
        }

        ActionsUser actionsUser = new ActionsUser();
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set
            {
                _LastName = value;
            }
        }

        private string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                _FirstName = value;
            }
        }

        private string _MiddleName;
        public string MiddleName
        {
            get { return _MiddleName; }
            set
            {
                _MiddleName = value;
            }
        }

        private string _Status;
        public string Status
        {
            get { return _Status; }
            set
            {
                _Status = value;
            }
        }

        private string _PathImage;
        public string PathImage
        {
            get { return _PathImage; }
            set
            {
                _PathImage = value;
            }
        }

        public ICommand ChangeImage
        {
            get
            {
                return new MyCommand((obj) =>
                {
                    OpenFileDialog OPF = new OpenFileDialog();
                    if (OPF.ShowDialog() == true)
                    {
                        Image img = Image.FromFile(OPF.FileName);
                        actionsUser.UploadingImage(img);
                    }
                });
            }
        }
    }
}
