using System.ComponentModel;
using Xamarin.Forms;
using AdoptApp.ViewModels;

namespace AdoptApp.Views
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