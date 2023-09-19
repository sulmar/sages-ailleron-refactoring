using System;

namespace PrototypePattern
{
    public class Customer : ICloneable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public object Clone()
        {
            return MemberwiseClone(); // płytka kopia (Shallow Copy)
        }

        // głębokia kopia (Deep Copy)
        // https://github.com/AlenToma/FastDeepCloner
    }

}
