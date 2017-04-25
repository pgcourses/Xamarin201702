using Day1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Portable.HttpClient;
using System.Collections.ObjectModel;

/// <summary>
///                                                                                                   | MyListTestRepository (LIST)
///                                                                                                   |
///  | Felület (XAML) | <----> [ViewModel] <------- [IMyListRepository]  <---- Dependency Service <-- | MyListSqliteRepository (Sqlight db)
///                                                                                                   |
///                                                                                                   | MyListRestApiRepository <-----HTTP----- [WebApi] 
/// 
/// 
/// 
/// 
/// 
/// </summary>





//[assembly: Xamarin.Forms.Dependency(typeof(MyListRestApiRepository)) ]
namespace Day1.Model
{
    public class MyListRestApiRepository : IMyListRepository
    {
        private readonly RestClient client;

        public MyListRestApiRepository()
        {
            client = new RestSharp.Portable.HttpClient.RestClient("http://localhost:1000/api/");
        }


        public void AddList(MyListViewModel myList)
        {
            throw new NotImplementedException();
        }

        public IList<MyListViewModel> GetLists()
        {
            //felparaméterezzük a kérést
            var request = new RestSharp.Portable.RestRequest("MyList", RestSharp.Portable.Method.GET);

            //elkészítjük a végrehajtó műveletet
            var task = client.Execute<List<MyListRestApiModel>>(request);

            //lefuttatjuk a saját szálunkon és megvárjuk a végét, majd a végeredményből
            //a JSON szövegből visszaalakított List<MyListRestApiModel> példányt elkérjük
            var list = task.Result.Data;  //Mindig a Data tartalmazza a példányosított objektumot, amit a JSON-ből gyárt a restSharp

            var listMyListViewModel = list.Select( // végigmegyünk minden elemen és példányosítunk ez alapján ViewModelt
                                                restapimodel => new MyListViewModel
                                                {
                                                    Id = restapimodel.Id,
                                                    Title = restapimodel.Title,
                                                    PictureAsByte = restapimodel.Picture,
                                                })
                                          .ToList();

            //Ahhoz, hogy a ViewModel-lünk teljes legyen, kell még egy utolsó oldal
            listMyListViewModel.Add(
                            new MyListViewModel
                            {
                                Id = -1,
                                Title = "Új lista rögzítése",
                                IsLastPage = true
                            });


            return new ObservableCollection<MyListViewModel>(listMyListViewModel);
        }

        public void UpdateList(MyListViewModel mylist)
        {
            throw new NotImplementedException();
        }
    }
}
