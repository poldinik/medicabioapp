using System;
namespace Medicabio.Models
{
    public class Location
    {
        public string Uri { get; set; }
        public string Name { get; set; }
        public int MaxSeats { get; set; }
        public string City { get; set; }
        public string Cap { get; set; }
        public string Address { get; set; }
        public string AddressRegion { get; set; }
    }
}
