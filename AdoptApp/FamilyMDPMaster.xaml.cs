using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AdoptApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FamilyMDPMaster : ContentPage
    {
        public ListView ListView;

        public FamilyMDPMaster()
        {
            InitializeComponent();

            BindingContext = new FamilyMDPMasterViewModel();
            ListView = MenuItemsListView;
        }

        class FamilyMDPMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<FamilyMDPMasterMenuItem> MenuItems { get; set; }

            public FamilyMDPMasterViewModel()
            {
                MenuItems = new ObservableCollection<FamilyMDPMasterMenuItem>(new[]
                {
                    new FamilyMDPMasterMenuItem { Id = 0, Title = "Page 1" },
                    new FamilyMDPMasterMenuItem { Id = 1, Title = "Page 2" },
                    new FamilyMDPMasterMenuItem { Id = 2, Title = "Page 3" },
                    new FamilyMDPMasterMenuItem { Id = 3, Title = "Page 4" },
                    new FamilyMDPMasterMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}