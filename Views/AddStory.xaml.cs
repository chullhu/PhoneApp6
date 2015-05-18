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
using Microsoft.Phone.Tasks;
using System.Windows.Media.Imaging;

namespace PhoneApp6.Views
{
    public partial class AddStory : PhoneApplicationPage
    {
        public AddStory()
        {
            InitializeComponent();
        }

        void pct_Completed(object sender, PhotoResult e)
        {
            BitmapImage bi = new BitmapImage();
            if (e.Error == null && e.TaskResult == TaskResult.OK)
            {
                bi.SetSource(e.ChosenPhoto);
                Img.Source = bi;
            }

            else
            {
                MessageBox.Show("не могу открыть фотку");
            }
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            DBHelperClass_Dreams DB_Helper = new DBHelperClass_Dreams();
            if (StoryTxt.Text != "" || ui.Text != "")
            {
                DB_Helper.Insert(new Dreams(StoryTxt.Text, ui.Text));
                //NavigationService.Navigate(new Uri("MainPage.xaml", UriKind.Relative));
            }

            else
            {
                MessageBox.Show("bla-bla-bla");
            }
        }

        private void ChoosePhoto_Click(object sender, RoutedEventArgs e)
        {
            PhotoChooserTask pct = new PhotoChooserTask();

            pct.Completed +=pct_Completed;
            pct.PixelHeight = 250;
            pct.PixelWidth = 250;
            pct.ShowCamera = true;

            pct.Show();
        }
    }
}