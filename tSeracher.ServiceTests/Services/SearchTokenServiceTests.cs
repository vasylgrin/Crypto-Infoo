using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tSeracher.Service.Services.Tests
{
    [TestClass()]
    public class SearchTokenServiceTests
    {
        [TestMethod()]
        public async Task SerachTokenAsync_AbreviatedBTC_BitcoinToken()
        {
            // arrange

            string name = "btc";

            // act

            var token = await SearchTokenService.SearchTokenAsync(name);

            // assert

            Assert.AreEqual(name, token.Symbol.ToLower());
        }

        [TestMethod()]
        public async Task SerachTokenAsync_BitcoinName_BitcoinToken()
        {
            // arrange

            string name = "bitcoin";

            // act

            var token = await SearchTokenService.SearchTokenAsync(name);

            // assert

            Assert.AreEqual(name, token.FullName.ToLower());
        }

        [TestMethod()]
        public async Task SerachTokenAsync_UnknownTokenName_null()
        {
            // arrange

            string name = "sdgsdfgdsfg";

            // act

            var token = await SearchTokenService.SearchTokenAsync(name);

            // assert

            Assert.IsNull(token);
        }

        public async Task SerachTokenAsync_EmptyInputString_ArgumentNullException()
        {
            // arrange

            string name = "";

            // act
            // assert

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await SearchTokenService.SearchTokenAsync(name));
        }



        [TestMethod()]
        public async Task GetAllTokensAsyncTest()
        {
            // arrange
            // act

            var TokensList = await SearchTokenService.GetAllTokensAsync();

            // assert

            Assert.AreNotEqual(0, TokensList.Count);
        }
    }
}