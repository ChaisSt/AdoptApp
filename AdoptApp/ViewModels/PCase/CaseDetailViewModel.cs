﻿//using System;
//using System.Diagnostics;
//using System.Threading.Tasks;
//using AdoptApp.Models;
//using Xamarin.Forms;

//namespace AdoptApp.ViewModels
//{
//    [QueryProperty(nameof(CaseNum), nameof(CaseNum))]
//    public class CaseDetailViewModel : BaseViewModel
//    {
//        private string caseNum;
//        private string pic;
//        private string description;
//        private int group;
//        private string name;
//        private string age;
//        private string gender;
//        private string state;
//        private string race;
//        private string language;
//        private string bio;
//        private string interests;
//        public int CaseId { get; set; }

//        public string CaseNum
//        {
//            get
//            {
//                return caseNum;
//            }
//            set
//            {
//                caseNum = value;
//                LoadCaseNum(value);
//            }
//        }

//        public string Pic
//        {
//            get => pic;
//            set => SetProperty(ref pic, value);
//        }

//        public string Description
//        {
//            get => description;
//            set => SetProperty(ref description, value);
//        }

//        public int Group
//        {
//            get => group;
//            set => SetProperty(ref group, value);
//        }
        
//        public string Name
//        {
//            get => name;
//            set => SetProperty(ref name, value);
//        }

//        public string Age
//        {
//            get => age;
//            set => SetProperty(ref age, value);
//        }

//        public string Gender
//        {
//            get => gender;
//            set => SetProperty(ref gender, value);
//        }

//        public string State
//        {
//            get => state;
//            set => SetProperty(ref state, value);
//        }

//        public string Race
//        {
//            get => race;
//            set => SetProperty(ref race, value);
//        }

//        public string Language
//        {
//            get => language;
//            set => SetProperty(ref language, value);
//        }

//        public string Bio
//        {
//            get => bio;
//            set => SetProperty(ref bio, value);
//        }

//        public string Interests
//        {
//            get => interests;
//            set => SetProperty(ref interests, value);
//        }

//        public async void LoadCaseNum(string caseNum)
//        {
//            try
//            {
//                var child = await CaseDataStore.GetCaseAsync(caseNum);
//                CaseId = child.CaseId;
//                CaseNum = child.CaseNum;
//                Pic = child.Pic;
//                Description = child.Description;
//                Group = child.Group;
//                Name = child.Name;
//                Age = child.Age;
//                Gender = child.Gender;
//                State = child.State;
//                Race = child.Race;
//                Language = child.Language;
//                Bio = child.Bio;
//                Interests = child.Interests;
//            }
//            catch (Exception)
//            {
//                Debug.WriteLine("Failed to Load Case");
//            }
//        }
//    }
//}
