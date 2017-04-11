using Day1.Model;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
/// 
/// Binding:
///        BindingContext
///        BindingSource
///        BindingTarget
///        BindingExpression
///        
/// 
/// Reagálás az eszköz helyzetésre (álló vagy fekvő)
/// 
///    Ehelyett
///    ------------------------------
///    |     Gomb Kép               |
///    ------------------------------
///    |     Listanézet             |
///    ------------------------------
/// 
/// 
///    Ez:
///    --------------------------------------------------
///    |     Gomb Kép               |                   |
///    --------------------------------------------------
///    |     Listanézet             |  Gomb Kép         |
///    --------------------------------------------------

///    Álló 
///    -------------------------------
///    |     Gomb Kép               ||
///    -------------------------------
///    |     Listanézet             ||
///    -------------------------------
///    Fekvő:
///    --------------------------------------------------
///    |                            |                   |
///    --------------------------------------------------
///    |     Listanézet             |  Gomb Kép         |
///    --------------------------------------------------
/// 
/// </summary>





namespace Day1.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoList : TabbedPage
    {
        public TodoList()
        {
            InitializeComponent();
            //A DI szerviz segítségével példányosítunk egy példányt ezzel a felülettel.
            var repo = DependencyService.Get<IMyListRepository>();
            ItemsSource=repo.GetLists();
            SizeChanged += TodoList_SizeChanged;
        }

        private void TodoList_SizeChanged(object sender, EventArgs e)
        { //Az Álló/Fekvő tulajdonság ilyenkor változhat, amikor ez az eseménykezelő lefut

            //Fekvő: Width>Height
            //egyébként Álló (Width<=Height)
            //Tehát itt érdemes jelezni, ha megváltozik az elrendezés
            //Itt tudjuk írni a viewmodel-t, hogy reflektáljon a változásra

            //var l = SelectedItem as MyList;
            //if (null==l)
            //{
            //    throw new ArgumentNullException("l");
            //}

            //l.IsHorizontal = Width > Height;

            var vm = ItemsSource as IList<MyList>;
            if (null == vm)
            {
                throw new ArgumentNullException("vm");
            }

            foreach (var ml in vm)
            {
                ml.IsHorizontal = Width > Height;
            }

        }

        //Például így lehet egy tulajdonságot gyártani, ami 
        //visszaadja, hogy az adott oldal álló vagy fekvő
        public bool IsHorizontal { get { return Width > Height; } }

        //public TodoList(IList<MyList> model)
        //    : this()
        //{
        //    ItemsSource = model;
        //}

        private async void btnSave_Clicked(object sender, EventArgs e)
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

            var mylist = SelectedItem as MyList;
            if (!mylist.NewList.IsValid())
            {
                //akkor üzenni, hogy nem lehet elmenteni
                await DisplayAlert("Érvénytelen adatok", "A bevitt adatok nem felelnek meg!", "Rendben");
                return;
            }

            //Az aktuális lap adatforrása:
            //var list = SelectedItem as MyList;
            //if (list == null)
            //{
            //    return;
            //}

            //Megkeressük az oldalunknak megfelelő viewmodel elemet
            var pageIndex = Children.IndexOf(CurrentPage);

            //töröljük a beviteli mezőt

            //felvisszük az új listaelemet a végére
            model.Add(new MyList { Title = model[pageIndex].NewList.NewListName });

            //majd megcseréljük az utolsó két elemet
            var tmp = model[pageIndex + 1];
            model[pageIndex + 1] = model[pageIndex];
            model[pageIndex] = tmp;

            //A beviteli mezőt kiürítjük
            model[pageIndex + 1].NewList.NewListName = string.Empty;

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
            model[pageIndex].NewList.NewListName = string.Empty;
            if (pageIndex>0)
            {
                CurrentPage = Children[pageIndex - 1];
            }
        }

        private void btnAddnewCard_Clicked(object sender, EventArgs e)
        {

        }

        private async void btnGetPicture_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(
                new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "Sample",
                    Name = "test.jpg"
                });

            if (file == null)
                return;

            await DisplayAlert("File Location", file.Path, "OK");

            var mylist = SelectedItem as MyList;

            if (mylist==null)
            {
                //todo: ez biztosan hiba, throw!
                return;
            }

            //mylist.Picture = ImageSource.FromStream(() =>
            //{
            //    var stream = file.GetStream();
            //    stream.Position = 0;
            //    var memstream = new MemoryStream();
            //    stream.CopyTo(memstream);
            //    memstream.Position = 0; //enélkül nem mutatja meg a képet
            //    file.Dispose();
            //    //return stream;
            //    return memstream;
            //});

            mylist.Picture = ImageSource.FromFile(file.Path);

        }

        //private void btnPhoneCall_Clicked(object sender, EventArgs e)
        //{

        //}
    }
}
