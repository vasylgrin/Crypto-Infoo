using System.Collections.ObjectModel;
using System.Linq;
using tSeracher.Service.Services;
using tSeracherr.Entity.Models;

namespace tSeracherr.WPF.ViewModel
{
    internal class HomeVM : BaseVM
    {
        private ObservableCollection<Token>? topTokens;
        public ObservableCollection<Token>? TopTokens { get => topTokens; set { topTokens = value; OnPropertyChanged(); } }


        public HomeVM()
        {
            GetTopTokenAsync();
        }

        private async void GetTopTokenAsync()
        {
            int amountOfTokensToPrint = 10;

            var tokensCollection = await SearchTokenService.GetAllTokensAsync();
            //tokensCollection.CheckForAnyValue(); //CheckForNull

            TopTokens = new ObservableCollection<Token>(tokensCollection.Take(amountOfTokensToPrint));
        }
    }
}
