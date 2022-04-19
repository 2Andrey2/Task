using System.Windows;
using Task_Client_.ViewModels;
using Task_Client_.ViewModels.ModelWindows.MainWindow;
using Task_Client_.ViewModels.ModelWindows;
using Task_Client_.Views;
using Task_Client_.Views.MainWindowViews;
using Task_Client_.Views.MainWindowViews.MainPage.Groups;
using Task_Client_.ViewModels.ModelWindows.MainWindow.Groups;

namespace Task_Client_
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public DisplayRootRegistry displayRootRegistry = new DisplayRootRegistry();

        public App()
        {
            displayRootRegistry.RegisterWindowType<LoginWindowViewModel, LoginWindow>();
            displayRootRegistry.RegisterWindowType<RegistrationWindowViewModel, RegistrationWindow>();
            displayRootRegistry.RegisterWindowType<MainWindowViewModel, MainWindow>();
            displayRootRegistry.RegisterWindowType<GroupWindowsViewModel, GroupWindow>();
            displayRootRegistry.RegisterWindowType<CreatePostWindowViewModel, CreatePostWindow>();
        }
    }
}
