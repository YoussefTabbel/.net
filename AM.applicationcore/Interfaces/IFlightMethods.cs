using System;
using System.Collections.Generic;
using AM.applicationcore.Domain;

namespace AM.applicationcore.Interfaces
{
    public interface IFlightMethods
    {
        IEnumerable<DateTime> GetFlightDates(string destination);
        void GetFlights(string filterType, string filterValue); 

        int ProgrammedFlightNumber(DateTime startDate);

        IEnumerable<Traveller> SeniorTravellers(Flight flight);

        double DurationAverage_Lambda(string destination);
        double DurationAverage_Query(string destination);

        IEnumerable<Flight> OrderedDurationFlights_Lambda();
        IEnumerable<Flight> OrderedDurationFlights_Query();

        void DestinationGroupedFlights_Lambda();
        void DestinationGroupedFlights_Query();
    }
}

