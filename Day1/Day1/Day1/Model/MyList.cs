using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1.Model
{
    public class MyList : BaseViewModel
    {
        public MyList()
        {
            Cards = new List<Card>();
        }

        public List<Card> Cards { get; set; }
        public string Title { get; set; }

        // innentől Viewmodel
        public bool IsLastPage { get; set; } = false;

        

        private string newListName;
        public string NewListName
        {
            get
            {
                return newListName;
            }
            set
            {
                //A BaseViewModel-ben lévő CallerMemberName miatt
                //egy ilyen sorral helyettesít majd a FORDÍTÓ
                //SetProperty(value, ref newListName, nameof(NewListName));
                SetProperty(value, ref newListName);
            }
        }
    }
}
