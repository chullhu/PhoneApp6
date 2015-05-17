using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PhoneApp6.Resources;


namespace PhoneApp6
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Конструктор
        public MainPage()
        {
            this.InitializeComponent();
            //DrawerLayout.DrawerLayout.InitializeDrawerLayout();
        }

        private void Hamburger_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            
        }

        private void MemoList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/AddStory.xaml", UriKind.Relative));
        }

        
    }
}