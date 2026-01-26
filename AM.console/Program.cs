// See https://aka.ms/new-console-template for more information
using AM.applicationcore.Domain;

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
