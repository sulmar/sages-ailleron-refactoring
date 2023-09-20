using MediatorPattern.Models;
using MediatR;

namespace MediatorPattern.Events
{   
    public class AddedCustomerEvent : INotification // marker inferface
    {
        public Customer Customer { get; private set; }

        public AddedCustomerEvent(Customer customer)
        {
            Customer = customer;
        }
    }
}
