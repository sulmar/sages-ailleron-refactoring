using System;
using System.Text.RegularExpressions;
using ChainOfResponsibilityPattern.Models;

namespace ChainOfResponsibilityPattern.Handlers
{
    public class ExtractTaxNumberHandler : MessageHandler
    {
        const string pattern = @"\b(\d{10}|\d{3}-\d{3}-\d{2}-\d{2})\b";

        public override void Handle(MessageContext context)
        {
            Regex regex = new Regex(pattern);
            Match match = regex.Match(context.Message.Body);

            if (match.Success)
            {
                string taxNumber = match.Value;

                context.TaxNumber = taxNumber;
            }
            else
            {
                throw new FormatException();
            }

            base.Handle(context);
        }
    }
}
