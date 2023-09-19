namespace CompositePattern;

class Program
{
    static void Main(string[] args)
    {
        Group root = new();
        root.Add(new Shape());
        root.Add(new Shape());

        Group group = new Group();
        group.Add(new Shape());

        root.Add(group);

        root.Render();
        

        // DecisionTree();

    }

    private static void DecisionTree()
    {
        Console.Write("Are you developer?");

        if (Response)
        {

            Console.Write("Do you know C#?");

            if (Response)
            {
                Console.WriteLine("Welcome on Design Pattern in C# Course!");
            }
            else
            {
                Console.WriteLine("The Course is not for you.");
            }

        }
        else
        {
            Console.WriteLine("Have a nice day.");
        }
    }

    public static bool Response => Console.ReadKey().Key == ConsoleKey.Y;

}
