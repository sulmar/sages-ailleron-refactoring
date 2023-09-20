using CompositePattern.DecisionTree;

namespace CompositePattern;

class Program
{
    static void Main(string[] args)
    {
        // TreeTest();

        DecisionTreeBuilderTest();

        DecisionTree();

    }

    private static void TreeTest()
    {
        Group root = new();
        root.Add(new Shape());
        root.Add(new Shape());

        Group group = new Group();
        group.Add(new Shape());

        root.Add(group);

        root.Render();
    }

    private static void DecisionTreeBuilderTest()
    {
        Node welcome = new FluentNodeBuilder().AddQuestion("Welcome on Design Pattern in C# Course!").BuildDecision();
        Node notcourseforyou = new FluentNodeBuilder().AddQuestion("The Course is not for you.").BuildDecision();
        Node notwelcome = new FluentNodeBuilder().AddQuestion("Have a nice day.").BuildDecision();

        Node csharp = new FluentNodeBuilder()
            .AddQuestion("Do you know C#?")
            .WithPositiveResponse(welcome)
            .WithNegativeResponse(notcourseforyou)
            .BuildQuestion();

        Node developer = new FluentNodeBuilder()
            .AddQuestion("Are you developer?")
            .WithPositiveResponse(csharp)
            .WithNegativeResponse(notwelcome)
            .BuildQuestion();

        developer.Operation();
    }

    private static void DecisionTree()
    {
        Node welcome = new Decision("Welcome on Design Pattern in C# Course!");
        Node notcourseforyou = new Decision("The Course is not for you.");
        Node notwelcome = new Decision("Have a nice day.");

        Node csharp = new Question("Do you know C#?", welcome, notcourseforyou);
        Node developer = new Question("Are you developer?", csharp, notwelcome);

        developer.Operation();
        
        
    }

    public static bool Response => Console.ReadKey().Key == ConsoleKey.Y;

}
