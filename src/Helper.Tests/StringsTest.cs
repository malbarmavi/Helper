using Xunit;
namespace Helper.Tests
{

  public class StringsTest
  {
    [Fact]
    public void IsValid_GivenStringValue_ShouldReturnTrue()
    {

      // act
      string value = "Hello";
      bool result = Strings.IsValid(value);

      // assert
      Assert.True(result);
    }

    [Fact]
    public void IsValid_GivenNullValue_ShouldReturnFalse()
    {
      
      // act
      string nullValue = null;
      bool result = Strings.IsValid(nullValue);

      // assert
      Assert.False(result);
    }

    [Fact]
    public void IsValid_GivenEmptyString_ShouldReturnFalse()
    {

      // act
      string emptyValue = string.Empty; // => ""
      bool result = Strings.IsValid(emptyValue);

      // assert
      Assert.False(result);
    }

    [Fact]
    public void IsValid_GivenStringSpaceValue_ShouldReturnFalse()
    {

      // act
      string value = "    ";
      bool result = Strings.IsValid(value);

      // assert
      Assert.False(result);
    }
  }
}
