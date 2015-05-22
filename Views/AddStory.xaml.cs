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
using Windows.Storage.Pickers;
using Windows.Storage;
using Windows.Storage.Streams;
using System.IO;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Media.PhoneExtensions;
using System.IO.IsolatedStorage;

namespace PhoneApp6.Views
{
    public partial class AddStory : PhoneApplicationPage
    {

        public string FileName = string.Empty;
        public AddStory()
        {
            InitializeComponent();
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            string date = DateTime.Now.ToShortDateString();
            DBHelperClass_Dreams DB_Helper = new DBHelperClass_Dreams();
            if (StoryTxt.Text != "" || ui.Text != "")
            {
                DB_Helper.Insert(new Class(date, StoryTxt.Text, FileName));
                //NavigationService.Navigate(new Uri("MainPage.xaml", UriKind.Relative)); 
                
            }

            else
            {
                MessageBox.Show("bla-bla-bla");
            }
        }

        private void ChoosePhoto_Click(object sender, RoutedEventArgs e)
        {
            var pc = new PhotoChooserTask();
            pc.Completed += pc_Completed;
            pc.ShowCamera = true;
            pc.Show();
        }

        void pc_Completed(object sender, PhotoResult e)
        {
            var originalName = Path.GetFileName(e.OriginalFileName);
            SaveImage(e.ChosenPhoto, originalName, 0, 100);
        }

        /// <summary>
        /// Сохранение из Фотопленки в IsolatedStorage
        /// </summary>
        /// <param name="imageName"></param>
        /// <param name="fileName"></param>
        /// <param name="orientation"></param>
        /// <param name="quality"></param>
        public void SaveImage(Stream imageName, string fileName, int orientation, int quality)
        {
            using (var isolatedStorage = IsolatedStorageFile.GetUserStoreForApplication()) 
            {
                if (isolatedStorage.FileExists(fileName))
                    isolatedStorage.DeleteFile(fileName);

                var fileStream = isolatedStorage.CreateFile(fileName);
                var bitMap = new BitmapImage();
                bitMap.SetSource(imageName);

                FileName = fileName;

                var wb = new WriteableBitmap(bitMap);
                wb.SaveJpeg(fileStream, wb.PixelWidth, wb.PixelHeight, orientation, quality);
                fileStream.Close();
            }
        }

        
    }
}