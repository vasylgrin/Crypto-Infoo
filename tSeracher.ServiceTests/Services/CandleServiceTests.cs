using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tSeracher.Service.Services.Tests
{
    [TestClass()]
    public class CandleServiceTests
    {
        [TestMethod()]
        public async Task AddCandleAsyncTest()
        {
            // arrange

            string tokenName = "ethereum";

            var tokenForSearchCandle = await SearchTokenService.SearchTokenAsync(tokenName);

            // act

            var candleDomainModel = await CandleService.GetCandlesByTokenAsync(tokenForSearchCandle);

            // assert

            Assert.AreNotEqual(0, candleDomainModel.ChartValuesOhlcPoint.Count);
            Assert.AreNotEqual(0, candleDomainModel.ChartValuesObseravableCollection1.Count);
            Assert.AreNotEqual(0, candleDomainModel.ChartValuesObseravableCollection2.Count);
        }
    }
}