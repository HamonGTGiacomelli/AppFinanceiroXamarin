using AppFinanceiro.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppFinanceiro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntryPage : ContentPage
    {
        UserEntry userEntry;
        public EntryPage()
        {
            InitializeComponent();
        }

        public EntryPage(UserEntry userEntry)
        {
            InitializeComponent();
            this.userEntry = userEntry;
            txtTitle.Text = userEntry.title;
            txtValue.Text = userEntry.value.ToString();
            debitCreditPicker.SelectedItem = userEntry.type == EntryType.CREDIT ? "Crédito (+)" : "Débito (-)";
        }

        private async void btnSaveUserEntry_Clicked(object sender, EventArgs e)
        {
            String entryTitle = txtTitle.Text;
            double entryValue = 0;
            Double.TryParse(txtValue.Text, out entryValue);

            if (null == entryTitle || entryTitle.Equals(""))
            {
                await DisplayAlert("Erro", "Favor informar o Título", "OK");
                return;
            }
            if (entryValue <= 0)
            {
                await DisplayAlert("Erro", "Favor informar um valor maior do que 0", "OK");
                return;
            }
            if (debitCreditPicker.SelectedItem == null)
            {
                await DisplayAlert("Erro", "Favor Selecionar o Tipo", "OK");
                return;
            }

            String pickerStringValue = debitCreditPicker.SelectedItem.ToString();
            if (userEntry == null)
            {
                userEntry = new UserEntry();
            }            
            userEntry.title = entryTitle;
            userEntry.value = entryValue;
            userEntry.type = pickerStringValue.Equals("Crédito (+)") ? EntryType.CREDIT : EntryType.DEBIT;

            var result = await App.Database.SaveUserEntry(userEntry);
            if (result > 0)
            {
                await DisplayAlert("Sucesso!", "Dado Salvo com Sucesso!", "OK");
                await Navigation.PopAsync();
            }
        }
    }
}