using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BysykkelConsoleApp
{
    /// <summary>
    /// Class to get data from 'Oslo bysykkel' web API
    /// </summary>
    public class BysykkelWebApi
    {
        string _apiKey;
        string _apiBaseAddress;

        public BysykkelWebApi(string apiKey, string apiBaseAddress)
        {
            _apiKey = apiKey;
            _apiBaseAddress = apiBaseAddress;
        }
        
        public async Task<BikeStationResult> GetBikeStationsAsync()
        {
            var bikeStationResult = new BikeStationResult();
            try
            {
                var httpClient = new HttpClient()
                {
                    BaseAddress = new Uri(_apiBaseAddress)
                };
                httpClient.DefaultRequestHeaders.Add("Client-Identifier", _apiKey);

                HttpResponseMessage response = await httpClient.GetAsync("stations");
                if (response.IsSuccessStatusCode == false)
                {
                    bikeStationResult.Message = response.StatusCode.ToString();
                    return bikeStationResult;
                }

                string stationsResult = await response.Content.ReadAsStringAsync();
                StationsInOperation stationsInOperation = GetData<StationsInOperation>(stationsResult);

                response = await httpClient.GetAsync("stations/availability");
                string stationsAvailabilityResult = await response.Content.ReadAsStringAsync();
                StationsAvailability stationsAvailability = GetData<StationsAvailability>(stationsAvailabilityResult);

                return BikeStationMatcher.MergeStations(stationsInOperation, stationsAvailability);
            }
            catch (Exception)
            {
                bikeStationResult.Message = "En uventet feil skjedde!";
                return bikeStationResult;
            }

        }

        private static T GetData<T>(string result)
        {
            T jsonData = JsonConvert.DeserializeObject<T>(result);
            return jsonData;
        }
    }
}
