using ChainOfResponsibilityPattern.Models;

namespace ChainOfResponsibilityPattern.Handlers
{
    // Abstract Handler (interface)
    public interface IMessageHandler
    {
        void SetNext(IMessageHandler next);
        void Handle(Message message);
    }
}
