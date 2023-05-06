using LiveCharts.Defaults;
using Newtonsoft.Json.Linq;
using System.Collections;
using tSeracher.Service.Helpers;
using tSeracherr.Entity.Models;

namespace tSeracher.Service.Services
{
    public static class CandleService
    {
        public static async Task<List<OhlcPoint>> GetCandlesByTokenAsync(Token token)
        {
            if (token == null)
                throw new ArgumentNullException(nameof(token), "Input data is null.");

            string link = $"https://api.coingecko.com/api/v3/coins/{token.FullName}/ohlc?vs_currency=usd&days=30";
            string allCandlesString = await ReciveRequestHelper.ReciveToRequest(link);

            var candlesJArray = JArray.Parse(allCandlesString);
            var candles = CreateCandleAsync(candlesJArray);

            return await Task.FromResult(candles.ToList());
        }

        private static IEnumerable<OhlcPoint> CreateCandleAsync(JArray candlesArray)
        {
            foreach (var candleInform in candlesArray)
            {
                var candle = new OhlcPoint(Convert.ToDouble(candleInform[1]), Convert.ToDouble(candleInform[2]), Convert.ToDouble(candleInform[3]), Convert.ToDouble(candleInform[4]));
                yield return candle;
            }
        }
    }
}
