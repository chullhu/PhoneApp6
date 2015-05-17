using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.ComponentModel;

namespace PhoneApp6.Model
{
    public class Dreams
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int Id 
        {
            get;
            set; 
        }

        public bool Star
        {
            get;
            set;
        }

        public bool Fav
        {
            get;
            set;
        }

        private int idValue;
        private string DateValue = string.Empty;
        private string TextValue = string.Empty;
        private string TagValue = string.Empty;
        private bool StarValue = false;
        private bool FavValue = false;

        public event PropertyChangedEventHandler PropertyChanged;
        private string p1;
        private string p2;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public string Date
        {
            get
            { return this.DateValue; }

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
            { return this.TextValue;}

            set
            {
                if (value != this.TextValue)
                {
                    this.TextValue = value;
                    NotifyPropertyChanged("Text");
                }
            }
        }

        public string Tag
        {
            get
            { return this.TagValue; }

            set
            {
                if (value != this.TagValue)
                {
                    this.TagValue = value;
                    NotifyPropertyChanged("Tag");
                }
            }
        }

        public Dreams()
        { 
        }

        public Dreams(string date, string text, string tag, bool star, bool fav)
        {
            Date = date;
            Text = text;
            Tag = tag;
            Star = star;
            Fav = fav;
        }

        public Dreams(string date, string text)
        {
            // TODO: Complete member initialization
            this.Date = date;
            this.Text = text;
        }
    }
}
