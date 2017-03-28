using Day1.Model;
using Day1.View.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Day1.View.MainMenu
{

    /// <summary>
    /// MasterDetailPage:
    /// 
    /// 
    /// MasterDetailPage
    ///         Master (Tulajdonság, aminek a típusa Page)
    ///             (Amennyiben itt történik valami, a Detail tulajdonság 
    ///             átállításával betölthetjük a megfelelő képernyőt)
    /// 
    ///         Detail (Tulajdonság, aminek a típusa NavigationPage, kötelező a Title kitöltése)
    /// 
    /// 
    /// Alkalmazkodik a Telefon/Tablet/Desktop megjelenítéshez, a menü telefonon tűnik el.
    /// </summary>

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenu : MasterDetailPage
    {
        public MainMenu()
        {
            InitializeComponent();
            BindingContext = new MainMenuModel();
            Detail = new NavigationPage(new About());
        }

        private void mainMenuListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedItem = e.SelectedItem as MainMenuItem;
            if (selectedItem == null) { return; }

            NavigateTo(selectedItem);

        }

        /// <summary>
        /// Itt érdemes elgondolkodni azon, hogy hogy lehetne ezt 
        /// gyorsítótárazni
        /// </summary>
        /// <param name="selectedItem"></param>
        private void NavigateTo(MainMenuItem selectedItem)
        {
            if (Detail!=null)
            {
                if (Device.Idiom != TargetIdiom.Tablet)
                {
                    //Ezt csak akkor, ha nem tableten vagyunk
                    IsPresented = false;
                }

                
                if (Device.OS == TargetPlatform.Android)
                {//Az adndroidon oldalváltások között érdemes várni 300ms-ot
                    Task.Delay(300);
                }
            }

            //Amennyiben típusokat használunk a viewmodel-ben, akkor így példányosítunk
            var page = (Page)Activator.CreateInstance(selectedItem.PageType);

            //ha func-cal factory-t csinálunk, akkor pedig így:
            //var page = selectedItem.GetPage();

            Detail = new NavigationPage(page);
            mainMenuListView.SelectedItem = null;
        }
    }
}
