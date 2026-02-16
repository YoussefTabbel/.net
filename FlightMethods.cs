public void ShowFlightDetails(string destination, DateTime date)
{
    var flights = Flights.Where(f => f.Destination == destination && f.FlightDate == date);
    foreach (var flight in flights)
    {
        Console.WriteLine(FormatFlight(flight));
    }
}