using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Day1.Model;
using Xamarin.Forms;
using Day1.Droid.Services;

[assembly: Dependency(typeof(FileService))]
namespace Day1.Droid.Services
{
    public class FileService : IFileService
    {
        public string GetLocalPath(string filename)
        {
            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return System.IO.Path.Combine(path, filename); 
        }
    }
}