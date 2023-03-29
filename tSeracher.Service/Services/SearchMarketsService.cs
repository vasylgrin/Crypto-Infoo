using Newtonsoft.Json.Linq;
using tSeracher.Service.Helpers;
using tSeracherr.Entity.Excpetions;
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
            var markets = await CreateMarketsCollectionAsync(allMarketsjToken["data"]);

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
