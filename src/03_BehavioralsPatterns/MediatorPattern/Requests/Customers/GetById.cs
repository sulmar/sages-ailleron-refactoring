using MediatR;
using MediatorPattern.Models;

namespace MediatorPattern.Requests.Customers
{
    public class GetById : IRequest<Customer>
    {
        public int Id { get; private set; }

        public GetById(int id)
        {
            Id = id;
        }
    }
}
