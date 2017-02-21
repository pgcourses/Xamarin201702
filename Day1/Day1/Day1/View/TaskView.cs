using Day1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Day1.View
{
    public class TaskView : ContentPage
    {
        Entry entryTitle = new Entry { Placeholder = "A feladat leírása" };
        Picker pickerPriority = new Picker { Title = "Fontosság", Items = { "Ráér", "Normál", "Sürgős" } };
        DatePicker dueDate = new DatePicker { };
        TimePicker dueTime = new TimePicker { };
        Switch switchSolved = new Switch { IsToggled = false };
        Button btnCancel = new Button { Text = "Mégsem" };
        Button btnSave = new Button { Text = "Mentés" };
        Button btnList = new Button { Text = "Lista" };

        TaskViewModel vm;

        List<TaskViewModel> list = new List<TaskViewModel>();

        /// <summary>
        /// MVVM: Model, View, ViewModel hármasának egysége
        /// Model: adatok elérése, létrehozása, kezelése
        /// View: a megtekintés, ami a felhasználó számára megjelenik vizuálisan
        /// ViewModel: ami ezt a kettőt összeköti. Gyakorlatilag egyfajta üzleti logikának is lehet gondolni
        /// </summary>

        public TaskView()
        {
            btnCancel.Clicked += btnCancel_Clicked;
            btnSave.Clicked += btnSave_Clicked;
            btnList.Clicked += btnList_Clicked;

            ResetData();

            Content = new StackLayout
            {
                Children = {
                        new Label { Text = "Új feladat rögzítése!" },
                        entryTitle,
                        pickerPriority,
                        new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            Children =
                            {
                                new Label { Text = "Határnap" },
                                dueDate
                            }
                        },
                        new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            Children =
                            {
                                new Label { Text = "Határidő" },
                                dueTime
                            }
                        },
                        new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            Children =
                            {
                                new Label { Text = "Elintézve" },
                                switchSolved
                            }
                        },
                        new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            Children =
                            {
                                btnCancel,
                                btnSave,
                                btnList
                            }
                        },
                    }
            };
        }

        private void btnList_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TaskListView(list));
        }

        private void btnSave_Clicked(object sender, EventArgs e)
        {
            var date = dueDate.Date;
            var time = dueTime.Time;
            list.Add(new TaskViewModel {
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
    }
}
