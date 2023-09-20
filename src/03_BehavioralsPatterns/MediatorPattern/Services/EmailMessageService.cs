using MediatorPattern.IServices;
using System;

namespace MediatorPattern.Services
{
    public class EmailMessageService : IMessageService
    {
        public void Send(string number, string message)
        {
            Console.WriteLine($"Send email {message} to {number}");
        }
    }
}