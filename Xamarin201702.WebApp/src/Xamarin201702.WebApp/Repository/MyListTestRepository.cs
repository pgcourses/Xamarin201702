using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xamarin201702.WebApp.Repository
{
    public class MyListTestRepository : IMyListRepository
    {
        private readonly List<MyListRestApiModel> data = new List<MyListRestApiModel>();

        public MyListTestRepository()
        {
            var list = new MyListRestApiModel { Title = "Ez az első lista" };
            list.Cards = new List<CardRestApiModel> {
                    new CardRestApiModel { Title ="1. lista 1. bejegyzés", Description = "Ez a részletes bejegyzés az 1.lista 1. bejegyzéséhez" },
                    new CardRestApiModel { Title ="1. lista 2. bejegyzés", Description = "Ez a részletes bejegyzés az 1.lista 2. bejegyzéséhez" },
                    new CardRestApiModel { Title ="1. lista 3. bejegyzés", Description = "Ez a részletes bejegyzés az 1.lista 3. bejegyzéséhez" },
                    new CardRestApiModel { Title ="1. lista 4. bejegyzés", Description = "Ez a részletes bejegyzés az 1.lista 4. bejegyzéséhez" }
            };
            data.Add(list);
            
            list = new MyListRestApiModel { Title = "Ez a második lista" };
            list.Cards = new List<CardRestApiModel> {
                    new CardRestApiModel { Title ="2. lista 1. bejegyzés", Description = "Ez a részletes bejegyzés az 2.lista 1. bejegyzéséhez" },
                    new CardRestApiModel { Title ="2. lista 2. bejegyzés", Description = "Ez a részletes bejegyzés az 2.lista 2. bejegyzéséhez" },
                    new CardRestApiModel { Title ="2. lista 3. bejegyzés", Description = "Ez a részletes bejegyzés az 2.lista 3. bejegyzéséhez" },
                    new CardRestApiModel { Title ="2. lista 4. bejegyzés", Description = "Ez a részletes bejegyzés az 2.lista 4. bejegyzéséhez" }
            };
            data.Add(list);
        }

        public int AddList(MyListRestApiAddModel myList)
        {
            var restapimodel = new MyListRestApiModel
            {
                Id = data.Count + 1,
                Title = myList.Title,
                Picture = myList.Picture,
                Cards = myList.Cards
            };
            data.Add(restapimodel);
            return restapimodel.Id;
        }

        public IList<MyListRestApiModel> GetLists()
        {
            return data;
        }

        public void UpdateList(MyListRestApiModel mylist)
        {
            throw new NotImplementedException();
        }
    }
}
