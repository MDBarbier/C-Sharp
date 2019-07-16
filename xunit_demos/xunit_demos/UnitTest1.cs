using System;
using Xunit;

namespace xunit_demos
{
    //This is used for shared object instances across tests in a single file. This example ensures that fixture is created once per test file.
    public class CalculatorFixture : IDisposable
    {
        public Calculator Calculator { get; }

        public CalculatorFixture()
        {
            Calculator = new Calculator();
        }

        public void Dispose()
        {
            //any required clean up can be done here            
        }
    }

    //the test class implements the class fixture interface
    public class CalculatorTests : IClassFixture<CalculatorFixture>
    {
        private readonly CalculatorFixture _calculatorFixture;

        public CalculatorTests(CalculatorFixture calculatorFixture)
        {
            _calculatorFixture = calculatorFixture;
        }

        [Theory]
        [InlineData(3, 6, 9)]
        [InlineData(3, -6, -3)]
        public void When_AddCalled_CorrectResultReturned(int x, int y, int expected)
        {
            var result = _calculatorFixture.Calculator.Add(x, y);

            Assert.Equal(result, expected);
        }

        [Theory]
        [InlineData(4, 4, 0)]
        [InlineData(3, 2, 1)]
        public void When_SubtractCalled_CorrectResultReturned(int x, int y, int expected)
        {
            var result = _calculatorFixture.Calculator.Subtract(x, y);

            Assert.Equal(result, expected);
        }
    }

    public class Calculator
    {
        public float Subtract(float inputOne, float inputTwo)
        {
            return inputOne - inputTwo;
        }
        public float Add(float inputOne, float inputTwo)
        {
            return inputOne + inputTwo;
        }
    }
}
