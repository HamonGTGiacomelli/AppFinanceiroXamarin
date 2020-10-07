using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AppFinanceiro.iOS;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace AppFinanceiro.iOS
{
    class FileHelper : IFileHelper
    {
        public string GetLocationPath(string fileName)
        {
            String docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            String libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }
            return Path.Combine(libFolder, fileName);
        }
    }
}