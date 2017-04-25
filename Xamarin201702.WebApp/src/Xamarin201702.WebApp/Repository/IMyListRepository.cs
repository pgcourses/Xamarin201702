using System.Collections.Generic;

namespace Xamarin201702.WebApp
{
    public interface IMyListRepository
    {
        IList<MyListRestApiModel> GetLists();
        void AddList(MyListRestApiModel myList);
        void UpdateList(MyListRestApiModel mylist);
    }
}