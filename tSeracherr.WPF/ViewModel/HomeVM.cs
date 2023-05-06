using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using tSeracher.Service.Services;
using tSeracherr.Entity.Models;

namespace tSeracherr.WPF.ViewModel
{
    public class HomeVM : BaseVM
    {
        private ObservableCollection<Token>? topTokens;
        private Token _selectedItem;

        public ObservableCollection<Token>? TopTokens { get => topTokens; set { topTokens = value; OnPropertyChanged(); } }
        public Token SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                Process.Start(new ProcessStartInfo { FileName = value.MarketLink, UseShellExecute = true });
                OnPropertyChanged();
            }
        }


        public HomeVM()
        {
            GetTopTokenAsync();
        }

        private async void GetTopTokenAsync()
        {
            int amountOfTokensToPrint = 10;
            var tokensCollection = await SearchTokenService.GetAllTokensAsync();
            TopTokens = new ObservableCollection<Token>(tokensCollection.Take(amountOfTokensToPrint));
        }
    }
}
