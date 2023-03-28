using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tSeracher.Service.Services.Tests
{
    [TestClass()]
    public class ConvertServiceTests
    {
        [TestMethod()]
        public async Task TokenConvertAsyncTest()
        {
            // arrange

            var firstToken = await SearchTokenService.SearchTokenAsync("btc");
            var secondToken = await SearchTokenService.SearchTokenAsync("trx");
            decimal amountOfTokens = 3;

            // act

            decimal countConvertTokens = await ConvertService.TokenConvertAsync(firstToken, amountOfTokens, secondToken);

            // assert

            Assert.AreNotEqual(0, countConvertTokens); // TODO: Переробити тест.
        }
    }
}