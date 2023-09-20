using FacadePattern.Models;
using FacadePattern.Repositories;
using System;

namespace FacadePattern.Services
{
    public class TicketService : ITicketService
    {
        private readonly IRailwayConnectionRepository railwayConnectionRepository;
        private readonly TicketCalculator ticketCalculator;
        private readonly ReservationService reservationService;
        private readonly PaymentService paymentService;
        private readonly EmailService emailService;

        public TicketService(IRailwayConnectionRepository railwayConnectionRepository, 
            TicketCalculator ticketCalculator, 
            ReservationService reservationService, 
            PaymentService paymentService, 
            EmailService emailService)
        {
            this.railwayConnectionRepository = railwayConnectionRepository;
            this.ticketCalculator = ticketCalculator;
            this.reservationService = reservationService;
            this.paymentService = paymentService;
            this.emailService = emailService;
        }

        public Ticket Buy(TicketParameters parameters)
        {
            RailwayConnection railwayConnection = railwayConnectionRepository.Find(parameters.From, parameters.To, parameters.When);
            decimal price = ticketCalculator.Calculate(railwayConnection, parameters.NumberOfPlaces);
            Reservation reservation = reservationService.MakeReservation(railwayConnection, parameters.NumberOfPlaces);
            Ticket ticket = new Ticket { RailwayConnection = reservation.RailwayConnection, NumberOfPlaces = reservation.NumberOfPlaces, Price = price };
            Payment payment = paymentService.CreateActivePayment(ticket);

            if (payment.IsPaid)
            {
                emailService.Send(ticket);
            }

            return ticket;
        }

        public void Cancel(Ticket ticket)
        {
            throw new NotImplementedException();
        }
    }
}
