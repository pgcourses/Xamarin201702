using Day1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//felvesszük a xamarin futásidejű DI Containerébe ezt az osztályt
[assembly: Xamarin.Forms.Dependency(typeof(MyListTestRepository)) ]
namespace Day1.Model
{
    public class MyListTestRepository : IMyListRepository
    {
        public IList<MyList> GetLists()
        {
            return new ObservableCollection<MyList>
            {
                new MyList {
                    Title ="Ez az első lista",
                    Cards =new List<Card> {
                    new Card { Title ="1. lista 1. bejegyzés", Description = "Ez a részletes bejegyzés az 1.lista 1. bejegyzéséhez" },
                    new Card { Title ="1. lista 2. bejegyzés", Description = "Ez a részletes bejegyzés az 1.lista 2. bejegyzéséhez" },
                    new Card { Title ="1. lista 3. bejegyzés", Description = "Ez a részletes bejegyzés az 1.lista 3. bejegyzéséhez" },
                    new Card { Title ="1. lista 4. bejegyzés", Description = "Ez a részletes bejegyzés az 1.lista 4. bejegyzéséhez" },
                    new Card { Title ="1. lista 5. bejegyzés", Description = "Ez a részletes bejegyzés az 1.lista 5. bejegyzéséhez" },
                    new Card { Title ="1. lista 6. bejegyzés", Description = "Ez a részletes bejegyzés az 1.lista 6. bejegyzéséhez" }
                } },
                new MyList {
                    Title ="Ez a második lista",
                    Cards =new List<Card> {
                    new Card { Title ="2. lista 1. bejegyzés", Description = "Ez a részletes bejegyzés az 2.lista 1. bejegyzéséhez" },
                    new Card { Title ="2. lista 2. bejegyzés", Description = "Ez a részletes bejegyzés az 2.lista 2. bejegyzéséhez" },
                    new Card { Title ="2. lista 3. bejegyzés", Description = "Ez a részletes bejegyzés az 2.lista 3. bejegyzéséhez" }
                } },

                //Innentől ViewModel
                new MyList {
                    Title ="Új lista rögzítése",
                    IsLastPage = true
                },
            };
        }
    }
}
