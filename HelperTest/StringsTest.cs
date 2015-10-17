using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Helper;
namespace HelperTest
{
    [TestClass]
    public class StringsTest
    {
        [TestMethod]
        public void IsNullOrEmptyOrWhiteSpace()
        {
            Assert.IsTrue(Strings.IsNullOrEmptyOrWhiteSpacce(null));
            Assert.IsTrue(Strings.IsNullOrEmptyOrWhiteSpacce(string.Empty));
            Assert.IsTrue(Strings.IsNullOrEmptyOrWhiteSpacce("  "));
            Assert.IsTrue(!Strings.IsNullOrEmptyOrWhiteSpacce("Helper ..."));
            Assert.IsFalse(Strings.IsNullOrEmptyOrWhiteSpacce("Helper ..."));
        }
    }
}
