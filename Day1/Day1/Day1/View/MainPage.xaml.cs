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
    }
}
