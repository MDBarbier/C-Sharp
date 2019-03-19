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
    class steps
    {                
        string message1 = "";
        string message2 = "";
        string message3 = "";

        [Given(@"I have a message of Hello")]
        public void GivenIHaveAMessageOfHello()
        {
            message2 = "Hello";
            Console.WriteLine("************** F2 S1 start");
        }

        [Given(@"I have a message of Hello World")]
        public void GivenIHaveAMessageOfHelloWorld()
        {
            message1 = "Hello World";
            Console.WriteLine("************** F1 start");
        }

        [Given(@"My name is Matt")]
        public void GivenMyNameIsMatt()
        {            
            message2 += " Matt";
        }

        [When(@"I process message1")]
        public void WhenIProcessMessage1()
        {
            message1 = message1.ToLower();

            int j = 0;
            LongProcess();         
        }

        [When(@"I process message2")]
        public void WhenIProcessMessage2()
        {
            message2 = message2.ToUpper();

            LongProcess();       
        }

        [Given(@"I have a message of hello all")]
        public void GivenIHaveAMessageOfHelloAll()
        {
            Console.WriteLine("************** F2S2 start");
            message3 = "hello all";
        }

        [Then(@"the result should be HELLO MATT")]
        public void ThenTheResultShouldBeHelloMatt()
        {            
            Assert.IsTrue(message2.Equals("HELLO MATT"));
            Console.WriteLine("************** F2S1 end");
        }

        [Then(@"the result should be hello world")]
        public void ThenTheResultShouldBeHelloWorld ()
        {            
            Assert.IsTrue(message1.Equals("hello world"));
            Console.WriteLine("************** F1 end");
        }

        [When(@"I process message2 to reverse it")]
        public void WhenIProcessMessageToReverseIt()
        {
            char[] charArray = message3.ToCharArray();
            Array.Reverse(charArray);
            message3 = new string(charArray);
            message3.TrimEnd(' ');
            LongProcess();
        }

        private static void LongProcess()
        {
            long j = 0;
            for (long i = 0; i < 1_000_000_000; i++)
            {
                j++;
            }
        }

        [Then(@"the result should be ttaM olleH")]
        public void ThenTheResultShouldBeTtaMOlleH()
        {            
            Assert.IsTrue(message3 == "lla olleh");
            Console.WriteLine("************** F2S2 end");
        }



    }
}
