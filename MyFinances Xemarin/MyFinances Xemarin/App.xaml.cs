using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyFinances_Xemarin.Services;
using MyFinances_Xemarin.Views;

namespace MyFinances_Xemarin
{
    public partial class App : Application
    {
        //TODO :uzupełnic
        public static string BackendUrl = "";
        public App()
        {
            InitializeComponent();

            DependencyService.Register<OperationService>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
