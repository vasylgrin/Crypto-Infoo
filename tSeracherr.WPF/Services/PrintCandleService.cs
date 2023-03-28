using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using System.Windows.Media;
using tSeracher.Service.Services;
using tSeracherr.Entity.Models;

namespace tSeracherr.WPF.Services
{
    internal class PrintCandleService
    {
        public async Task<SeriesCollection> PrintCandlesAsync(string tokenName) // TODO: Змінити назву методу.
        {
            if (string.IsNullOrWhiteSpace(tokenName))
            {
                throw new Exception(); // TODO: EVENT.
            }

            var tokenForSearchCandle = await SearchTokenService.SearchTokenAsync(tokenName);


            //var candleDomainModel = await CandleService.GetCandlesByTokenAsync(tokenForSearchCandle);

            var candlesList = await CandleService.GetCandlesByTokenAsync(tokenForSearchCandle);

            SeriesCollection seriesCollection = new();

            seriesCollection.Add(new CandleSeries
            {
                Values = new ChartValues<OhlcPoint>(candlesList),
                Title = "Candle",
                ScalesYAt = 0,
            });

            return await Task.FromResult(seriesCollection);
        }
    }
}
