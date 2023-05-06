using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tSeracherr.WPF.ViewModel.Tests
{
    [TestClass()]
    public class HomeVMTests
    {
        [TestMethod()]
        public void HomeVMTest_CreateHomeVM_GetTopTokens()
        {
            // arrange

            var vm = new HomeVM();

            // act

            var countTokens = vm.TopTokens.Count;

            // assert

            Assert.AreNotEqual(0, countTokens);
            Assert.AreEqual(10, countTokens);
        }
    }
}