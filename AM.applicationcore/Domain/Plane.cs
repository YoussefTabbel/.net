using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.applicationcore.Domain
{
    public class Plane
    {
        //private int capacity;
        //public int getCapacity()
        //{
        //    return capacity;
        //}
        //public void setCapacity(int capacity)
        //{
        //    this.capacity = capacity;
        //}
        public int Capacity { get; set; }
        public DateTime ManufactureDate { get; set; }
        public int PlaneId { get; set; }
        public PlaneType PlaneType { get; set; }
        public ICollection<Flight> Flights { get; set; }
    }

}
