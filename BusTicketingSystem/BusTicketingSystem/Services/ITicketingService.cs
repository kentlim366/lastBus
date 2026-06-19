using BusTicketingSystem.Models;
using System;
using System.Collections.Generic;

namespace BusTicketingSystem.Services
{
    public interface ITicketingService
    {
        // Ticket Operations
        Ticket CreateTicket(Ticket ticket);
        List<Ticket> GetAllTickets();
        Ticket GetTicketById(string ticketId);
        Ticket UpdateTicket(Ticket ticket);
        void DeleteTicket(string ticketId);
        List<Ticket> GetConductorTickets(string conductorId, DateTime date);

        // Conductor Operations
        bool AuthenticateConductor(string username, string password);
        User GetConductor(string conductorId);

        // Route Operations
        List<string> GetLocationsByRoute(string routeId);
        decimal CalculateFare(string routeId, string fromLocation, string toLocation);
        double GetDistance(string routeId, string fromLocation, string toLocation);

        // Ticket Printing
        Ticket CreateAndPrintTicket(string routeId, string conductorId, string passengerId, string fromLocation);

        // Hardware Operations
        string GetHardwareStatus();
        bool IsHardwareAvailable();
    }
}
