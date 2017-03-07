using System.Collections.Generic;

namespace Day1.Model
{
    public interface IMyListRepository
    {
        IList<MyList> GetLists();
    }
}