using MoneyExchangeRatePkg;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CalculatorPkg.Tests
{    
    public class CalculatorTester
    {
        //This private method mocks up an instantiation of the IUSD_CLP_ExchangeRateFeed interface, specifying the amount that the method
        //called GetActualUSDValue() returns a value of 500. This is simulating a call to an actual webservice.
        private IUSD_CLP_ExchangeRateFeed prvGetMockExchangeRateFeed()
        {
            Mock<IUSD_CLP_ExchangeRateFeed> mockObject = new Mock<IUSD_CLP_ExchangeRateFeed>();
            mockObject.Setup(m => m.GetActualUSDValue()).Returns(500);
            return mockObject.Object;
        }
                
        [Fact] //Divide 9 by 3. Expected result is 3
        public void TC1_Divide9By3()
        {
            IUSD_CLP_ExchangeRateFeed feed = this.prvGetMockExchangeRateFeed();
            ICalculator calculator = new Calculator(feed);
            int actualResult = calculator.Divide(9, 3);
            int expectedResult = 3;
            Assert.Equal(expectedResult, actualResult);
        }

        //Divide any number by zero. Should throw an System.DivideByZeroException exception.")]
        [Fact]        
        public void TC2_DivideByZero()
        {
            IUSD_CLP_ExchangeRateFeed feed = this.prvGetMockExchangeRateFeed();
            ICalculator calculator = new Calculator(feed);
            Assert.Throws<DivideByZeroException>(() => calculator.Divide(9, 0));
        }

        //Convert 1 USD to CLP. Expected result is 500
        [Fact]
        public void TC3_ConvertUSDtoCLPTest()
        {
            IUSD_CLP_ExchangeRateFeed feed = this.prvGetMockExchangeRateFeed();
            ICalculator calculator = new Calculator(feed);
            int actualResult = calculator.ConvertUSDtoCLP(1);
            int expectedResult = 500;
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
