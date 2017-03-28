using Day1.Model;
using Day1.View;
using Day1.View.MainMenu;
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
            //var repo = DependencyService.Get<IMyListRepository>();
            //MainPage = new NavigationPage(new MainPage(repo.GetLists()));

            //A Master/Detail oldalt nem navigációs oldalként kell betölteni
            //MainPage = new NavigationPage(new MainMenu());

            MainPage = new MainMenu();

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
