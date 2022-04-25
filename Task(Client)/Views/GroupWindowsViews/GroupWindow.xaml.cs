using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Task_Client_.Data.Entities;
using Task_Client_.Models.Actions;
using Task_Client_.Views.GroupWindowsViews;
using Task_Client_.Views.GroupWindowsViews.PageGroups;
using Task_Client_.Views.MainWindowViews.Model;
using Task_Data_.Entities;

namespace Task_Client_.Views
{
    /// <summary>
    /// Логика взаимодействия для Group.xaml
    /// </summary>
    public partial class GroupWindow : Window
    {
        public GroupWindow()
        {
            InitializeComponent();
            ActionsGroups actionsGroups = new();
            UserNow.userMass = actionsGroups.GetSubscribers(new List<string> { UserNow.groups.ToString() });
            foreach (members_group user in UserNow.userMass)
            {
                if (user.id == UserNow.Authorized.id)
                {
                    UserNow.status_groups = user.status_id;
                }
            }

            var item0 = new ItemMenu("Меню", new UserControl(), PackIconKind.ViewDashboard);

            var menuRegister = new List<SubItem>();
            menuRegister.Add(new SubItem("Главная", new MainGroupPage()));
            if (UserNow.status_groups == 3)
            {
                menuRegister.Add(new SubItem("Управление", new ManagementGroupPage()));
                menuRegister.Add(new SubItem("Статистика", new Statistics()));
            }

            var item6 = new ItemMenu("Функции", menuRegister, PackIconKind.Function);

            Menu.Children.Add(new UserControlMenuItem(item0, this));
            Menu.Children.Add(new UserControlMenuItem(item6, this));


        }

        internal void SwitchScreen(object sender)
        {
            var screen = ((UserControl)sender);

            if (screen != null)
            {
                StackPanelMain.Children.Clear();
                StackPanelMain.Children.Add(screen);
            }
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            UserNow.groups = 0;
        }
    }
}
