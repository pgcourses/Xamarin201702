using System.Collections.Generic;

namespace Xamarin201702.WebApp
{
    public class MyListRestApiModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public byte[] Picture { get; set; }

        public List<CardRestApiModel> Cards { get; set; }
    }
}