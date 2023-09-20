using MediatorPattern.Events;
using MediatorPattern.IServices;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace MediatorPattern.Handlers
{
    public class AddCustomerToRepository : INotificationHandler<AddedCustomerEvent>
    {
        private readonly ICustomerRepository customerRepository;

        public AddCustomerToRepository(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public Task Handle(AddedCustomerEvent notification, CancellationToken cancellationToken)
        {
            customerRepository.Add(notification.Customer);

            return Task.CompletedTask;
        }
    }
}
