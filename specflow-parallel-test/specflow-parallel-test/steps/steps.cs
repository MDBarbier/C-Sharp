using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using System.Diagnostics;

namespace specflow_parallel_test.steps
{
    [Binding]
    [Parallelizable]
    public class steps
    {
        controller c = new controller();

        [Given(@"I have a message of ""(.*)""")]
        public void GivenIHaveAMessageOf(string p0)
        {
            c.Scenario = TestContext.CurrentContext.Test.Name;
            c.Message = p0;            
        }

        [When(@"I process message")]
        public void WhenIProcessMessage()
        {
            LongProcess();
        }

        [Then(@"the result should be ""(.*)""")]
        public void ThenTheResultShouldBe(string p0)
        {
            Assert.IsTrue(c.Message == p0);
        }

        [When(@"I process message to reverse it")]
        public void WhenIProcessMessageToReverseIt()
        {
            char[] charArray = c.Message.ToCharArray();
            Array.Reverse(charArray);
            c.Message = new string(charArray);
            c.Message.TrimEnd(' ');
            LongProcess();
        }

        [When(@"I process message to make uppercase")]
        public void WhenIProcessMessageToMakeUppercase()
        {
            c.Message = c.Message.ToUpper();
        }

        private static void LongProcess()
        {
            long j = 0;
            for (long i = 0; i < 5_000_000_000; i++)
            {
                j++;
            }
        }

        [AfterScenario("testScenario")]
        internal void AfterScenario()
        {            
            Console.WriteLine("^^^^^^^^^^^^^^^^ After scenario " + c.Scenario);
        }
    }

    public class controller
    {
        public string Message { get; set; }
        public string Scenario { get; set; }
    }
}
