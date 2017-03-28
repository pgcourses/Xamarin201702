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

            if (Device.Idiom != TargetIdiom.Tablet)
            {
                //Ezt csak akkor, ha nem tableten vagyunk
                IsPresented = false;
            }

            var selectedItem = e.SelectedItem as MainMenuItem;
            if (selectedItem == null) { return; }

            var page = (Page)Activator.CreateInstance(selectedItem.PageType);

            Detail = new NavigationPage(page);

            mainMenuListView.SelectedItem = null;


        }
    }
}
