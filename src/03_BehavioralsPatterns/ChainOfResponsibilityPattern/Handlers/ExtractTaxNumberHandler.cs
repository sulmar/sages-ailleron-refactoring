using System;
using System.Text.RegularExpressions;
using ChainOfResponsibilityPattern.Models;

namespace ChainOfResponsibilityPattern.Handlers
{
    public class ExtractTaxNumberHandler : MessageHandler
    {
        const string pattern = @"\b(\d{10}|\d{3}-\d{3}-\d{2}-\d{2})\b";

        public override void Handle(Message message)
        {
            Regex regex = new Regex(pattern);
            Match match = regex.Match(message.Body);

            if (match.Success)
            {
                string taxNumber = match.Value;

                // TODO: extract number
                // return taxNumber;
            }
            else
            {
                throw new FormatException();
            }

            base.Handle(message);
        }
    }
}
