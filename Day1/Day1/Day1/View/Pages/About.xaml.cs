using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Day1.View.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class About : ContentPage
    {
        public About()
        {
            InitializeComponent();
            var asmn = new AssemblyName(typeof(App).GetTypeInfo().Assembly.FullName);
            labelVersion.Text = asmn.Version.ToString();
        }
    }
}
