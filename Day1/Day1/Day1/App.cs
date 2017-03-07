using Day1.Model;
using Day1.View;
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
            //Ezt a direkt hivatkozást lecseréljük egy DI indirekcióra
            //var repo = new MyListTestRepository();
            // The root page of your application

            //A DI szerviz segítségével példányosítunk egy példányt ezzel a felülettel.
            var repo = DependencyService.Get<IMyListRepository>();
            MainPage = new NavigationPage(new MainPage(repo.GetLists()));

            //MainPage = new NavigationPage(new TabbedTaskPage());
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
