using System.Collections.Generic;

namespace Day1.Model
{
    public class MyListRestApiAddModel
    {
        public string Title { get; set; }
        public byte[] Picture { get; set; }
        public List<CardRestApiModel> Cards { get; set; }
    }
}