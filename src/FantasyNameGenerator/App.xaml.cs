using Service;
using System.Windows;
using View;
using ViewModel;

namespace StartUp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            ViewRegistration.RegisterViewType<MainViewModel, MainView>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainViewModel mainViewModel = new();
            ViewInteraction.ShowPresentation(mainViewModel);
        }
    }
}