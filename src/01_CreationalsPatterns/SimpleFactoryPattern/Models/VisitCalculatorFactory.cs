namespace SimpleFactoryPattern
{
    public class VisitCalculatorFactory
    {
        private readonly Dictionary<string, Type> types = new Dictionary<string, Type>();

        public VisitCalculatorFactory()
        {
            types.Add("N", typeof(NfzVisitCalculator));
            types.Add("P", typeof(PrivateVisitCalculator));
            types.Add("F", typeof(CompanyVisitCalculator));
            types.Add("T", typeof(TeleVisitCalculator));
        }

        public IVisitCalculator Create(string symbol)
        {
            Type visitType = types[symbol];

            return (IVisitCalculator)Activator.CreateInstance(visitType);
        }
    }
}
