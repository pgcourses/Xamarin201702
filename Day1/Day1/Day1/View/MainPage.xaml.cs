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
/// </summary>


namespace Day1.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            var asmn = new AssemblyName(typeof(App).GetTypeInfo().Assembly.FullName);
            Title = asmn.Version.ToString();
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
            model.Add(new MyList { Title = model[pageIndex].NewListName });

            //majd megcseréljük az utolsó két elemet
            var tmp = model[pageIndex + 1];
            model[pageIndex + 1] = model[pageIndex];
            model[pageIndex] = tmp;

            //A beviteli mezőt kiürítjük
            model[pageIndex + 1].NewListName = string.Empty;

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
