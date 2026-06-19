using System;
using System.Collections.Generic;

namespace BusTicketingSystem.Models
{
    public class Route
    {
        public string Id { get; set; }
        public string RouteName { get; set; }
        public List<string> Locations { get; set; }
        public decimal FarePerKm { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
