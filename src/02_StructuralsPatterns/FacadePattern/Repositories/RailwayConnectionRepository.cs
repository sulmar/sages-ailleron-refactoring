using FacadePattern.Models;
using FacadePattern.Services;
using System;

namespace FacadePattern.Repositories
{
    public interface IRailwayConnectionRepository
    {
        RailwayConnection Find(string from, string to, DateTime when);
    }

    public class PkpRailwayConnectionRepository : IRailwayConnectionRepository
    {
        public RailwayConnection Find(string from, string to, DateTime when)
        {
            return new RailwayConnection { From = from, To = to, When = when, Distance = 1000 };
        }
    }

    public class RailwayConnectionService
    {
        private readonly IRailwayConnectionRepository repository;

        public RailwayConnection Find(TicketParameters parameters)
        {
            var railwayConnection = repository.Find(parameters.From, parameters.To, parameters.When);
            return railwayConnection;
        }
    }
}
