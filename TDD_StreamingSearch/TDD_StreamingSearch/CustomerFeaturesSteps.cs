using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace TDD_StreamingSearch
{
    [Binding]
    public class CustomerFeaturesSteps
    {
        [Given(@"There is a show that I want to watch")]
        public void GivenThereIsAShowThatIWantToWatch(Table table)
        {
            StreamingProgramExample productDefinitions = table.CreateInstance<StreamingProgramExample>();
        }

        [When(@"I enter the name od the show I want to watch")]
        public void WhenIEnterTheNameOdTheShowIWantToWatch()
        {
            
        }

        [Then(@"A list of sites is presented to me where I can stream the show")]
        public void ThenAListOfSitesIsPresentedToMeWhereICanStreamTheShow()
        {
            
        }

        [Then(@"my show is added to a notification list so if it leaves or is added to a service I get notified")]
        public void ThenMyShowIsAddedToANotificationListSoIfItLeavesOrIsAddedToAServiceIGetNotified()
        {
            
        }

    }

    public class StreamingProgramExample
    {
        public string ShowName { get; set; }
        public string UserRegion { get; set; }
        public string EmailAddress { get; set; }
        public string[] Exclusions { get; set; }
        public bool Notifications { get; set; }
    }
}
