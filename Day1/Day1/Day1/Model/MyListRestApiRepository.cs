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

[assembly: Xamarin.Forms.Dependency(typeof(MyListRestApiRepository)) ]
namespace Day1.Model
{
    public class MyListRestApiRepository : IMyListRepository
    {
        private readonly RestClient client;

        public MyListRestApiRepository()
        {
            //ez így egy "Error: ConnectFailure (Connection refused)" hibával elszáll
            //A mobil emulátor localhost-ja nem a gép localhost-ja, így meg kell adni az IP címet, 
            //hogy tesztelni tudjuk a saját api-nkat
            //valamint, az IIS Express alapértelmezésben a localhost-ról jövő kérésekre korlátozza a 
            //kiszolgálást, így át kell állni a Webalkalmazásban Kestrel-re, hogy ezt könnyen átugorjuk
            client = new RestSharp.Portable.HttpClient.RestClient("http://192.168.0.201:5000/api");
        }


        public void AddList(MyListViewModel myList)
        {
            //var request = new RestSharp.Portable.RestRequest("MyList", RestSharp.Portable.Method.POST);

            //request.Parameters.Add

            ////elkészítjük a végrehajtó műveletet
            //var task = client.Execute<List<MyListRestApiModel>>(request);
        }

        public IList<MyListViewModel> GetLists()
        {
            //felparaméterezzük a kérést
            var request = new RestSharp.Portable.RestRequest("MyList", RestSharp.Portable.Method.GET);

            //elkészítjük a végrehajtó műveletet
            var task = client.Execute<List<MyListRestApiModel>>(request);

            //Ha kivétel történik, akkor kérjük a részleteket
            try
            {
                //lefuttatjuk a saját szálunkon és megvárjuk a végét, majd a végeredményből
                //a JSON szövegből visszaalakított List<MyListRestApiModel> példányt elkérjük
                var list = task.Result.Data;  //Mindig a Data tartalmazza a példányosított objektumot, amit a JSON-ből gyárt a restSharp

                var listMyListViewModel = list.Select( // végigmegyünk minden elemen és példányosítunk ez alapján ViewModelt
                                                    restapimodel => new MyListViewModel
                                                    {
                                                        Id = restapimodel.Id,
                                                        Title = restapimodel.Title,
                                                        PictureAsByte = restapimodel.Picture,
                                                        Cards = restapimodel.Cards
                                                                            .Select( //Viewmodelt készítünk minden CardModel-ből
                                                                                c => new CardViewModel
                                                                                {
                                                                                    Title = c.Title,
                                                                                    Description = c.Description,
                                                                                })
                                                                            .ToList()
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
            catch (Exception ex)
            {

                throw;
            }
        }

        public void UpdateList(MyListViewModel mylist)
        {
            throw new NotImplementedException();
        }
    }
}
