using Xunit;
namespace Helper.Tests
{

  public class NumbersTest
  {
    [Fact]
    public void ToInt_Given0_shouldReturn0()
    {
      // arrange
      int num = 0;

      // act
      int result = Numbers.Map<int>(0);

      // assert
      Assert.Equal(num, result);
    }

    [Fact]
    public void ToInt_GivenDoubleValue_shouldReturn1()
    {
      // arrange
      double num = 1;

      // act
      int result = Numbers.Map<int>(1.2);

      // assert
      Assert.Equal(num, result);
    }

    [Fact]
    public void ToInt_GivenDoubleValue_shouldReturn2()
    {
      // arrange
      double num = 2;

      // act
      int result = Numbers.Map<int>(1.5);

      // assert
      Assert.Equal(num, result);
    }


    [Fact]
    public void ToInt_GivenNull_shouldReturn0()
    {
      // arrange
      double num = 0;

      // act
      int result = Numbers.Map<int>(null);

      // assert
      Assert.Equal(num, result);
    }



  }
}
