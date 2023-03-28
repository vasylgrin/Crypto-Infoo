using tSeracherr.Entity.Models;

namespace tSeracher.Service.Services
{
    public static class ConvertService
    {
        public static Task<decimal> TokenConvertAsync(Token firstToken, decimal amountOfFirstTokens, Token secondToken)
        {
            if(firstToken == null || secondToken == null)
            {
                throw new ArgumentNullException(nameof(firstToken)); // TODO: event.
            }
            
            decimal percentage = 0.05m;

            decimal res = (firstToken.Price - (firstToken.Price * percentage)) * amountOfFirstTokens / secondToken.Price;

            return Task.FromResult(Math.Round(res, 4));
        }
    }
}
