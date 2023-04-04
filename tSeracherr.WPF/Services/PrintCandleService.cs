using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using System.Windows.Media;
using tSeracher.Service.Services;
using tSeracherr.Entity.Models;

namespace tSeracherr.WPF.Services
{
    internal sealed class PrintCandleService
    {
        private IEnumerable<OhlcPoint> _collection;
        private SeriesCollection _seriesCollection;

        public async Task<SeriesCollection> CreateSeriesCollectionWithPoints(string tokenName) // TODO: Змінити назву методу.
        {
            if (string.IsNullOrWhiteSpace(tokenName))
                throw new ArgumentNullException(nameof(tokenName), "Input data is null.");

            var tokenForSearchCandle = await SearchTokenService.SearchTokenAsync(tokenName);

            _collection = await CandleService.GetCandlesByTokenAsync(tokenForSearchCandle);
            FillSeriesCollection();

            return await Task.FromResult(_seriesCollection);
        }

        private void FillSeriesCollection()
        {
            _seriesCollection = new SeriesCollection
            {
                new CandleSeries
                {
                    Values = new ChartValues<OhlcPoint>(_collection),
                    Title = "Candle",
                    ScalesYAt = 0,
                }
            };
        }
    }
}
