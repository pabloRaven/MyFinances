using MyFinances_Xemarin.ViewModels;
using Xamarin.Forms;

namespace MyFinances_Xemarin.Views
{
    public partial class NewItemPage : ContentPage
    {

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}