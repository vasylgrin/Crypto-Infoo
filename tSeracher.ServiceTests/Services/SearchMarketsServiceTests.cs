﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using tSeracherr.Entity.Models;

namespace tSeracher.Service.Services.Tests
{
    [TestClass()]
    public class SearchMarketsServiceTests
    {
        [TestMethod()]
        public async Task GetMarketsByTokenAsync_TokenBitcoin_MarketsWhereItsSold()
        {
            // arrange

            string tokenName = "bitcoin";
            var token = await SearchTokenService.SearchTokenAsync(tokenName);
            // act

            var markets = await SearchMarketsService.GetMarketsByTokenAsync(token);

            // assert

            Assert.AreNotEqual(0, markets.Count);
        }

        [TestMethod()]
        public async Task GetMarketsByTokenAsync_EmptyToken_ArgumentNullException()
        {
            // arrange

            Token token = null;

            // act
            // assert

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(
                async () => await SearchMarketsService.GetMarketsByTokenAsync(token));
        }
    }
}