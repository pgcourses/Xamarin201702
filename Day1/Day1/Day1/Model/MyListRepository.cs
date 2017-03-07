using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1.Model
{
    public class MyListRepository
    {
        public IList<MyList> GetLists()
        {
            return new List<MyList>
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
                    new Card { Title ="2. lista 3. bejegyzés", Description = "Ez a részletes bejegyzés az 2.lista 3. bejegyzéséhez" },
                } },
            };
        }
    }
}
