using AppFinanceiro.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppFinanceiro
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();           
        }

        private async void updateListView()
        {
            double total = 0;
            var entryList = await App.Database.GetUserEntries();
            foreach (var entry in entryList)
            {
                if (entry.type == EntryType.CREDIT)
                {
                    total += entry.value;
                }
                else
                {
                    total -= entry.value;
                }

            }
            txtTotalValue.Text = total.ToString("C");
            txtTotalValue.TextColor = total >= 0 ? Color.Green : Color.Red;
            entryList.Reverse();
            lstHistory.HasUnevenRows = true;
            lstHistory.ItemsSource = entryList;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            updateListView();
        }

        private void btnAddEntry_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EntryPage());
        }

        private async void btnEdit_Clicked(object sender, EventArgs e)
        {
            Button button = (Button) sender;
            UserEntry userEntry = (UserEntry) button.CommandParameter;
            await Navigation.PushAsync(new EntryPage(userEntry));
        }

        private async void  btnDelete_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            UserEntry userEntry = (UserEntry)button.CommandParameter;
            var userConfirmed = await DisplayAlert("Delete", $"Tem certeza que deseja remover {userEntry.title}?", "SIM", "NÃO");
            if (userConfirmed)
            {
                var result = await App.Database.DeleteUserEntry(userEntry);
                if (result > 0)
                {
                    await DisplayAlert("Sucesso!","Entrada Removida com Sucesso!","OK");
                    updateListView();
                } else
                {
                    await DisplayAlert("Erro!", "Um erro ocorreu, tente novamente mais tarde.", "OK");
                }
            }
        }
    }
}
