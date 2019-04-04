using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace specflow3test
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        public int Counter { get; set; }
        public int Num1 { get; set; }
        public int Num2 { get; set; }

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            if (Num1 == 0)
                Num1 = p0;
            else
                Num2 = p0;
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            Counter = Num1 + Num2;
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            Assert.IsTrue(Counter == p0);
        }
    }
}
