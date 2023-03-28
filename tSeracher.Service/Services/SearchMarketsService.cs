using Newtonsoft.Json.Linq;
using tSeracher.Service.Helpers;
using tSeracherr.Entity.Models;

namespace tSeracher.Service.Services
{
    public static class SearchMarketsService
    {
        public static async Task<List<Market>> GetMarketsByTokenAsync(Token tokenForSearchMarkets) // TODO: Зробити NotFound;
        {
            string? allMarketsString;
            List<Market> markets;

            if (tokenForSearchMarkets == null)
            {
                throw new Exception("not Found"); // TODO: event.
            }
            allMarketsString = await ReciveRequestHelper.ReciveToRequest($"https://api.coincap.io/v2/assets/{tokenForSearchMarkets.FullName}/markets");


            if (allMarketsString == null)
            {
                throw new Exception("not Found"); // TODO: event.
            }
            var allMarketsjToken = JToken.Parse(allMarketsString);
            markets = await CreateMarketsCollectionAsync(allMarketsjToken["data"]);

            if (!markets.Any())
            {
                throw new Exception("not Found"); // TODO: event.
            }

            return await Task.FromResult(markets);
        }

        private async static Task<List<Market>> CreateMarketsCollectionAsync(JToken allMarketsjToken)
        {
            var marketCollection = new List<Market>();

            foreach (var mkt in allMarketsjToken)
            {
                var market = new Market(mkt["exchangeId"].ToString(), mkt["baseId"].ToString(), mkt["baseSymbol"].ToString(), Math.Round(Convert.ToDouble(mkt["priceUsd"]), 4), mkt["quoteId"].ToString(), mkt["quoteSymbol"].ToString());
                marketCollection.Add(market);
            }

            return await Task.FromResult(marketCollection);
        }
    }
}
