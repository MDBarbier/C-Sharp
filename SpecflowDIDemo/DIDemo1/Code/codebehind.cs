using DIDemo1.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace DIDemo1.Code
{
    [Binding]
    class codebehind
    {
        private readonly ScenarioInstance scenarioInstance;

        //Constructor using DI
        public codebehind(ScenarioInstance scenarioInstance)
        {
            this.scenarioInstance = scenarioInstance;
        }

        [Given(@"I want to run a test")]
        public void GivenIWantToRunATest()
        {
            Assert.IsTrue(scenarioInstance.MsWaitBetweenRetries != 0);

            scenarioInstance.NumberOfRetries++;
        }

        [Then(@"Assert successfully")]
        public void ThenAssertSuccessfully()
        {
            Assert.IsTrue(1 < 2);
        }

    }
}
