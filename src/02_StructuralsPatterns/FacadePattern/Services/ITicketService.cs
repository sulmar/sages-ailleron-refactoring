using FacadePattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.Services
{
    public struct TicketParameters
    {
        public string From { get; set; }
        public string To { get; set; }
        public DateTime When { get; set; }
        public byte NumberOfPlaces { get; set; }
        public bool HasDog { get; set; }

        public TicketParameters(string from, string to, DateTime when, byte numberOfPlaces, bool hasDog = false)
        {
            From = from;
            To = to;
            When = when;
            NumberOfPlaces = numberOfPlaces;
            HasDog = hasDog;
        }
    }


    // Abstract Fasada
    public interface ITicketService
    {
        Ticket Buy(TicketParameters parameters); 
        void Cancel(Ticket ticket);
    }
}
