﻿using AdoptApp.ViewModels;
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
    public partial class AdoptList : ContentPage
    {
        CaseViewModel vm;
        public AdoptList()
        {
            InitializeComponent();
            vm = new CaseViewModel();
            this.BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            if (vm != null)
                vm.GetCases();

            base.OnAppearing();
        }

        private async void btnNewCase_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewCase());
        }
    }
}