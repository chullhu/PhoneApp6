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
using DrawerLayout;

namespace PhoneApp6
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Конструктор
        public MainPage()
        {
            InitializeComponent();
            //DrawerLayout.InitializeDrawerLayout();
        }

        private void Hamburger_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            
        }

        
    }
}