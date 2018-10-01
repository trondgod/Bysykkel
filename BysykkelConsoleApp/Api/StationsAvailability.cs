using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BysykkelConsoleApp
{
    public class StationsAvailability
    {
        [JsonProperty("stations")]
        public List<StationAvailability> Stations { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("refresh_rate")]
        public long RefreshRate { get; set; }
    }

    public class StationAvailability
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("availability")]
        public Availability Availability { get; set; }
    }

    public class Availability
    {
        [JsonProperty("bikes")]
        public long Bikes { get; set; }

        [JsonProperty("locks")]
        public long Locks { get; set; }
    }
}
