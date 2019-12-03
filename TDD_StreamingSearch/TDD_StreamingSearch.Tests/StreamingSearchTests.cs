using System;
using Xunit;
using TDD_StreamingSearch_App;
using FluentAssertions;
using System.Collections.Generic;

namespace TDD_StreamingSearch.Tests
{
    public class StreamingSearchTests

    {
        [Theory]
        [InlineData(1, "UK")]
        public void GetListOfAvailableShowsForMyRegion(int expectedNumberOfShows, string region)
        {
            IStreamingProvider serviceProvider = new Netflix();

            SearchFunctions sf = new SearchFunctions();
            List<Show> showsAvailable = sf.GetAvailableShowsForRegion(region, serviceProvider);
            showsAvailable.Count.Should().NotBe(0);
        }


    }
}
