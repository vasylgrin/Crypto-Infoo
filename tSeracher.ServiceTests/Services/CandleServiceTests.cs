using Microsoft.VisualStudio.TestTools.UnitTesting;
using tSeracherr.Entity.Models;

namespace tSeracher.Service.Services.Tests
{
    [TestClass()]
    public class CandleServiceTests
    {
        [TestMethod()]
        public async Task SearchTokenAsync_ETH_Candles()
        {
            // arrange

            string tokenName = "eth";
            var tokenForSearchCandle = await SearchTokenService.SearchTokenAsync(tokenName);

            // act

            var candleDomainModel = await CandleService.GetCandlesByTokenAsync(tokenForSearchCandle);

            // assert

            Assert.AreNotEqual(0, candleDomainModel.Count);
        }

        [TestMethod()]
        public async Task SearchTokenAsync_null_ArgumentNullException()
        {
            // arrange

            Token tokenForSearchCandle = null;

            // act
            // assert

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(
                async () => await CandleService.GetCandlesByTokenAsync(tokenForSearchCandle));
        }
    }
}