using Day1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

/// <summary>
/// 
/// 
///                                                 Listanézet
///         Adatforrás: List<T>            |----------------------------|
///                       T                |                            |
///                                        |----------------------------|
///                       T --DataBinding->| T.Property | T.Property    | 
///                       T                |                            | 
///                       T                |                            | 
///                                        |                            | 
///                                        |                            | 
/// 
/// </summary>




namespace Day1.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskListPage : ContentPage
    {
        public TaskListPage(List<TaskViewModel> vm)
        {
            InitializeComponent();
            lvwTaskList.ItemsSource = vm;
        }
    }
}
