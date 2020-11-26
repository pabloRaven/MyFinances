using System.ComponentModel;
using Xamarin.Forms;
using MyFinances_Xemarin.ViewModels;

namespace MyFinances_Xemarin.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}