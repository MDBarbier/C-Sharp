using System;
using System.Collections.Generic;
using System.Text;

namespace TDD_StreamingSearch_App
{
    public interface IStreamingProvider
    {
        public string Name { get; }
        public List<string> RegionsCovered { get; }
        public List<Show> AvailableShows { get; }

        public List<Show> GetAvailableShows();
        
    }
}
