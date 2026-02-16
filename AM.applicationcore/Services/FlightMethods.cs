using AM.applicationcore.Domain;
using AM.applicationcore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AM.applicationcore.Services
{
    public class FlightMethods : IFlightMethods
    {
        public List<Flight> Flights { get; set; } = new List<Flight>();

        public IEnumerable<DateTime> GetFlightDates(string destination)
        {
            if (string.IsNullOrWhiteSpace(destination)) return Enumerable.Empty<DateTime>();

            var query =
                from f in Flights
                where string.Equals(f.Destination, destination, StringComparison.OrdinalIgnoreCase)
                select f.FlightDate;

            return query;
        }

        public void GetFlights(string filterType, string filterValue)
        {
            if (string.IsNullOrEmpty(filterType))
            {
                Console.WriteLine("Filter type is required.");
                return;
            }

            switch (filterType.Trim().ToLowerInvariant())
            {
                case "destination":
                    foreach (var item in Flights.Where(f => string.Equals(f.Destination, filterValue, StringComparison.OrdinalIgnoreCase)))
                        Console.WriteLine(FormatFlight(item));
                    break;

                case "flightdate":
                    if (DateTime.TryParse(filterValue, out var parsedDate))
                    {
                        foreach (var item in Flights.Where(f => f.FlightDate.Date == parsedDate.Date))
                            Console.WriteLine(FormatFlight(item));
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format for filterValue.");
                    }
                    break;

                case "flightid":
                    if (int.TryParse(filterValue, out var id))
                    {
                        foreach (var item in Flights.Where(f => f.FlightId == id))
                            Console.WriteLine(FormatFlight(item));
                    }
                    else
                    {
                        Console.WriteLine("Invalid integer format for filterValue.");
                    }
                    break;

                default:
                    Console.WriteLine($"Unknown filter type: {filterType}");
                    break;
            }
        }

        private static string FormatFlight(Flight f)
        {
            if (f == null) return string.Empty;
            return $"FlightId: {f.FlightId}, Destination: {f.Destination}, FlightDate: {f.FlightDate:yyyy-MM-dd HH:mm:ss}, Departure: {f.Departure}";
        }

        public void ShowFlightDetails(Plane plane)
        {
            var flightDetails = Flights.Where(f => f.Plane == plane)
                                       .Select(f => new { f.Destination, f.FlightDate });
            foreach (var item in flightDetails)
            {
                Console.WriteLine("destination =" + item.Destination + " date=" + item.FlightDate.ToString());
            }
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            var start = startDate.Date;
            var end = start.AddDays(7);
            return Flights.Count(f => f.FlightDate.Date >= start && f.FlightDate.Date < end);
        }

        public IEnumerable<Traveller> SeniorTravellers(Flight flight)
        {
            if (flight?.Passengers == null) return Enumerable.Empty<Traveller>();

            return flight.Passengers
                         .OfType<Traveller>()
                         .OrderBy(t => t.BirthDate) // les plus âgés (naissance la plus ancienne)
                         .Take(3);
        }

        // 4. DurationAverage
        // - Variante méthode LINQ (expression lambda)
        public double DurationAverage_Lambda(string destination)
        {
            if (string.IsNullOrWhiteSpace(destination)) return 0.0;

            var durations = Flights
                .Where(f => string.Equals(f.Destination, destination, StringComparison.OrdinalIgnoreCase))
                .Select(f => f.EstimatedDuration);

            return durations.Any() ? durations.Average() : 0.0;
        }

        // - Variante syntaxe de requête LINQ
        public double DurationAverage_Query(string destination)
        {
            if (string.IsNullOrWhiteSpace(destination)) return 0.0;

            var query =
                from f in Flights
                where string.Equals(f.Destination, destination, StringComparison.OrdinalIgnoreCase)
                select f.EstimatedDuration;

            return query.Any() ? query.Average() : 0.0;
        }

        // 5. OrderedDurationFlights
        // - Variante méthode LINQ (expression lambda)
        public IEnumerable<Flight> OrderedDurationFlights_Lambda()
        {
            return Flights.OrderByDescending(f => f.EstimatedDuration);
        }

        // - Variante syntaxe de requête LINQ
        public IEnumerable<Flight> OrderedDurationFlights_Query()
        {
            var query =
                from f in Flights
                orderby f.EstimatedDuration descending
                select f;
            return query;
        }

        // 7. DestinationGroupedFlights (affichage)
        // - Variante méthode LINQ (GroupBy avec lambda)
        public void DestinationGroupedFlights_Lambda()
        {
            var groups = Flights.GroupBy(f => f.Destination);

            foreach (var g in groups)
            {
                Console.WriteLine($"Destination {g.Key}");
                foreach (var f in g)
                {
                    Console.WriteLine($"Décollage : {f.FlightDate:dd/MM/yyyy HH:mm:ss}");
                }
            }
        }

        // - Variante syntaxe de requête LINQ (query syntax)
        public void DestinationGroupedFlights_Query()
        {
            var groups =
                from f in Flights
                group f by f.Destination into g
                select g;

            foreach (var g in groups)
            {
                Console.WriteLine($"Destination {g.Key}");
                foreach (var f in g)
                {
                    Console.WriteLine($"Décollage : {f.FlightDate:dd/MM/yyyy HH:mm:ss}");
                }
            }
        }
    }
}
