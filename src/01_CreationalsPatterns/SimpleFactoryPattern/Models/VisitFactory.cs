namespace SimpleFactoryPattern
{
    public class VisitFactory
    {
        private readonly Dictionary<string, Type> types = new Dictionary<string, Type>();

        public VisitFactory()
        {
            types.Add("N", typeof(NfzVisit));
            types.Add("P", typeof(PrivateVisit));
            types.Add("F", typeof(CompanyVisit));
            types.Add("T", typeof(TeleVisit));
        }

        public Visit Create(string symbol)
        {
            Type visitType = types[symbol];

            return (Visit)Activator.CreateInstance(visitType);
        }
    }
}
