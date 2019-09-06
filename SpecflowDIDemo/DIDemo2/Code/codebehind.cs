using DIDemo2.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace DIDemo2.Code
{    
    [Binding]
    class codebehind
    {
        private readonly IScenarioInstance scenarioInstance;

        //Use DI to assign the implementation of the interface passed in to the local scenario instance
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
