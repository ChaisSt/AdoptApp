using AdoptApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static AdoptApp.AppShell;

namespace AdoptApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewCase : ContentPage
    {
        public NewCase()
        {
            try
            {
                InitializeComponent();
                NewCaseViewModel vm = new NewCaseViewModel();
                this.BindingContext = vm;
            }
            catch (Exception)
            {

            }
        }

        async void OnPickPhotoButtonClicked(object sender, EventArgs e)
        {
            (sender as Button).IsEnabled = false;
            Image image = new Image();

            Stream stream = await DependencyService.Get<CameraInterface>().GetImageStreamAsync();
            if (stream != null)
            {
                image.Source = ImageSource.FromStream(() => stream);
            }

            (sender as Button).IsEnabled = true;
        }

        public void CreateCase(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AboutPage());
        }
    }
}