using Microsoft.VisualStudio.TestTools.UnitTesting;
using tSeracherr.Entity.Models;

namespace tSeracher.Service.Services.Tests
{
    [TestClass()]
    public class ConvertServiceTests
    {
        [TestMethod()]
        public async Task TokenConvertAsync_ThreeBTCToTRX_NotZiro()
        {
            // arrange

            var firstToken = await SearchTokenService.SearchTokenAsync("btc");
            var secondToken = await SearchTokenService.SearchTokenAsync("trx");
            decimal amountOfTokens = 3;

            // act

            decimal countConvertTokens = await ConvertService.TokenConvertAsync(firstToken, amountOfTokens, secondToken);

            // assert

            Assert.AreNotEqual(0, countConvertTokens); 
        }

        [TestMethod()]
        public async Task TokenConvertAsync_NullTokenAndTrx_ArgumentNullException()
        {
            // arrange

            Token firstToken = null;
            var secondToken = await SearchTokenService.SearchTokenAsync("trx");
            decimal amountOfTokens = 0;

            // act
            // assert

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(
                async () => await ConvertService.TokenConvertAsync(firstToken, amountOfTokens, secondToken));
        }
    }
}