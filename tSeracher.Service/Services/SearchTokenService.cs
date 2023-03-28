using Newtonsoft.Json.Linq;
using tSeracher.Service.Helpers;
using tSeracherr.Entity.Models;

namespace tSeracher.Service.Services
{
    public static class SearchTokenService
    {
        public static async Task<Token?> SearchTokenAsync(string searchTokenName)
        {
            // TODO: Зробити пошук по іменні зразу по api.

            var tokensCollection = await GetAllTokensAsync();
            var token = tokensCollection.Where(tkn => tkn.FullName.ToUpper() == searchTokenName.ToUpper() || tkn.Symbol.ToUpper() == searchTokenName.ToUpper()).FirstOrDefault();

            return token;
        }

        public static async Task<List<Token>> GetAllTokensAsync()
        {
            var allTokensString = await ReciveRequestHelper.ReciveToRequest(@"https://api.coincap.io/v2/assets/");

            if (string.IsNullOrWhiteSpace(allTokensString))
                throw new ArgumentNullException(nameof(allTokensString), "Переробити"); // TODO: Event

            var jToken = JToken.Parse(allTokensString);
            var tokensList = await CreateTokenList(jToken["data"]);

            return await Task.FromResult(tokensList);
        }

        private async static Task<List<Token>> CreateTokenList(JToken allTokensJToken)
        {
            var tokensCollection = new List<Token>();

            foreach (var tkn in allTokensJToken)
            {
                var token = new Token(Convert.ToInt32(tkn["rank"]), tkn["id"].ToString(), tkn["symbol"].ToString(), Convert.ToDecimal(tkn["priceUsd"]));
                tokensCollection.Add(token);
            }

            return await Task.FromResult(tokensCollection);
        }
    }
}
