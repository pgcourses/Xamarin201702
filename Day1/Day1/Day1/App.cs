using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Day1
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            var content = new ContentPage
            {
                Title = "Feljegyzések",

                Content = new StackLayout
                {
                    Children = {
                        new Label { Text = "Új feladat rögzítése!" },
                        new Entry { Placeholder = "A feladat leírása" },
                        new Picker { Title = "Fontosság", Items = { "Sürgős","Normál","Ráér" } },
                        new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            Children =
                            {
                                new Label { Text = "Határnap" },
                                new DatePicker { }
                            }
                        },
                        new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            Children =
                            {
                                new Label { Text = "Határidő" },
                                new TimePicker { }
                            }
                        },
                        new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            Children =
                            {
                                new Label { Text = "Elintézve" },
                                new Switch { IsToggled = false}
                            }
                        },
                        new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            Children =
                            {
                                new Button { Text = "Mégsem" },
                                new Button { Text = "Mentés"}
                            }
                        },

                    }
                }
            };

            MainPage = new NavigationPage(content);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
