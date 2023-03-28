using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Net;

namespace tSeracher.Service.Helpers.Tests
{
    [TestClass()]
    public class ReciveRequestHelperTests
    {
        [TestMethod()]
        public async Task ReciveToRequest_CorrectLink_JToken()
        {
            // arrange
            
            string correctlink = @"https://api.coincap.io/v2/assets/";
            
            // act
            
            var jToken = await ReciveRequestHelper.ReciveToRequest(correctlink);
            
            // assert
            
            Assert.IsNotNull(jToken);
            Assert.AreNotEqual(0, jToken.ToList().Count);
        }// TODO: тетси з exception.
    }
}