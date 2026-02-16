// See https://aka.ms/new-console-template for more information
using AM.applicationcore.Domain;
using AM.applicationcore.Services;
using AM.ApplicationCore.Domain;
using System.ComponentModel;

Plane p = new Plane { Capacity = 200, ManufactureDate = new DateTime(2010, 5, 1), PlaneType = PlaneType.Boeing };
Plane p2 = new Plane();

p2.Capacity = 150;
p2.ManufactureDate = new DateTime(2015, 3, 15);
p2.PlaneType = PlaneType.Airbus;
//initializer d objet
Plane p3 = new Plane
    {
    Capacity = 180,
    ManufactureDate = new DateTime(2012, 7, 20),
    PlaneType = PlaneType.Boeing
};
Console.WriteLine(p);
Passenger pas = new Passenger
{
    FirstName = "John",
    LastName = "Doe",
    EmailAddress = "JohnDoe@gmail.com"
};
Console.WriteLine(pas.CheckProfile("John", "Doe" , "JohnDoe@gmail.com"));
Console.WriteLine(pas.CheckProfile("John", "Doe"));
Console.WriteLine(pas.login("you", "ssef"));
Console.WriteLine(pas.login("John", "Doe", "you@you@gmail.com"));
//Instance DE SERVICE
FlightMethods FM = new FlightMethods();
//alimenter list flights
FM.Flights = AM.ApplicationCore.Domain.TestData.listFlights;
FM.GetFlightDates("Paris");
foreach (var item in FM.GetFlightDates("Paris"))
{
    Console.WriteLine(item);
}
FM.GetFlights("FlightDate","2022,01,01");
FM.ShowFlightDetails(TestData.Airbusplane); 
FM.ShowFlightDetails(p);
int programmedFlights = FM.ProgrammedFlightNumber(DateTime.Now);
Console.WriteLine($"Nombre de vols programmés : {programmedFlights}");
var seniors = FM.SeniorTravellers(TestData.flight1);
foreach (var s in seniors) Console.WriteLine($"{s.FirstName} {s.LastName} - {s.BirthDate:yyyy-MM-dd}");
Passenger p5 = new Passenger { FirstName = "youssef", LastName = "tabbel" };
p5.UpperFullName();
Console.WriteLine(p5.FirstName + p5.LastName);
// 3) DurationAverage pour "Paris" (lambda et query)
double avgLambda = FM.DurationAverage_Lambda("Paris");
double avgQuery = FM.DurationAverage_Query("Paris");
Console.WriteLine($"Moyenne EstimatedDuration (Paris) - Lambda : {avgLambda}");
Console.WriteLine($"Moyenne EstimatedDuration (Paris) - Query  : {avgQuery}");
Console.WriteLine(new string('-', 60));

// 4) OrderedDurationFlights (lambda et query)
Console.WriteLine("Vols triés par EstimatedDuration (desc) - Lambda :");
foreach (var f in FM.OrderedDurationFlights_Lambda())
{
    Console.WriteLine($"FlightId: {f.FlightId}, Dest: {f.Destination}, Duration: {f.EstimatedDuration}");
}
Console.WriteLine(new string('-', 30));
Console.WriteLine("Vols triés par EstimatedDuration (desc) - Query :");
foreach (var f in FM.OrderedDurationFlights_Query())
{
    Console.WriteLine($"FlightId: {f.FlightId}, Dest: {f.Destination}, Duration: {f.EstimatedDuration}");
}
Console.WriteLine(new string('-', 60));

// 5) DestinationGroupedFlights (lambda et query) - affichage
Console.WriteLine("Groupement par destination - Lambda :");
FM.DestinationGroupedFlights_Lambda();
Console.WriteLine(new string('-', 30));
Console.WriteLine("Groupement par destination - Query :");
FM.DestinationGroupedFlights_Query();
Console.WriteLine(new string('-', 60));
