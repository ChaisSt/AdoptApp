using AdoptApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AdoptApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewHome : ContentPage
    {
        public NewHome()
        {
            try
            {
                InitializeComponent();
                this.BindingContext = new NewHomeViewModel();

            }
            catch (Exception e)
            {

            }
        }
        public void CreateWorker(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }
    }
}
