using Day1.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Day1.Model
{
    public class MyList : ViewModelBase
    {
        public MyList()
        {
            Cards = new List<Card>();
        }

        public List<Card> Cards { get; set; }
        public string Title { get; set; }

        // innentől Viewmodel
        public bool IsLastPage { get; set; } = false;

        private NewList newList = new NewList();
        public NewList NewList
        {
            get { return newList; }
            set { SetProperty(value, ref newList); }
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
