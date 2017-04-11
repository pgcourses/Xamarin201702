using Day1.Data;
using Day1.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

//[assembly: Xamarin.Forms.Dependency(typeof(MyListSqliteRepository))]
namespace Day1.Model
{
    public class MyListSqliteRepository : IMyListRepository
    {
        SQLiteConnection connection;
        public MyListSqliteRepository()
        {
            var dbpath = DependencyService.Get<IFileService>().GetLocalPath("MylistDB.db3");
            //database = new SqliteDatabase(dbpath);
            connection = new SQLiteConnection(dbpath);
            connection.CreateTable<Card>(); //Ez innentől nem megy, mert túl bonyolult a modell, majd javítjuk
            connection.CreateTable<MyList>();

            if (connection.Table<MyList>().Count() == 0)
            {
                connection.Insert(new MyList
                {
                    Title = "Ez az első lista",
                    Cards = new List<Card> {
                        new Card { Title ="1. lista 1. bejegyzés", Description = "Ez a részletes bejegyzés az 1.lista 1. bejegyzéséhez" },
                        new Card { Title ="1. lista 2. bejegyzés", Description = "Ez a részletes bejegyzés az 1.lista 2. bejegyzéséhez" },
                        new Card { Title ="1. lista 3. bejegyzés", Description = "Ez a részletes bejegyzés az 1.lista 3. bejegyzéséhez" },
                        new Card { Title ="1. lista 4. bejegyzés", Description = "Ez a részletes bejegyzés az 1.lista 4. bejegyzéséhez" },
                        new Card { Title ="1. lista 5. bejegyzés", Description = "Ez a részletes bejegyzés az 1.lista 5. bejegyzéséhez" },
                        new Card { Title ="1. lista 6. bejegyzés", Description = "Ez a részletes bejegyzés az 1.lista 6. bejegyzéséhez" }
                    }
                });
            }
        }

        public void AddList(MyList myList)
        {
            connection.Insert(myList);
        }

        public IList<MyList> GetLists()
        {
            var list = connection.Table<MyList>().ToList();
            return new ObservableCollection<MyList>(list);
        }
    }
}
