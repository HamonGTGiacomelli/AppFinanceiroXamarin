using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AppFinanceiro.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace AppFinanceiro.Droid
{
    class FileHelper : IFileHelper
    {
        public String GetLocationPath(String fileName)
        {
            String path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, fileName);
        }
    }
}