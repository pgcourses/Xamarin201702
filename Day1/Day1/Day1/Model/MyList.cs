using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

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

        private ImageSource picture;
        public ImageSource Picture
        {
            get { return picture; }
            set { SetProperty(value, ref picture); }
        }

        private bool isHorizontal;
        public bool IsHorizontal
        {
            get { return isHorizontal; }
            set { SetProperty(value, ref isHorizontal); }
        }


        //Ha akarjuk, akkor az IsHorizontal setteréből átállíthatjuk ezeket a propertyket
        private int gridRow;
        public int GridRow
        {
            get { return gridRow; }
            set { SetProperty(value, ref gridRow); }
        }

        private int gridColumn;
        public int GridColumnt
        {
            get { return gridColumn; }
            set { SetProperty(value, ref gridColumn); }
        }


    }
}
