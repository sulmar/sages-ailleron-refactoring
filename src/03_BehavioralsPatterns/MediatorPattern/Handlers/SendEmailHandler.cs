using MediatorPattern.Events;
using MediatorPattern.IServices;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MediatorPattern.Handlers
{
    public class SendEmailHandler : INotificationHandler<AddedCustomerEvent>
    {
        private readonly IMessageService messageService;

        public SendEmailHandler(IMessageService messageService)
        {
            this.messageService = messageService;
        }

        public Task Handle(AddedCustomerEvent notification, CancellationToken cancellationToken)
        {
            var customer = notification.Customer;

            messageService.Send(customer.Email, $"Welcome {customer.FullName}");

            return Task.CompletedTask;
        }
    }
}
