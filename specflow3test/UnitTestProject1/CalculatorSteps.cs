using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace dotnet472
{
    [Binding]
    public class CalculatorSteps
    {
        private int number1 = 0;
        private int number2 = 0;
        private int number3 = 0;

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            number1 = p0;    
        }
        
        [Given(@"I have also entered (.*) into the calculator")]
        public void GivenIHaveAlsoEnteredIntoTheCalculator(int p0)
        {
            number2 = p0;
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            number3 = number1 + number2;
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            Assert.IsTrue(number3 == p0);
        }
    }
}
