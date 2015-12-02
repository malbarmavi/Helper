using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Helper;
namespace HelperTest
{
    [TestClass]
    public class NumbersTest
    {
        [TestMethod]
        public void NullValueToInt()
        {
            Assert.AreEqual(0, Numbers.Parse<int>(null));
        }
        [TestMethod]
        public void StringValueToInt()
        {
            Assert.AreEqual(0, Numbers.Parse<int>(String.Empty));
            Assert.AreEqual(0, Numbers.Parse<int>("Hello"));
            Assert.AreEqual(0, Numbers.Parse<int>("1.2"));
            Assert.AreEqual(7, Numbers.Parse<int>("7"));
        }
        [TestMethod]
        public void DoubleValueToInt()
        {
            Assert.AreEqual(7, Numbers.Parse<int>(7.2));
            Assert.AreEqual(7, Numbers.Parse<int>(7.4));
            Assert.AreEqual(8, Numbers.Parse<int>(7.5));
            Assert.AreEqual(8, Numbers.Parse<int>(7.7));
            Assert.AreEqual(0, Numbers.Parse<int>(.5));
            Assert.AreEqual(1, Numbers.Parse<int>(.6));
        }

        [TestMethod]
        public void Binarytest()
        {
            Assert.AreEqual("1000", Numbers.ToBinary(8));
        }

        [TestMethod]
        public void HexText()
        {
            Assert.AreEqual("F", Numbers.ToHex(15));
        }

    }
}
