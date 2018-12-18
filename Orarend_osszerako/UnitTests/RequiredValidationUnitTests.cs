using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orarend_osszerako.Validation;

namespace UnitTests
{
    [TestClass]
    public class RequiredValidationUnitTests
    {
        [TestMethod]
        public void IsValid_NotNullOrEmpty_True()
        {
            string szoveg = "László Dániel UnitTest-je";

            bool result = Required.IsValid(szoveg);

            Assert.IsTrue(result);            
        }
    }
}
