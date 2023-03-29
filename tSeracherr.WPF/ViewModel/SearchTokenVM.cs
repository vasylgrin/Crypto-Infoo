using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using tSeracher.Service.Services;
using tSeracherr.Entity.Excpetions;
using tSeracherr.Entity.Models;
using tSeracherr.WPF.Delegate;

namespace tSeracherr.WPF.ViewModel
{
    internal class SearchTokenVM : BaseVM
    {
        private string _tokenToSearch;
        private string _printSearchToken;
        private ObservableCollection<Market> _printMarkets = new();

        public string TokenForSearch { get => _tokenToSearch; set { _tokenToSearch = value; OnPropertyChanged("TokenToSearch"); } }

        public string PrintSearchToken { get => _printSearchToken; set { _printSearchToken = value; OnPropertyChanged(); } }
        public ObservableCollection<Market> PrintMarkets { get => _printMarkets; set { _printMarkets = value; OnPropertyChanged(); } }

        public ICommand SearchButton
        {
            get
            {
                return new DelegateCommand(async obj =>
                {
                    Token token;
                    List<Market> markets;


                    PrintMarkets.Clear();
                    if (string.IsNullOrWhiteSpace(TokenForSearch))
                    {
                        PrintSearchToken = "Enter token name pls.";
                        return;
                    }
                    token = await SearchTokenService.SearchTokenAsync(TokenForSearch);


                    if(token is null)
                    {
                        PrintSearchToken = $"{TokenForSearch} is not found";
                        return;
                    }
                    PrintSearchToken = token.ToString();
                    
                    
                    markets = await SearchMarketsService.GetMarketsByTokenAsync(token);
                    PrintMarkets = new ObservableCollection<Market>(markets);
                });
            }
        }
    }
}
