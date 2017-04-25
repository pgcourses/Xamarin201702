using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xamarin201702.WebApp.Repository
{
    public class MyListTestRepository : IMyListRepository
    {
        private readonly List<MyListRestApiModel> data = new List<MyListRestApiModel>();

        public void AddList(MyListRestApiModel myList)
        {
            throw new NotImplementedException();
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
