using Excercise1;

ITicketService ticketService = new TicketService(
    new FakeMovieRepository(),
    new ReservationService(),
    new PlaceService(),
    new EmailTicketSender());

var ticketParameters = new TicketParameters
{
    Title = "Akademia pana Kleksa",
    When = DateTime.Parse("2023-09-19 20:00"),
    Place = new Place(1, 'A'),
    Email = "john@example.com"
};


Ticket ticket = ticketService.Buy(ticketParameters);

ticket.PrintTicket();

