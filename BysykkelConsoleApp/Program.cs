using System;

namespace BysykkelConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Applikasjonen viser bysykkelstasjonene i Oslo. For hver stasjon vises siste status for ledige sykler og låser.");
            Console.WriteLine();

            Console.WriteLine("Lim inn gyldig API nøkkelen for å få tilgang og trykk ENTER:");
            string apiKey = Console.ReadLine();

            Console.WriteLine("Henter bysykkelstasjonene i Oslo...");
            Console.WriteLine();
            
            var bysykkelApi = new BysykkelWebApi(apiKey, "https://oslobysykkel.no/api/v1/");
            BikeStationResult result = bysykkelApi.GetBikeStationsAsync().Result;

            foreach (var bikeStation in result.BikeStations)
            {
                Console.WriteLine(bikeStation);
            }

            if (result.BikeStations.Count == 0)
            {
                Console.WriteLine("Ingen oversikt over bysyklene er mulig å vise for øyeblikket.");
                if (!string.IsNullOrEmpty(result.Message))
                {
                    Console.WriteLine($"\tFeilårsak: {result.Message}");
                }
            }
            else
            {
                Console.WriteLine($"Hentet status for {result.BikeStations.Count} sykkelstasjoner, {result.UpdatedAt.ToLocalTime()}");
            }

            Console.ReadLine();
        }
        
    }
}
