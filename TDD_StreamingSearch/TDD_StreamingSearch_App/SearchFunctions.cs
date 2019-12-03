using System;
using System.Collections.Generic;
using System.Text;

namespace TDD_StreamingSearch_App
{
    public class SearchFunctions
    {
        public List<Show> GetAvailableShows(IStreamingProvider streamingProvider)
        {
            return streamingProvider.AvailableShows;
        }

        public List<Show> GetAvailableShowsForRegion(string region, IStreamingProvider streamingProvider)
        {
            List<Show> showsAvailableInRegion = new List<Show>();

            foreach (var show in streamingProvider.AvailableShows)
            {
                if (show.RegionsAvailable.Contains(region))
                {
                    showsAvailableInRegion.Add(show);
                }
            }

            return showsAvailableInRegion;
        }
    }
}
