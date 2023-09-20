using MediatR;
using MediatorPattern.Models;
using System.Collections.Generic;

namespace MediatorPattern.Requests.Customers
{
    public class GetCustomersRequest : IRequest<ICollection<Customer>>
    {
    }
}
