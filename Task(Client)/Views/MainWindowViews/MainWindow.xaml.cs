using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Task_Client_.Views.MainWindowViews.Model;
using Task_Client_.Views.MainWindowViews.MainPage;
using Task_Client_.Views.MainWindowViews.MainPage.Groups;

namespace Task_Client_.Views.MainWindowViews
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var item0 = new ItemMenu("Меню", new UserControl(), PackIconKind.ViewDashboard);

            var menuRegister = new List<SubItem>();
            menuRegister.Add(new SubItem("Главная", new User()));
            menuRegister.Add(new SubItem("Друзья", new FriendsPage()));
            menuRegister.Add(new SubItem("Поиск друзей", new SearchUsersPage()));
            var item6 = new ItemMenu("Друзья", menuRegister, PackIconKind.Account);

            var menuSchedule = new List<SubItem>();
            menuSchedule.Add(new SubItem("Создать группу", new CreatingGroupPage()));
            menuSchedule.Add(new SubItem("Найти группу", new SearchGroupsPage()));
            menuSchedule.Add(new SubItem("Мои группы", new MyGroupPage()));
            var item1 = new ItemMenu("Группы", menuSchedule, PackIconKind.AccountGroup);

            var menuChat = new List<SubItem>();
            menuChat.Add(new SubItem("Создать чат", new СreateChat()));
            menuChat.Add(new SubItem("Чаты", new Chats()));
            var item2 = new ItemMenu("Чаты", menuChat, PackIconKind.Chat);

            Menu.Children.Add(new UserControlMenuItem(item0, this));
            Menu.Children.Add(new UserControlMenuItem(item6, this));
            Menu.Children.Add(new UserControlMenuItem(item1, this));
            Menu.Children.Add(new UserControlMenuItem(item2, this));
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
    }
}
