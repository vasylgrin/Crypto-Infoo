using Newtonsoft.Json.Linq;
using tSeracher.Service.Helpers;
using tSeracherr.Entity.Models;

namespace tSeracher.Service.Services
{
    public static class SearchTokenService
    {
        public static async Task<Token> SearchTokenAsync(string searchTokenName)
        {
            if (string.IsNullOrWhiteSpace(searchTokenName))
                throw new ArgumentNullException(nameof(searchTokenName), "Input data is null.");

            var tokensCollection = await GetAllTokensAsync();
            var token = tokensCollection.Where(tkn => tkn.FullName.ToUpper() == searchTokenName.ToUpper() || tkn.Symbol.ToUpper() == searchTokenName.ToUpper()).FirstOrDefault();

            return token;
        }

        public static async Task<List<Token>> GetAllTokensAsync()
        {
            var allTokensString = await ReciveRequestHelper.ReciveToRequest(@"https://api.coincap.io/v2/assets/");

            var jToken = JToken.Parse(allTokensString);
            var tokensList = CreateTokenListAsync(jToken["data"]).ToList();

            return await Task.FromResult(tokensList);
        }

        private static IEnumerable<Token> CreateTokenListAsync(JToken allTokensJToken)
        {
            foreach (var tkn in allTokensJToken)
            {
                var token = new Token(Convert.ToInt32(tkn["rank"]), tkn["id"].ToString(), tkn["symbol"].ToString(), Convert.ToDecimal(tkn["priceUsd"]), tkn["explorer"].ToString());
                yield return token;
            }
        }
    }
}
