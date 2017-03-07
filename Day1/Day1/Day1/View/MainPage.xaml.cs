using Day1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

/// <summary>
///  model -> ItemSource
///                      ------> DataTemplate -> Binding -> megjelenítés
///                      ------> DataTemplate -> Binding
///                      ------> DataTemplate -> Binding
///                      ------> DataTemplate -> Binding
/// 
/// </summary>


namespace Day1.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public MainPage(IList<MyList> model)
            : this()
        {
            ItemsSource = model;
        }

        private void btnSave_Clicked(object sender, EventArgs e)
        {
            //Melyik lapon vagyunk:
            //CurrentPage
            //Hányadik lapon vagyunk (-1)
            //Children.IndexOf(CurrentPage)
            var model = ItemsSource as IList<MyList>;
            if (model == null)
            {
                //throw new ArgumentException(nameof(model));
                return;
            }
            
            //Megkeressük az oldalunknak megfelelő viewmodel elemet
            var pageIndex = Children.IndexOf(CurrentPage);

            //töröljük a beviteli mezőt

            //felvisszük az új listaelemet
            model.Insert(pageIndex, new MyList { Title = model[pageIndex].NewListName });
            model[pageIndex+1].NewListName = string.Empty;
            InvalidateMeasure();

            //ráállunk az újonnan felvitt listaelemre
            CurrentPage = Children[pageIndex];



        }

        private void btnCancel_Clicked(object sender, EventArgs e)
        {
            var model = ItemsSource as IList<MyList>;
            if (model == null)
            {
                //throw new ArgumentException(nameof(model));
                return;
            }
            var pageIndex = Children.IndexOf(CurrentPage);
            model[pageIndex].NewListName = string.Empty;
            if (pageIndex>0)
            {
                CurrentPage = Children[pageIndex - 1];
            }
        }
    }
}
