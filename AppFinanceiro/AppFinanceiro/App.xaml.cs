using AppFinanceiro.Database;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppFinanceiro
{
    public partial class App : Application
    {
        private static UserEntryDatabase database;

        internal static UserEntryDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new UserEntryDatabase(DependencyService
                        .Get<IFileHelper>()
                        .GetLocationPath("AppFinanceiroDatabase.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
