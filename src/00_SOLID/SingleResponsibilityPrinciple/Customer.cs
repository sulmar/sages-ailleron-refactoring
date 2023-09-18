// Zasada pojedynczej odpowiedzialności (Single-Responsibility Principle) - SRP

// Każda klasa powinna być odpowiedzialna za jedną konkretną rzecz.
// Klasa powinna mieć tylko jeden powód do zmiany.

// #1 Przykład łamiący zasadę pojedynczej odpowiedzialności

using System.Reflection;

class Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string City { get; set; }
    public string PostCode { get; set; }
    public string Street { get; set; }
    public string Email { get; set; }
}


interface IValidator
{
    void Validate(string content);
}

class EmailValidator : IValidator
{
    public void Validate(string email)
    {
        if (!email.Contains("@") || !email.Contains("."))
        {
            throw new FormatException("Email address is a invalid format!");
        }
    }
}

class PostCodeValidator : IValidator
{
    public void Validate(string postcode)
    {
        if (postcode.Length != 5)
        {
            throw new FormatException("Post code is a invalid format!");
        }
    }
}



// Przykład #2 łamiący zasadę pojedynczej odpowiedzialności

public class Student
{
    public string Name { get; set; }
    public string Email { get; set; }
}

public class Registration
{
    public void Register(Student student)
    {
        // Register a student
        // Perform validation and save to DB
        Console.WriteLine("Registering the student");
    }

    public void Unregister(Student student)
    {
        Console.WriteLine("Unregistering the student");
    }
}

public class Course
{
    public string Title { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
}

public class CourseEnrollment
{
    public void EnrollInCourse(Student student, Course course)
    {
        // Enroll the student in a course
        // Perform validation and save to DB
        Console.WriteLine("Enrolling to the course");
    }
}

// Przykład #3


namespace Example3
{

    public class User
    {
        public string Username { get; set; }
        public string HashedPassword { get; set; }
        public string Email { get; set; }
    }

    public class Authentication
    {
        // Perform user login
        public void Login(string username, string password)
        {
        }

        // User logout
        public void Logout()
        {
        }
    }

    public class Registration
    {
        //Register a user
        public void RegisterUser(User user)
        {
        }
    }
}