using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Linq;
using System.Windows.Input;
using tSeracher.Service.Services;
using tSeracherr.WPF.Delegate;
using tSeracherr.WPF.Services;

namespace tSeracherr.WPF.ViewModel
{
    internal class ConvertVM : BaseVM
    {
        private string _firstToken;
        private decimal _firstTokenAmount = 1;
        private string _secondToken;
        private string _printConvertToken;
        private SeriesCollection _seriesCollection = new();

        public string FirstToken { get { return _firstToken; } set { _firstToken = value; OnPropertyChanged(); } }
        public decimal FirstTokenAmount { get { return _firstTokenAmount; } set { _firstTokenAmount = value; OnPropertyChanged(); } }
        public string SecondToken { get { return _secondToken; } set { _secondToken = value; OnPropertyChanged(); } }
        public string PrintConvertToken { get => _printConvertToken; set { _printConvertToken = value; OnPropertyChanged(); } }
        public SeriesCollection SeriesCollection { get => _seriesCollection; set { _seriesCollection = value; OnPropertyChanged(); } }

        public ICommand ConvertTokenButton
        {
            get
            {
                return new DelegateCommand(async (obj) =>
                {
                    SeriesCollection.Clear();
                    if (string.IsNullOrWhiteSpace(FirstToken))
                    {
                        PrintConvertToken = "Enter first token name pls.";
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(SecondToken))
                    {
                        PrintConvertToken = "Enter second token for convertation.";
                        return;
                    }

                    var firstToken = await SearchTokenService.SearchTokenAsync(FirstToken);
                    var secondToken = await SearchTokenService.SearchTokenAsync(SecondToken);

                    if(firstToken is null)
                    {
                        PrintConvertToken = $"{FirstToken} not found.";
                        return;
                    }
                    if (secondToken is null)
                    {
                        PrintConvertToken = $"{SecondToken} not found.";
                        return;
                    }

                    var countOfTokensWhichWereConvertation = await ConvertService.TokenConvertAsync(firstToken, FirstTokenAmount, secondToken);
                    PrintConvertToken = countOfTokensWhichWereConvertation.ToString();

                    var seriesCollection = await new PrintCandleService().CreateSeriesCollectionWithPoints(firstToken.FullName);

                    SeriesCollection = seriesCollection;
                });
            }

        }
    }
}
