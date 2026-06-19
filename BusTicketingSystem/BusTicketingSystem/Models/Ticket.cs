using System;

namespace BusTicketingSystem.Models
{
    public class Ticket
    {
        public string Id { get; set; }
        public string RouteId { get; set; }
        public string ConductorId { get; set; }
        public string PassengerId { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public decimal Fare { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsPrinted { get; set; }
    }
}
