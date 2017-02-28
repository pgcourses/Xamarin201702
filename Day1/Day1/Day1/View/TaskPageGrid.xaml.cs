using Day1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Day1.View
{
    public partial class TaskPageGrid : ContentPage
    {
        private TaskViewModel vm;
        List<TaskViewModel> list = new List<TaskViewModel>();
        public TaskPageGrid()
        {
            InitializeComponent();
            ResetData();
        }

        private void ResetData()
        {
            vm = new TaskViewModel();
            vm.Due = DateTime.Now;

            entryTitle.Text = vm.Title;
            pickerPriority.SelectedIndex = vm.Priority;
            dueDate.Date = vm.Due.Date;
            dueTime.Time = vm.Due.TimeOfDay;
            switchSolved.IsToggled = vm.IsSolved;
        }

        private void btnList_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TaskListPage(list));
        }

        private void btnSave_Clicked(object sender, EventArgs e)
        {
            var date = dueDate.Date;
            var time = dueTime.Time;
            list.Add(new TaskViewModel
            {
                Title = entryTitle.Text,
                Priority = pickerPriority.SelectedIndex,
                Due = new DateTime(date.Year, date.Month, date.Day, time.Hours, time.Minutes, time.Seconds),
                IsSolved = switchSolved.IsToggled
            });

            ResetData();
        }

        private void btnCancel_Clicked(object sender, EventArgs e)
        {
            ResetData();
        }

    }
}
