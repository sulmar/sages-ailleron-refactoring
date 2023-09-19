using Excercise1;

Ticket ticket = new Ticket { MovieName = "Akademia pana Kleksa", ReleaseYear = 1983, Category = "Fantasy", AgeCategory = "G" };

ticket.Reserve(1, 'A');

ticket.CalculatePrice(20);

ticket.PrintTicket();
ticket.SendByEmail("john@example.com");