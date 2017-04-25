using Day1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Portable.HttpClient;
using System.Collections.ObjectModel;
using RestSharp.Portable;

/// <summary>
///                                                                                                   | MyListTestRepository (LIST)
///                                                                                                   |
///  | Felület (XAML) | <----> [ViewModel] <------- [IMyListRepository]  <---- Dependency Service <-- | MyListSqliteRepository (Sqlight db)
///                                                                                                   |
///                                                                                                   | MyListRestApiRepository <-----HTTP----- [WebApi] 
/// 
/// 
/// 
///  Bejelentkezés és azonosítás a RestAPI használata közben: JWT (JSON Web Token)
///  https://tools.ietf.org/html/rfc6750#section-1.2
///  https://jwt.io/
///  https://auth0.com/learn/json-web-tokens/
///  és a cikk, ahonnan a WebAPI implementációt vettem:
///  https://goblincoding.com/2016/07/03/issuing-and-authenticating-jwt-tokens-in-asp-net-core-webapi-part-i/
///  https://goblincoding.com/2016/07/07/issuing-and-authenticating-jwt-tokens-in-asp-net-core-webapi-part-ii/
/// ------------------------------------------------------------------------------- 
///  Felhasználó                      Szerver
///  (Böngésző)                      (Alkalmazás)
///  
/// POST login 
/// {                 POST
///    UserName=..., ----------->
///    Password=... 
/// }
///                    HTTP 200 OK
///                  <------------  {
///                                    token="JWT_Token"
///                                    (...)
///                                 }
///                   GET              
/// GET ....         ------------> 
/// Headers:  
/// [
///   "Authorization" : "Bearer JWT_Token"
///   (...)
/// ]
///                   HTTP 200 OK
///                  <--------------
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
            var restapiaddmodel = new MyListRestApiAddModel
            {
                Title = myList.Title,
                Picture = myList.PictureAsByte,
                Cards = myList.Cards
                              .Select(
                                    x => new CardRestApiModel
                               {
                                   Title = x.Title,
                                   Description = x.Description
                               }).ToList()
            };

            var request = new RestSharp.Portable.RestRequest("MyList", RestSharp.Portable.Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("body", restapiaddmodel, ParameterType.RequestBody, "application/json");

            //elkészítjük a végrehajtó műveletet
            var task = client.Execute(request);

            try
            {
                var result = task.Result;
                if (result.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception($"Nem sikerült a felvitel: {result.StatusDescription}");
                }
            }
            catch (Exception)
            {

                throw;
            }
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

        public void UpdateList(MyListViewModel myList)
        {
            var restapiaddmodel = new MyListRestApiAddModel
            {
                Title = myList.Title,
                Picture = myList.PictureAsByte,
                Cards = myList.Cards
                              .Select(
                                    x => new CardRestApiModel
                                    {
                                        Title = x.Title,
                                        Description = x.Description
                                    }).ToList()
            };

            var request = new RestSharp.Portable.RestRequest($"MyList/{myList.Id}", RestSharp.Portable.Method.PUT);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("body", restapiaddmodel, ParameterType.RequestBody, "application/json");

            //elkészítjük a végrehajtó műveletet
            var task = client.Execute(request);

            try
            {
                var result = task.Result;
                if (result.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception($"Nem sikerült a felvitel: {result.StatusDescription}");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
