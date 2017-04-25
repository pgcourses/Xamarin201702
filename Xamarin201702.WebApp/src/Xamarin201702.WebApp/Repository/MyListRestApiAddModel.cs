using System.Collections.Generic;

namespace Xamarin201702.WebApp
{
    /// <summary>
    /// Ugyanaz, mint a model, de nincs benne id
    /// </summary>
    public class MyListRestApiAddModel
    {
        public string Title { get; set; }
        public byte[] Picture { get; set; }
        public List<CardRestApiModel> Cards { get; set; }
    }
}