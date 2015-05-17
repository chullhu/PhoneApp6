using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PhoneApp6.ViewModel;
using PhoneApp6.Model;

namespace PhoneApp6.Views
{
    public partial class AddStory : PhoneApplicationPage
    {
        public AddStory()
        {
            InitializeComponent();
        }

        

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            //TextData.Text = DateTime.Now.ToShortDateString();
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            DBHelperClass_Dreams DB_Helper = new DBHelperClass_Dreams();
            if (StoryTxt.Text != "" || ui.Text != "")
            {
                DB_Helper.Insert(new Dreams(StoryTxt.Text, ui.Text));
                NavigationService.Navigate(new Uri("MainPage.xaml", UriKind.Relative));
            }

            else
            {
                MessageBox.Show("bla-bla-bla");
            }
        }
    }
}