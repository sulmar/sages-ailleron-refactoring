using ChainOfResponsibilityPattern.Models;

namespace ChainOfResponsibilityPattern.Handlers
{
    // Abstract Handler 
    public abstract class MessageHandler : IMessageHandler
    {
        protected IMessageHandler next;

        public virtual void Handle(MessageContext context)
        {
            next?.Handle(context);
        }

        public void SetNext(IMessageHandler next)
        {
            this.next = next;
        }
    }
}
