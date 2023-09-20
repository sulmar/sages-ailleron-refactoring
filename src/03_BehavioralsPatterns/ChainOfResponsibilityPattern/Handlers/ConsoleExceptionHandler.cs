using System;
using ChainOfResponsibilityPattern.Models;

namespace ChainOfResponsibilityPattern.Handlers
{
    public class ConsoleExceptionHandler : MessageHandler
    {
        public override void Handle(MessageContext context)
        {
            try
            {
                base.Handle(context);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
