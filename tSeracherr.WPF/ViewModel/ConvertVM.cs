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

                    // TODO: CheckForNull
                    var firstToken = await SearchTokenService.SearchTokenAsync(FirstToken);
                    var secondToken = await SearchTokenService.SearchTokenAsync(SecondToken); // Delete secondToken

                    var text = await ConvertService.TokenConvertAsync(firstToken, FirstTokenAmount, secondToken);
                    var seriesCollection = await new PrintCandleService().PrintCandlesAsync(firstToken.FullName);

                    //text.CheckForDefault();
                    PrintConvertToken = text.ToString();

                    if (seriesCollection.Any())
                    {
                        var list = seriesCollection.FirstOrDefault().Values.Cast<OhlcPoint>().Take(100); // TODO: Змінити назву змінної

                        SeriesCollection = new SeriesCollection
                        {
                            new OhlcSeries
                            {
                                Values = new ChartValues<OhlcPoint>(list)
                            }
                        };
                    }
                    else
                    {
                        //await SlowPrint(convertModel.ErrorMessage);
                        //convertModel.ErrorMessage = string.Empty;

                        PrintConvertToken = "Щось не получилось";
                    }
                });
            }

        }
    }
}
