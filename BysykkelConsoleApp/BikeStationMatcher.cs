namespace BysykkelConsoleApp
{
    /// <summary>
    /// Class merge stations into matched bikestations 
    /// </summary>
    public class BikeStationMatcher
    {

        /// <summary>
        /// Method match result from stations in operation and availability for stations into a merged bikestation object.   
        /// </summary>
        /// <param name="InOperation"></param>
        /// <param name="Availability"></param>
        /// <returns>Result object contain list of bikestations</returns>
        public static BikeStationResult MergeStations(StationsInOperation inOperation, StationsAvailability availability)
        {
            var bikeStationResult = new BikeStationResult();
            bikeStationResult.UpdatedAt = availability.UpdatedAt;

            foreach (var stationInOperation in inOperation.Stations)
            {
                StationAvailability stationAvailability = availability.Stations.Find(i => i.Id == stationInOperation.Id);

                long bikes = 0;
                long locks = 0;
                bool availableMatchFound = false;

                if (availability != null)
                {
                    bikes = stationAvailability.Availability.Bikes;
                    locks = stationAvailability.Availability.Locks;
                    availableMatchFound = true;
                }

                bikeStationResult.BikeStations.Add(new BikeStation
                {
                    Id = stationInOperation.Id,
                    Title = stationInOperation.Title,
                    Subtitle = stationInOperation.Subtitle,
                    Availability = new Available { Bikes = bikes, Locks = locks, MatchFound = availableMatchFound }
                });
            }

            return bikeStationResult;
        }
    }
}
