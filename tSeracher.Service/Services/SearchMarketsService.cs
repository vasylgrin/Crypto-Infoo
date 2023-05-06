using Newtonsoft.Json.Linq;
using System.Collections;
using tSeracher.Service.Helpers;
using tSeracherr.Entity.Models;

namespace tSeracher.Service.Services
{
    public static class SearchMarketsService
    {
        public static async Task<List<Market>> GetMarketsByTokenAsync(Token tokenForSearchMarkets) // TODO: Зробити NotFound;
        {
            if (tokenForSearchMarkets is null)
                throw new ArgumentNullException("Input data is null.");

            var allMarketsString = await ReciveRequestHelper.ReciveToRequest(
                $"https://api.coincap.io/v2/assets/{tokenForSearchMarkets.FullName}/markets");

            var allMarketsjToken = JToken.Parse(allMarketsString);
            var markets = CreateMarketsCollectionAsync(allMarketsjToken["data"]).ToList();

            return await Task.FromResult(markets);
        }

        private static IEnumerable<Market> CreateMarketsCollectionAsync(JToken allMarketsjToken)
        {
            foreach (var mkt in allMarketsjToken)
            {
                var market = new Market(mkt["exchangeId"].ToString(), mkt["baseId"].ToString(), mkt["baseSymbol"].ToString(), Math.Round(Convert.ToDouble(mkt["priceUsd"]), 4), mkt["quoteId"].ToString(), mkt["quoteSymbol"].ToString());
                yield return market;
            }
        }
    }
}
