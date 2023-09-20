using ChainOfResponsibilityPattern.Models;

namespace ChainOfResponsibilityPattern.Handlers
{
    // Abstract Handler 
    public abstract class MessageHandler : IMessageHandler
    {
        protected IMessageHandler next;

        public virtual void Handle(Message message)
        {
            next?.Handle(message);
        }

        public void SetNext(IMessageHandler next)
        {
            this.next = next;
        }
    }
}
