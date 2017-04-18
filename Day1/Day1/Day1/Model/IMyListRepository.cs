using System.Collections.Generic;

namespace Day1.Model
{
    public interface IMyListRepository
    {
        IList<MyListViewModel> GetLists();
        void AddList(MyListViewModel myList);
        void SavePicture(MyListViewModel mylist);
    }
}