using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyFinances_Xemarin.Services;
using MyFinances_Xemarin.Views;

namespace MyFinances_Xemarin
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
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
