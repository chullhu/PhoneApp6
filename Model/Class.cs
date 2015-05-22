using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.ComponentModel;

namespace PhoneApp6.Model
{
    public class Class
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int Id
        {
            get;
            set;
        }

        private int idValue;
        private string DateValue = string.Empty;
        private string TextValue = string.Empty;
        private string ImageValue = string.Empty;

        public string Date
        {
            get
            {
                return this.DateValue;
            }

            set
            {
                if (value != this.DateValue)
                {
                    this.DateValue = value;
                    NotifyPropertyChanged("Date");
                }
            }
        }

        public string Text
        {
            get
            {
                return this.TextValue;
            }

            set
            {
                if (value != this.TextValue)
                {
                    this.TextValue = value;
                    NotifyPropertyChanged("Text");
                }
            }
        }

        public string Image
        {
            get
            {
                return this.ImageValue;
            }

            set
            {
                if (value != this.ImageValue)
                {
                    this.ImageValue = value;
                    NotifyPropertyChanged("Image");
                }
            }
        }

        public Class()
        {
 
        }

        public Class(string date, string text, string image)
        {
            Date = date;
            Text = text;
            Image = image;
        }

        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion
    }
}
