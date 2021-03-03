using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AdoptApp.Views
{
    [ContentProperty("ContainerContent")]
    public partial class FormContainer : ContentView
    {
        public FormContainer()
        {
            InitializeComponent();
        }
        #region Properties  

        public View ContainerContent
        {
            get { return ContentFrame.Content; }
            set { ContentFrame.Content = value; }
        }
        public Color ContentBackgroundColor
        {
            get { return ContentFrame.BackgroundColor; }
            set { ContentFrame.BackgroundColor = value; }
        }
        public string HeaderText
        { get { return HeaderLabel.Text; } set { HeaderLabel.Text = value; } }
        public Color HeaderTextColor
        { get { return HeaderLabel.TextColor; } set { HeaderLabel.TextColor = value; } }
        public Color HeaderBackGroundColor
        { get { return HeaderFrame.BackgroundColor; } set { HeaderFrame.BackgroundColor = value; } }
        #endregion
    }
}
