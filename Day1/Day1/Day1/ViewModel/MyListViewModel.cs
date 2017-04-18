using Day1.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Day1.Model
{
    public class MyListViewModel : ViewModelBase
    {
        public MyListViewModel()
        {
            Cards = new List<CardViewModel>();
        }

        public int Id { get; set; }

        public List<CardViewModel> Cards { get; set; }
        public string Title { get; set; }

        // innentől Viewmodel
        public bool IsLastPage { get; set; } = false;

        //Azért, hogy a validálást objektum.Errors hivatkozással
        //használni tudjuk, a kérdéses mezőt becsomagoljuk egy osztályba, de 
        //ez általában a Viewmodel maga, csak ez most egy bonyolult 
        //többképernyős ViewModel
        private NewList newList = new NewList();
        public NewList NewList
        {
            get { return newList; }
            set { SetProperty(value, ref newList); }
        }

        #region Kép megjelenítése és mentése segéd property-k és függvények

        private byte[] pictureAsByte;
        public byte[] PictureAsByte
        {
            get
            {
                return pictureAsByte;
            }
            set
            {
                pictureAsByte = value ?? new byte[0];
                //figyelem, kitölteni az ImageSource-t
                Picture = ImageSource.FromStream(
                    () => new MemoryStream(pictureAsByte)
                );
            }
        }

        #endregion Kép megjelenítése és mentése segéd property-k és függvények

        private ImageSource picture;
        /// <summary>
        /// A megjelenítést szolgáló property, ha kitöltjük
        /// a felületen megjelenik a kép
        /// </summary>
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
