using PhoneApp6.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApp6.ViewModel
{
    public class DBHelperClass_Dreams
    {
        SQLiteConnection dbConn;

        /// <summary>
        /// Create Table Dreams
        /// </summary>
        /// <param name="DB_PATH"></param>
        /// <returns></returns>
        public async Task<bool> onCreate(string DB_PATH)
        {
            try
            {
                if (!CheckFileExists(DB_PATH).Result)
                {
                    using (dbConn = new SQLiteConnection(DB_PATH))
                    {
                        dbConn.CreateTable<Dreams>();
                    }
                }
                return true;
            }

            catch
            {
                return false;
            }
        }

        public async Task<bool> CheckFileExists(string fileName)
        {
            try
            {
                var store = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                return true;
            }

            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Получение записи из таблицы Dreams
        /// </summary>
        /// <param name="dreamid"></param>
        /// <returns></returns>
        public Dreams ReadDream(int dreamid)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                var existingDream = dbConn.Query<Dreams>("select * from Dreams where Id =" + dreamid).FirstOrDefault();
                return existingDream;
            }
        }


        /// <summary>
        /// Получение всех записей из таблицы Dreams
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Dreams> ReadDreams()
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                List<Dreams> myCollection = dbConn.Table<Dreams>().ToList<Dreams>();
                ObservableCollection<Dreams> DreamsList = new ObservableCollection<Dreams>(myCollection);

                return DreamsList;
            }
        }

        /// <summary>
        /// Обновление выбранной записи
        /// </summary>
        /// <param name="dreams"></param>
        public void UpdateDream(Dreams dreams)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                var existingDream = dbConn.Query<Dreams>("select * from Dreams where Id =" + dreams.Id).FirstOrDefault();

                if (existingDream != null)
                {
                    existingDream.Date = dreams.Date;
                    existingDream.Text = dreams.Text;
                    existingDream.Star = dreams.Star;
                    existingDream.Tag = dreams.Tag;
                    dbConn.RunInTransaction(() =>
                    {
                        dbConn.Update(existingDream);
                    });
                }
            }
        }

        /// <summary>
        /// Извлечение новой записи из таблицы Dreams
        /// </summary>
        /// <param name="newDream"></param>
        public void Insert(Dreams newDream)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                dbConn.RunInTransaction(() =>
                {
                    dbConn.Insert(newDream);
                });
            }
        }

        /// <summary>
        /// Удаление выбранной записи
        /// </summary>
        /// <param name="Id"></param>
        public void DeleteDream(Dreams Id)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                var existingDream = dbConn.Query<Dreams>("select * from Dreams where Id =" + Id).FirstOrDefault();
                if (existingDream != null)
                {
                    dbConn.RunInTransaction(() =>
                    {
                        dbConn.Delete(existingDream);
                    });
                }
            }
        }

        /// <summary>
        /// Удаление таблицы
        /// </summary>
        public void DeleteAllDreams()
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                dbConn.DropTable<Dreams>();
                dbConn.CreateTable<Dreams>();
                dbConn.Dispose();
                dbConn.Close();
            }
        }
    }
}
