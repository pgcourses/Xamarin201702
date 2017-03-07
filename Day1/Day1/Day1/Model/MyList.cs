using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1.Model
{
    public class MyList
    {
        public MyList()
        {
            Cards = new List<Card>();
        }

        public List<Card> Cards { get; set; }
        public string Title { get; set; }

        // innentől Viewmodel
        public bool IsLastPage { get; set; } = false;
        public string NewListName { get; set; }
    }
}
