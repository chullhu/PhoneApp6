using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace PhoneApp6.Model
{
    public class Dreams
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int Id { get; set; }
        public string Date { get; set; }
        public string Text { get; set; }
        public bool Star { get; set; }
        public string Tag { get; set; }
        //Photo?

        public Dreams()
        {

        }

        public Dreams(string date, string text, bool star, string tag)
        {
            Date = DateTime.Now.ToString();
            Text = text;
            Star = star;
            Tag = tag;
        }
    }
}
