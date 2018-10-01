using System.Collections.Generic;
using Newtonsoft.Json;

namespace BysykkelConsoleApp
{
    public class StationsInOperation
    {
        [JsonProperty("stations")]
        public List<StationInOperation> Stations { get; set; }
    }

    public class StationInOperation
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("subtitle")]
        public string Subtitle { get; set; }

        [JsonProperty("number_of_locks")]
        public long NumberOfLocks { get; set; }

        [JsonProperty("center")]
        public Center Center { get; set; }

        [JsonProperty("bounds")]
        public List<Bound> Bounds { get; set; }
    }

    public class Center
    {
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }
    }

    public class Bound
    {
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }
    }
}
