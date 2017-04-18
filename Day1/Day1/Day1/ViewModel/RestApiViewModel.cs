using Day1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Portable.HttpClient;
using RestSharp.Portable;

namespace Day1.ViewModel
{
    public class RestApiViewModel : ViewModelBase
    {
        //private readonly RestClient client;
        //private readonly RestRequest request;
        public RestApiViewModel()
        {
            var client = new RestSharp.Portable.HttpClient.RestClient("https://www.bitstamp.net/api");
            var request = new RestSharp.Portable.RestRequest("ticker");

            try
            {
                var response = client.Execute<RestApiModel>(request);
                //response.Wait();
                var result = response.Result;

                High = result.Data.high;
                Last = result.Data.last;
                Bid = result.Data.bid;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private string high;
        public string High
        {
            get { return high; }
            set { SetProperty(value, ref high); }
        }


        private string last;
        public string Last
        {
            get { return last; }
            set { SetProperty(value, ref last); }
        }


        private string bid;

        public string Bid
        {
            get { return bid; }
            set { SetProperty(value, ref bid); }
        }
    }
}
