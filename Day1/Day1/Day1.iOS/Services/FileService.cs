using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Day1.iOS.Services;
using Day1.Model;

[assembly: Dependency(typeof(FileService))]
namespace Day1.iOS.Services
{
    public class FileService : IFileService
    {
        public string GetLocalPath(string filename)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            //Az iOS konvenció miatt a ../Library/Databases könyvtárba pakolunk
            var folder = System.IO.Path.Combine(path, "..", "Library", "Databases");

            //Ez nem biztos, hogy létezik, ezért
            if (!System.IO.Directory.Exists(folder))
            {
                System.IO.Directory.CreateDirectory(folder);
            }

            return System.IO.Path.Combine(folder, path);

        }
    }
}