using BusTicketingSystem.Hardware;
using BusTicketingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusTicketingSystem.Services
{
    public class TicketingService : ITicketingService
    {
        private List<Ticket> _tickets = new List<Ticket>();
        private List<User> _conductors = new List<User>();
        private PrintingMachine _printer = new PrintingMachine();

        public Ticket CreateTicket(Ticket ticket)
        {
            ticket.Id = Guid.NewGuid().ToString();
            ticket.CreatedDate = DateTime.Now;
            _tickets.Add(ticket);
            return ticket;
        }

        public List<Ticket> GetAllTickets()
        {
            return _tickets;
        }

        public Ticket GetTicketById(string ticketId)
        {
            return _tickets.FirstOrDefault(t => t.Id == ticketId);
        }

        public Ticket UpdateTicket(Ticket ticket)
        {
            var existingTicket = GetTicketById(ticket.Id);
            if (existingTicket != null)
            {
                _tickets.Remove(existingTicket);
                _tickets.Add(ticket);
            }
            return ticket;
        }

        public void DeleteTicket(string ticketId)
        {
            var ticket = GetTicketById(ticketId);
            if (ticket != null)
            {
                _tickets.Remove(ticket);
            }
        }

        public List<Ticket> GetConductorTickets(string conductorId, DateTime date)
        {
            return _tickets.Where(t => t.ConductorId == conductorId && t.CreatedDate.Date == date.Date).ToList();
        }

        public bool AuthenticateConductor(string username, string password)
        {
            var conductor = _conductors.FirstOrDefault(c => c.Name == username && c.Password == password);
            return conductor != null;
        }

        public User GetConductor(string conductorId)
        {
            return _conductors.FirstOrDefault(c => c.Id == conductorId);
        }

        public List<string> GetLocationsByRoute(string routeId)
        {
            // Implementation to get locations for a route
            return new List<string> { "Start", "Middle", "End" };
        }

        public decimal CalculateFare(string routeId, string fromLocation, string toLocation)
        {
            // Implementation to calculate fare between two locations
            return 50.00m;
        }

        public double GetDistance(string routeId, string fromLocation, string toLocation)
        {
            // Implementation to get distance between two locations
            return 100.0;
        }

        public Ticket CreateAndPrintTicket(string routeId, string conductorId, string passengerId, string fromLocation)
        {
            if (!_printer.IsHardwareAvailable())
            {
                throw new InvalidOperationException("Printing hardware is not available");
            }

            var ticket = new Ticket
            {
                Id = Guid.NewGuid().ToString(),
                RouteId = routeId,
                ConductorId = conductorId,
                PassengerId = passengerId,
                FromLocation = fromLocation,
                CreatedDate = DateTime.Now
            };

            _tickets.Add(ticket);
            _printer.PrintTicket($"Ticket {ticket.Id}: {passengerId} - {fromLocation}");
            return ticket;
        }

        public string GetHardwareStatus()
        {
            return _printer.IsHardwareAvailable() ? "Online" : "Offline";
        }

        public bool IsHardwareAvailable()
        {
            return _printer.IsHardwareAvailable();
        }
    }
}
