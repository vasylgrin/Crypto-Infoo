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
            
            var dataString = await ReciveRequestHelper.ReciveToRequest(correctlink);
            
            // assert
            
            if(string.IsNullOrWhiteSpace(dataString))
                Assert.Fail();
        }
    }
}