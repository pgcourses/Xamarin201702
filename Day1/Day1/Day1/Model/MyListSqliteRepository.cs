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

/// <summary>
/// A használt sqlite csomag (sqlite-net-pcl) az 1.3.1-es verzióban vezette be a .NET Standard támogatást.
/// http://stackoverflow.com/questions/42220017/impossible-to-install-sqlite-net-pcl-in-xamarin
/// 
/// Ha nem akarunk ilyen bonyodalmat, akkor érdemes megmaradni az 1.2.1-es változatnál.
/// 
/// Az adatelérésre két megoldás van:
/// 
/// SQLite.NET (Ezt használjuk most) 
/// https://developer.xamarin.com/guides/android/application_fundamentals/data/part_3_using_sqlite_orm/
/// sqlite-net-pcl nuget csomag
/// https://www.nuget.org/packages/sqlite-net-pcl/
/// https://github.com/praeclarum/sqlite-net
/// 
/// 
/// vagy ADO.NET, ezt nem próbáljuk most ki
/// https://developer.xamarin.com/guides/ios/application_fundamentals/data/part_4_using_adonet/
/// https://developer.xamarin.com/guides/android/application_fundamentals/data/part_4_using_adonet/
/// </summary>


[assembly: Xamarin.Forms.Dependency(typeof(MyListSqliteRepository))]
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
            connection.CreateTable<CardModel>(); //Ez innentől nem megy, mert túl bonyolult a modell, majd javítjuk
            connection.CreateTable<MyListModel>();

            if (connection.Table<MyListModel>().Count() == 0)
            { //tesztadatokkal feltöltés csak, ha nincs még benne rekord
                var myList = new MyListModel { Title = "Ez az első lista" };
                connection.Insert(myList); //Itt kiírjuk ezt a rekordot, és az sqlite.net kitölti az Id-t

                connection.Insert(
                    new CardModel
                    {
                        Title = "1. lista 1. bejegyzés",
                        Description = "Ez a részletes bejegyzés az 1.lista 1. bejegyzéséhez",
                        MyListId = myList.Id
                    });

                connection.Insert(
                    new CardModel
                    {
                        Title = "1. lista 2. bejegyzés",
                        Description = "Ez a részletes bejegyzés az 1.lista 2. bejegyzéséhez",
                        MyListId = myList.Id
                    });

                connection.Insert(
                    new CardModel
                    {
                        Title = "1. lista 3. bejegyzés",
                        Description = "Ez a részletes bejegyzés az 1.lista 3. bejegyzéséhez",
                        MyListId = myList.Id
                    });

                connection.Insert(
                    new CardModel
                    {
                        Title = "1. lista 4. bejegyzés",
                        Description = "Ez a részletes bejegyzés az 1.lista 4. bejegyzéséhez",
                        MyListId = myList.Id
                    });

                connection.Insert(
                    new CardModel
                    {
                        Title = "1. lista 5. bejegyzés",
                        Description = "Ez a részletes bejegyzés az 1.lista 5. bejegyzéséhez",
                        MyListId = myList.Id
                    });

                connection.Insert(
                    new CardModel
                    {
                        Title = "1. lista 6. bejegyzés",
                        Description = "Ez a részletes bejegyzés az 1.lista 6. bejegyzéséhez",
                        MyListId = myList.Id
                    });

                myList = new MyListModel { Title = "Ez a második lista" };
                connection.Insert(myList); //Itt kiírjuk ezt a rekordot, és az sqlite.net kitölti az Id-t

                connection.Insert(
                    new CardModel
                    {
                        Title = "2. lista 1. bejegyzés",
                        Description = "Ez a részletes bejegyzés az 1.lista 1. bejegyzéséhez",
                        MyListId = myList.Id
                    });

                connection.Insert(
                    new CardModel
                    {
                        Title = "2. lista 2. bejegyzés",
                        Description = "Ez a részletes bejegyzés az 1.lista 2. bejegyzéséhez",
                        MyListId = myList.Id
                    });

                connection.Insert(
                    new CardModel
                    {
                        Title = "2. lista 3. bejegyzés",
                        Description = "Ez a részletes bejegyzés az 1.lista 3. bejegyzéséhez",
                        MyListId = myList.Id
                    });

                connection.Insert(
                    new CardModel
                    {
                        Title = "Felhívni Jánost",
                        Description = "06 1 1234567",
                        IsPhoneCallCard = true,
                        MyListId = myList.Id
                    });

            }
        }

        //Ennek a jó megoldása az AutoMapper használata
        //ld. C# nagyoknak tanfolyam

        public void AddList(MyListViewModel myListViewmodel)
        {
            //Konvertálni MyListViewModel-ről MyListModel-re

            var myListModel = new MyListModel
            {
                Title = myListViewmodel.Title
            };
            connection.Insert(myListModel); //Elmentettük, van Id-nk

            //Figyelem, lehetnek Card-ok a MyList-en
            foreach (var card in myListViewmodel.Cards)
            {
                connection.Insert(new CardModel
                {
                    Title = card.Title,
                    Description = card.Description,
                    IsPhoneCallCard = card.IsPhoneCallCard,
                    MyListId = myListModel.Id
                });
            }
        }

        public IList<MyListViewModel> GetLists()
        { 
            var listMyListModel = connection.Table<MyListModel>().ToList();
            //Konvertálni MyListModel-ről MyListViewModel-re

            //Ehhez kell a Cards tábla is 
            var listCardModel = connection.Table<CardModel>().ToList();

            var listMyListViewModel = listMyListModel.Select( // végigmegyünk minden elemen és példányosítunk ez alapján ViewModelt
                                                            l => new MyListViewModel {
                                                                Title = l.Title,
                                                                Cards = listCardModel.Where(c => c.MyListId == l.Id)
                                                                                     .Select( //Viewmodelt készítünk minden CardModel-ből
                                                                                        c=> new CardViewModel
                                                                                        {
                                                                                            Title = c.Title,
                                                                                            Description = c.Description,
                                                                                            IsPhoneCallCard = c.IsPhoneCallCard
                                                                                        })
                                                                                     .ToList()
                                                            })
                                                     .ToList();

            //Ahhoz, hogy a ViewModel-lünk teljes legyen, kell még egy utolsó oldal
            listMyListViewModel.Add(
                            new MyListViewModel
                            {
                                Title = "Új lista rögzítése",
                                IsLastPage = true
                            });


            return new ObservableCollection<MyListViewModel>(listMyListViewModel);
        }
    }
}
