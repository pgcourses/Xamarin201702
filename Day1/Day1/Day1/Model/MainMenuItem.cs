using System;

namespace Day1.Model
{
    public class MainMenuItem
    {
        public string Title { get; set; }
        public Type PageType { get; set; }
        public Func<Type> GetPage { get; set; }
    }
}