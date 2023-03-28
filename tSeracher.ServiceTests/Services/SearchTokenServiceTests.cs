using Microsoft.VisualStudio.TestTools.UnitTesting;
using tSeracher.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tSeracherr.Entity.Excpetions;

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