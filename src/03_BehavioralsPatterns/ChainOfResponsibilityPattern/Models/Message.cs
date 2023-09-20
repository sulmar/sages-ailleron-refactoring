using ChainOfResponsibilityPattern.Handlers;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibilityPattern.Models
{

    public class Message
    {
        public string From { get; set; }
        public string Title { get; set; }   
        public string Body { get; set; }        
    }

    public class MessageContext
    {
        public Message Message { get; set; }
        public string TaxNumber { get; set; }

        public MessageContext(Message message)
        {
            Message = message;
        }
    }

    public class MessageProcessor
    {
        private string[] whiteList;

        private MessageHandler handler;

        public MessageProcessor(string[] whiteList)
        {
            this.whiteList = whiteList;

            MessageHandler exceptionHandler = new ConsoleExceptionHandler();
            MessageHandler whiteListHandler = new FromWhiteListHandler(whiteList);
            MessageHandler titleHandler = new TitleContainsTextHandler("Order");
            MessageHandler taxNumberHandler = new ExtractTaxNumberHandler();

            exceptionHandler.SetNext(whiteListHandler);
            whiteListHandler.SetNext(titleHandler);
            titleHandler.SetNext(taxNumberHandler);

            handler = exceptionHandler;
        }

        public string Process(Message message)
        {
            handler.Handle(new MessageContext(message));

            throw new NotImplementedException();
        }

       

      
    }
}
