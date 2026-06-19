using System;

namespace BusTicketingSystem.Hardware
{
    public class PrintingMachine
    {
        private bool _isOnline = false;

        public bool IsHardwareAvailable()
        {
            return _isOnline;
        }

        public void SetOnline(bool online)
        {
            _isOnline = online;
            Console.WriteLine($"Printing Machine is now {(_isOnline ? "Online" : "Offline")}");
        }

        public void PrintTicket(string ticketData)
        {
            if (!_isOnline)
            {
                throw new InvalidOperationException("Printing Machine is offline");
            }
            Console.WriteLine($"Printing Ticket: {ticketData}");
        }
    }
}
