using System;
using System.Linq;
using Xunit;
namespace Helper.Tests
{

  /*

    Popular unit test naming
    https://dzone.com/articles/7-popular-unit-test-naming

   */

  public class NumbersTest
  {
    [Fact]
    public void ToInt_Given0_ShouldReturn0()
    {
      // arrange
      int num = 0;

      // act
      int result = Utility.Map<int>(0);

      // assert
      Assert.Equal(num, result);
    }

    [Fact]
    public void ToInt_GivenDoubleValue_ShouldReturn1()
    {
      // arrange
      double num = 1;

      // act
      int result = Utility.Map<int>(1.2);

      // assert
      Assert.Equal(num, result);
    }

    [Fact]
    public void ToInt_GivenDoubleValue_ShouldReturn2()
    {
      // arrange
      double num = 2;

      // act
      int result = Utility.Map<int>(1.5);

      // assert
      Assert.Equal(num, result);
    }

    [Fact]
    public void ToInt_GivenNull_ShouldReturn0()
    {
      // arrange
      int num = 0;

      // act
      int result = Utility.Map<int>(null);

      // assert
      Assert.Equal(num, result);
    }

    [Fact]
    public void ToInt_GivenTrue_ShouldReturn1()
    {
      // arrange
      int num = 1;

      // act
      int result = Utility.Map<int>(true);

      // assert
      Assert.Equal(num, result);
    }

    [Fact]
    public void ToInt_GivenFalse_ShouldReturn0()
    {
      // arrange
      int num = 1;

      // act
      int result = Utility.Map<int>(true);

      // assert
      Assert.Equal(num, result);
    }

    [Fact]
    public void ToInt_GivenInValidStringValue_ShouldReturn0()
    {
      // arrange
      int num = 0;

      // act
      int result = Utility.Map<int>("Hello");

      // assert
      Assert.Equal(num, result);
    }

    [Fact]
    public void ToInt_GivenValidStringValue10_ShouldReturn10()
    {
      // arrange
      int num = 10;

      // act
      int result = Utility.Map<int>("10");

      // assert
      Assert.Equal(num, result);
    }

    [Fact]
    public void ToBinary_Given4_ShouldReturn1000()
    {

      // arange 
      string binaryValue = "100";

      // act
      string result = Numbers.ToBinary(4);

      // assert
      Assert.Equal(binaryValue, result);
    }


    [Fact]
    public void ToHex_Given15_ShouldReturnFF()
    {

      // arange 
      string hexValue = "F";

      // act
      string result = Numbers.ToHex(15);

      // assert
      Assert.Equal(result, hexValue);
    }

    [Fact]
    public void IsEven_Given3_ShouldReturnFalse()
    {
      // act
      bool result = Numbers.IsEven(3);

      // assert
      Assert.False(result);

    }

    [Fact]
    public void IsEven_Given2_ShouldReturnTrue()
    {

      // act
      bool result = Numbers.IsEven(2);

      // assert
      Assert.True(result);

    }

    [Fact]
    public void IsOdd_Given3_ShouldReturnTrue()
    {
      // act
      bool result = Numbers.IsOdd(3);

      // assert
      Assert.True(result);

    }

    [Fact]
    public void IsOdd_Given2_ShouldReturnFalse()
    {

      // act
      bool result = Numbers.IsOdd(2);

      // assert
      Assert.False(result);

    }

    [Fact]
    public void CalcFibonacciSequence_Given0_ShouldReturn0()
    {
      // arange
      int fib = 0;

      // act
      int result = Numbers.CalcFibonacciSequence(0).Sum();

      // assert
      Assert.Equal(fib, result);

    }

    [Fact]
    public void CalcFibonacciSequence_Given1_ShouldReturn1()
    {
      // arange
      int fibList = 1;

      // act
      int result = Numbers.CalcFibonacciSequence(1).Sum();

      // assert
      Assert.Equal(fibList, result);

    }

    [Fact]
    public void CalcFibonacciSequence_Given2_ShouldReturn2()
    {
      // arange
      int fibList = 4;

      // act
      int result = Numbers.CalcFibonacciSequence(2).Sum();

      // assert
      Assert.Equal(fibList, result);

    }

    [Fact]
    public void ToFixed_GivenPi_ShouldReturn3()
    {
      // arange
      double value = 3d;

      // act
      double result = Numbers.ToFixed(Math.PI);

      // assert
      Assert.Equal(value, result);
    }

    public void ToFixed_GivenPi_ReturnPiWith2PrecisionLength()
    {
      // arange
      double value = 3d;

      // act
      double result = Numbers.ToFixed(Math.PI,2);

      // assert
      Assert.Equal(value, result);
    }


    public void ToFixed_GivenPi_ReturnPiWith4PrecisionLength()
    {
      // arange
      double value = 3d;

      // act
      double result = Numbers.ToFixed(Math.PI,4) ;

      // assert
      Assert.Equal(value, result);
    }
  }
}


