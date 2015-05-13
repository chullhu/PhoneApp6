using PhoneApp6.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApp6.ViewModel
{
    class ReadAllDreams
    {
        DBHelperClass_Dreams db_help = new DBHelperClass_Dreams();
        public ObservableCollection<Dreams> getAllDreams()
        {
            return db_help.ReadDreams();
        }
    }
}
