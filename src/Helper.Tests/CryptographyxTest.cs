using Helper.Models;
using Xunit;

namespace Helper.Tests
{

  public class CryptographyxTest
  {
    [Fact]
    public void ToHash_Givern123456_Md5Hash()
    {
      // arrange
      string testValue = "e10adc3949ba59abbe56e057f20f883e"; //123456

      // act
      string value = "123456";
      string result = Cryptographyx.ToHash(value, Algorithm.Md5);

      // assert 
      Assert.Equal(result, testValue);

    }

    [Fact]
    public void ToHash_Givern123456_Sha1Hash()
    {
      // arrange
      string testValue = "7c4a8d09ca3762af61e59520943dc26494f8941b"; //123456

      // act
      string value = "123456";
      string result = Cryptographyx.ToHash(value, Algorithm.Sha1);

      // assert 
      Assert.Equal(result, testValue);

    }

    [Fact]
    public void ToHash_Givern123456_Sha256Hash()
    {
      // arrange
      string testValue = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92"; //123456

      // act
      string value = "123456";
      string result = Cryptographyx.ToHash(value, Algorithm.sha256);

      // assert 
      Assert.Equal(result, testValue);

    }

    [Fact]
    public void ToHash_Givern123456_Sha384Hash()
    {
      // arrange
      string testValue = "0a989ebc4a77b56a6e2bb7b19d995d185ce44090c13e2984b7ecc6d446d4b61ea9991b76a4c2f04b1b4d244841449454"; //123456

      // act
      string value = "123456";
      string result = Cryptographyx.ToHash(value, Algorithm.Sha384);

      // assert 
      Assert.Equal(result, testValue);

    }

    [Fact]
    public void ToHash_Givern123456_sha512Hash()
    {
      // arrange
      string testValue = "ba3253876aed6bc22d4a6ff53d8406c6ad864195ed144ab5c87621b6c233b548baeae6956df346ec8c17f5ea10f35ee3cbc514797ed7ddd3145464e2a0bab413"; //123456

      // act
      string value = "123456";
      string result = Cryptographyx.ToHash(value, Algorithm.sha512);

      // assert 
      Assert.Equal(result, testValue);

    }
  }
}
