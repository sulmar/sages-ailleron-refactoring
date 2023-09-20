using Stateless;
using System;
using System.Diagnostics.Tracing;

namespace StatePattern
{
    // Install-Package stateless

    public class Order
    {
        private readonly StateMachine<OrderStatus, OrderTrigger> machine = new StateMachine<OrderStatus, OrderTrigger>(OrderStatus.Placement);

        public Order(OrderStatus initialState = OrderStatus.Placement)
        {
            Id = Guid.NewGuid();
            OrderDate = DateTime.Now;            

            machine.Configure(OrderStatus.Placement)
                .OnEntry(() => Console.WriteLine("Twoje zamówienie jest właśnie kompletowane..."))
                .PermitIf(OrderTrigger.Confirm, OrderStatus.Picking, () => IsPaid);

            machine.Configure(OrderStatus.Picking)
                .Permit(OrderTrigger.Confirm, OrderStatus.Shipping)
                .Permit(OrderTrigger.Cancel, OrderStatus.Canceled);

            machine.Configure(OrderStatus.Shipping)
                .Permit(OrderTrigger.Confirm, OrderStatus.Delivered);

            machine.Configure(OrderStatus.Delivered)
                .Permit(OrderTrigger.Cancel, OrderStatus.Canceled);

            // https://camunda.com/
        }

        public string Graph => Stateless.Graph.UmlDotGraph.Format(machine.GetInfo());

        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status => machine.State;
        public bool IsPaid { get; private set; }

        public void Paid()
        {
            IsPaid = true;
        }

        public void Confirm() => machine.Fire(OrderTrigger.Confirm);
        public void Cancel() => machine.Fire(OrderTrigger.Cancel);

        public override string ToString() => $"Order {Id} created on {OrderDate}{Environment.NewLine}";

        public virtual bool CanConfirm => machine.CanFire(OrderTrigger.Confirm);
        public virtual bool CanCancel => machine.CanFire(OrderTrigger.Cancel);
    }

    public enum OrderStatus
    {
        // The customer places an order on the company's website
        Placement,
        // The items from the order are picked from the inventory
        Picking,
        // The package is handed over to the shipping carrier or courier for delivery to the customer.      
        Shipping,
        // The package has been successfully delivered to the customer's specified address.
        Delivered,
        // The order has been successfully delivered, and the transaction is considered complete.
        Completed,
        // The customer canceled order
        Canceled

    }

    public enum OrderTrigger
    {
        Confirm,
        Cancel
    }

}
