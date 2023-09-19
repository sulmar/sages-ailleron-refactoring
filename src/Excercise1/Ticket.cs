using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise1
{


    public class TicketCalculatorFactory
    {
        private static decimal basePrice = 20m;

        public static ITicketCalculator Create()
        {
            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    return new DayOfWeekTicketCalculator(basePrice, 0.8m);
                default:
                    return new RegularTicketCalculator(basePrice);
            }

        }
    }

    public interface ITicketSender
    {
        void SendTicket(Ticket ticket, string to);
    }

    public class EmailTicketSender : ITicketSender
    {
        public void SendTicket(Ticket ticket, string to)
        {
            SendByEmail(ticket, to);
        }

        private void SendByEmail(Ticket ticket, string emailAddress)
        {
            Console.WriteLine($"{ticket} sent to {emailAddress}");
        }
    }

    public class Reservation
    {
        public Movie Movie { get; set; }
        public Place Place { get; set; }
        public DateTime When { get; set; }
    }

    public struct TicketParameters
    {
        public string Title { get; set; }
        public DateTime When { get; set; }
        public Place Place { get; set; }
        public string Email { get; set; }
    }

    // Fasade
    public interface ITicketService
    {
        Ticket Buy(TicketParameters ticketParameters);

        void Cancel(Ticket ticket);
    }

    public interface ITicketCalculator
    {
        decimal Calculate(TicketParameters parameters);
    }

    public class RegularTicketCalculator : ITicketCalculator
    {
        private readonly decimal basePrice;

        public RegularTicketCalculator(decimal basePrice)
        {
            this.basePrice = basePrice;
        }

        public decimal Calculate(TicketParameters parameters)
        {
            return basePrice;
        }
    }

    public class DayOfWeekTicketCalculator : ITicketCalculator
    {
        private readonly decimal basePrice;

        private readonly decimal percentage;

        public DayOfWeekTicketCalculator(decimal basePrice, decimal percentage)
        {
            this.basePrice = basePrice;
            this.percentage = percentage;
        }

        public decimal Calculate(TicketParameters parameters)
        {
            return basePrice * percentage;
        }
    }

    public interface IMovieRepository
    {
        Movie? GetByTitle(string title);
    }

    public class FakeMovieRepository : IMovieRepository
    {
        private readonly IList<Movie> movies;
        public FakeMovieRepository()
        {
            movies = new List<Movie>
            {
                new Movie { MovieName = "Akademia pana Kleksa", ReleaseYear = 1983, Category = "Fantasy", AgeCategory = AgeCategory.G }
            };
        }

        public Movie? GetByTitle(string title)
        {
            return movies.FirstOrDefault(m => m.MovieName.Contains(title));
        }
    }


    public class TicketService : ITicketService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IReservationService reservationService;
        private readonly PlaceService placeService;
        private readonly ITicketSender ticketSender;
        private readonly ITicketCalculator ticketCalculator;

        public TicketService(
            IMovieRepository movieRepository,
            IReservationService reservationService,
            PlaceService placeService,
            ITicketSender ticketSender)
        {
            _movieRepository = movieRepository;

            this.reservationService = reservationService;
            this.placeService = placeService;
            this.ticketSender = ticketSender;

            ticketCalculator = TicketCalculatorFactory.Create();
        }

        public Ticket Buy(TicketParameters ticketParameters)
        {
            var movie = _movieRepository.GetByTitle(ticketParameters.Title);

            if (movie == null)
                throw new KeyNotFoundException(ticketParameters.Title);


            decimal price = ticketCalculator.Calculate(ticketParameters);


            Place place;
            Reservation reservation = null;

            do
            {
                place = placeService.GenerateRandomPlace();

            } while (!reservationService.TryMakeReservation(movie, place, out reservation) && reservationService.IsAnyPlaceAvailable);

            Ticket ticket = new Ticket(reservation.Movie, reservation.Place, price);

            ticketSender.SendTicket(ticket, ticketParameters.Email);

            return ticket;

        }

        public void Cancel(Ticket ticket)
        {
            throw new NotImplementedException();
        }
    }


    public class PlaceService
    {
        private readonly Random random = new Random();
        public Place GenerateRandomPlace()
        {
            int row = random.Next(1, 11); // Random row between 1 and 10
            char seat = (char)random.Next('A', 'J'); // Random seat between A and J

            return new Place(row, seat);
        }
    }

    public interface IReservationService
    {
        void Cancel(Reservation reservation);
        bool TryMakeReservation(Movie movie, Place place, out Reservation reservation);
        bool IsAnyPlaceAvailable { get; }
    }

    public class ReservationService : IReservationService
    {
        private readonly IDictionary<Place, bool> places = new Dictionary<Place, bool>();

        public ReservationService()
        {
            int[] rows = Enumerable.Range(1, 11).ToArray(); // Generate row between 1 and 10
            char[] seats = Enumerable.Range('A', 10).Select(i => (char)i).ToArray(); // Generate seat between A and J

            foreach (var row in rows)
            {
                foreach (var seat in seats)
                {
                    places.Add(new Place(row, seat), false);
                }
            }
        }

        public bool TryMakeReservation(Movie movie, Place place, out Reservation reservation)
        {
            reservation = null;

            if (places.TryGetValue(place, out var busy))
            {
                if (busy)
                {
                    return false;
                }
                else
                {
                    places[place] = true;
                    reservation = new Reservation { Movie = movie, Place = place };
                    return true;
                }
            }
            else
            {
                throw new ApplicationException($"Place {place} not exists.");
            }


        }

        public void Cancel(Reservation reservation)
        {

        }

        public bool IsAnyPlaceAvailable => places.All(p => p.Value == true);
    }

    public enum AgeCategory
    {
        G,
        PG,
        PG13,
        R,
        NC17
    }

    public class Movie
    {
        public string MovieName { get; set; }
        public int ReleaseYear { get; set; }
        public AgeCategory AgeCategory { get; set; }
        public string Category { get; set; }

        public Movie()
        {
            AgeCategory = AgeCategory.G;
        }

        public override string ToString()
        {
            return $"Movie: {MovieName} {ReleaseYear}";
        }
    }

    public record Place(int Row, char Seat)
    {
        public override string ToString()
        {
            return $"{Seat}{Row}";
        }
    }

    public class Ticket
    {
        public Ticket(Movie movie, Place place, decimal price)
        {
            Movie = movie;
            Place = place;
            Price = price;
        }

        public Movie Movie { get; set; }

        public Place Place { get; set; }
        public decimal Price { get; set; }
        public string Email { get; set; }

        public void PrintTicket()
        {
            Console.WriteLine(FullDescription);
        }
        public string FullDescription => $"Ticket Movie: {Movie}, Place: {Place}";
    }

}
