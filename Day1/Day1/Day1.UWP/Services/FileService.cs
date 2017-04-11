using Day1.Model;
using Day1.UWP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileService))]
namespace Day1.UWP.Services
{
    public class FileService : IFileService
    {
        public string GetLocalPath(string filename)
        {
            return System.IO.Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, filename);
        }
    }
}
