using AdoptApp.Database;
using AdoptApp.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace AdoptApp.ViewModels
{
    public class CaseViewModel : INotifyPropertyChanged
    {
        //private Case _selectedCase;
        private ObservableCollection<Case> _lstCases { get; set; }

        public ObservableCollection<Case> lstCases
        {
            get { return _lstCases; }
            set
            {
                _lstCases = value;
                OnPropertyChanged();
            }
        }
        public Command btnNewCase { get; set; }

        private string _lblInfo { get; set; }
        public string lblInfo
        {
            get { return _lblInfo; }
            set
            {
                _lblInfo = value;
                OnPropertyChanged();
            }
        }

        public CaseViewModel()
        {
            lstCases = new ObservableCollection<Case>();

        }

        //public Command LoadCasesCommand { get; }
        //public Command AddCaseCommand { get; }
        //public Command<Case> CaseTapped { get; }
        //public CaseViewModel()
        //{
        //    Title = "Browse";
        //    //Cases = new ObservableCollection<Case>();
        //    LoadCasesCommand = new Command(async () => await ExecuteLoadCasesCommand());

        //    CaseTapped = new Command<Case>(OnCaseSelected);

        //    AddCaseCommand = new Command(OnAddCase);
        //}

        public void GetCases()
        {
            try
            {
                AdoptDatabase caseDatabase = new AdoptDatabase();
                var cases = caseDatabase.GetCases().Result;

                if (cases != null && cases.Count > 0)
                {
                    lstCases = new ObservableCollection<Case>();

                    foreach (var child in cases)
                    {
                        lstCases.Add(new Case
                        {
                            CaseNum = child.CaseNum,
                            Pic = child.Pic,
                            Description = child.Description,
                            Group = child.Group,
                            Name = child.Name,
                            Age = child.Age,
                            Gender = child.Gender,
                            State = child.State,
                            Race = child.Race,
                            Language = child.Language,
                            Bio = child.Bio,
                            Interests = child.Interests
                        });
                    }

                    lblInfo = "Total " + cases.Count.ToString() + " record(s) found";
                }
                else
                    lblInfo = "No case records found. Please add one";
            }

            catch (Exception ex)
            {
                lblInfo = ex.Message.ToString();
            }
        }

        //async Task ExecuteLoadCasesCommand()
        //{
        //    IsBusy = true;

        //    try
        //    {
        //        Cases.Clear();
        //        var cases = await CaseDataStore.GetCasesAsync(true);
        //        foreach (var child in cases)
        //        {
        //            Cases.Add(child);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex);
        //    }
        //    finally
        //    {
        //        IsBusy = false;
        //    }
        //}

        //public void OnAppearing()
        //{
        //    IsBusy = true;
        //    SelectedCase = null;
        //}

        //public Case SelectedCase
        //{
        //    get => _selectedCase;
        //    set
        //    {
        //        SetProperty(ref _selectedCase, value);
        //        OnCaseSelected(value);
        //    }
        //}

        //private async void OnAddCase(object obj)
        //{
        //    await Shell.Current.GoToAsync(nameof(NewCaseProfile));
        //}

        //async void OnCaseSelected(Case child)
        //{
        //    if (child == null)
        //        return;

        //    // This will push the CaseDetailPage onto the navigation stack
        //    await Shell.Current.GoToAsync($"{nameof(CaseDetailPage)}?{nameof(CaseDetailViewModel.CaseNum)}={child.Id}");
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}