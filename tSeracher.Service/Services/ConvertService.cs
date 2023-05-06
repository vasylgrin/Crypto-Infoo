using tSeracherr.Entity.Models;

namespace tSeracher.Service.Services
{
    public static class ConvertService
    {
        public static async Task<decimal> TokenConvertAsync(Token firstToken, decimal amountOfFirstTokens, Token secondToken)
        {
            if(firstToken == null || secondToken == null)
            {
                throw new ArgumentNullException(nameof(firstToken));
            }
            
            decimal res = firstToken.Price * amountOfFirstTokens / secondToken.Price;

            return await Task.FromResult(Math.Round(res, 4));
        }
    }
}
