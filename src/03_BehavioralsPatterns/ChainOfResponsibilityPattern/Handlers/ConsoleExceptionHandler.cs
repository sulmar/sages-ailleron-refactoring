using System;
using ChainOfResponsibilityPattern.Models;

namespace ChainOfResponsibilityPattern.Handlers
{
    public class ConsoleExceptionHandler : MessageHandler
    {
        public override void Handle(Message message)
        {
            try
            {
                base.Handle(message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
