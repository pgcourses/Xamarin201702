using System.Collections.Generic;

namespace Xamarin201702.WebApp
{
    public interface IMyListRepository
    {
        IList<MyListRestApiModel> GetLists();
        int AddList(MyListRestApiAddModel myList);
        void UpdateList(MyListRestApiModel mylist);
    }
}