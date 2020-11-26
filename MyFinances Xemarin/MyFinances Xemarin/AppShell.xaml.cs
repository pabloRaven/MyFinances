using System;
using System.Collections.Generic;
using MyFinances_Xemarin.ViewModels;
using MyFinances_Xemarin.Views;
using Xamarin.Forms;

namespace MyFinances_Xemarin
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
