using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Helper;
namespace HelperTest
{
    [TestClass]
    public class StringsTest
    {
        [TestMethod]
        public void IsValidString()
        {
            Assert.IsFalse(Strings.IsValidString(null));
            Assert.IsFalse(Strings.IsValidString(string.Empty));
            Assert.IsFalse(Strings.IsValidString("  "));
            Assert.IsTrue(Strings.IsValidString("Helper ..."));

        }
        [TestMethod]
        public void GetSpace()
        {
            var space = "    ";
            var result = Strings.GetSpace();

            Assert.AreEqual(space, result);
            Assert.AreEqual(space.Length, result.Length);
        }
    }
}
