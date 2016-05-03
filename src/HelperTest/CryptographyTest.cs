using Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelperTest
{
    [TestClass]
    public class CryptographyTest
    {
        [TestMethod]
        public void MD5()
        {
            Assert.AreEqual("e10adc3949ba59abbe56e057f20f883e", Cryptography.GenerateMD5("123456"));
        }

        [TestMethod]
        public void SHA1()
        {
            Assert.AreEqual("7c4a8d09ca3762af61e59520943dc26494f8941b", Cryptography.GenerateSHA1("123456"));
        }

        [TestMethod]
        public void SHA256()
        {
            Assert.AreEqual("8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", Cryptography.GenerateSHA256("123456"));
        }

        [TestMethod]
        public void SHA384()
        {
            Assert.AreEqual("0a989ebc4a77b56a6e2bb7b19d995d185ce44090c13e2984b7ecc6d446d4b61ea9991b76a4c2f04b1b4d244841449454", Cryptography.GenerateSHA384("123456"));
        }

        [TestMethod]
        public void SHA512()
        {
            Assert.AreEqual("ba3253876aed6bc22d4a6ff53d8406c6ad864195ed144ab5c87621b6c233b548baeae6956df346ec8c17f5ea10f35ee3cbc514797ed7ddd3145464e2a0bab413", Cryptography.GenerateSHA512("123456"));
        }
    }
}