using NUnit.Framework;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Tests
{
    [Binding]
    public class Tests
    {
        public List<int> Numbers { get; set; } = new List<int>();
        public int Total { get; set; }
        public string Data { get; set; }

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            Numbers.Add(p0);
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            foreach (var numbre in Numbers)
            {
                Total += numbre;
            }
        }

        [Given(@"I want to download some data")]
        public async Task GivenIWantToDownloadSomeData()
        {
            Data = await GetData();
        }


        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            Assert.IsTrue(p0 == Total);
            Assert.IsFalse(string.IsNullOrEmpty(Data));
        }

        private async Task<string> GetData()
        {
            using (HttpClient client = new HttpClient())
            {
                var reply = await client.GetStringAsync(new System.Uri("https://google.co.uk"));

                return reply;
            }
        }

    }
}