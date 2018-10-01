using System;
using System.Collections.Generic;

namespace BysykkelConsoleApp
{
    public class BikeStationResult
    {
        public List<BikeStation> BikeStations { get; set; } = new List<BikeStation>();

        public string Message { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }

    public class BikeStation
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }
        
        public Available Availability { get; set; }

        public override string ToString()
        {
            return $"{Title} - {Subtitle} \r\n\t{Availability}\r\n";
        }
    }

    public class Available
    {
        public long Bikes { get; set; }

        public long Locks { get; set; }

        public bool MatchFound { get; set; }

        public override string ToString()
        {
            if (!MatchFound)
            {
                return "Siste status på tilgjengelige sykler og låser ble ikke funnet for stasjonen!";
            }

            string bikeText = "sykler";
            if (Bikes == 0) bikeText = "sykkel";

            string lockText = "låser";
            if (Locks == 0) lockText = "lås";

            return $"Tilgjengelig: {Bikes} {bikeText}, {Locks} {lockText}";
        }
    }
}
