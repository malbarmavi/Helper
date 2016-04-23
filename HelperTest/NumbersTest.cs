using Helper;
using Helper.Extention;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HelperTest
{
    [TestClass]
    public class NumbersTest
    {
        [TestMethod]
        public void NullValueToInt()
        {
            Assert.AreEqual(0, Numbers.Map<int>(null));
        }

        [TestMethod]
        public void StringValueToInt()
        {
            Assert.AreEqual(0, Numbers.Map<int>(String.Empty));
            Assert.AreEqual(0, Numbers.Map<int>("Hello"));
            Assert.AreEqual(0, Numbers.Map<int>("1.2"));
            Assert.AreEqual(7, Numbers.Map<int>("7"));
        }

        [TestMethod]
        public void DoubleValueToInt()
        {
            Assert.AreEqual(7, Numbers.Map<int>(7.2));
            Assert.AreEqual(7, Numbers.Map<int>(7.4));
            Assert.AreEqual(8, Numbers.Map<int>(7.5));
            Assert.AreEqual(8, Numbers.Map<int>(7.7));
            Assert.AreEqual(0, Numbers.Map<int>(0.5));
            Assert.AreEqual(1, Numbers.Map<int>(0.6));
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

        [TestMethod]
        public void ExtentionTest()
        {
            var number = "2";
            Assert.AreEqual(2, number.ToInt());
            Assert.IsTrue(number.ToInt().IsEven());
            Assert.IsTrue("3".ToInt().IsOdd());
        }
    }
}