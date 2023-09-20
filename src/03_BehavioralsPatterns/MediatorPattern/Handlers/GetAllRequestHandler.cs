using MediatorPattern.IServices;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using MediatorPattern.Models;
using System.Collections.Generic;
using MediatorPattern.Requests.Customers;

namespace MediatorPattern.Handlers
{
    public class GetAllRequestHandler : IRequestHandler<GetCustomersRequest, ICollection<Customer>>
    {
        private readonly ICustomerRepository customerRepository;

        public GetAllRequestHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public Task<ICollection<Customer>> Handle(GetCustomersRequest request, CancellationToken cancellationToken)
        {
            var customers = customerRepository.Get();

            return Task.FromResult(customers);
        }
    }
}
