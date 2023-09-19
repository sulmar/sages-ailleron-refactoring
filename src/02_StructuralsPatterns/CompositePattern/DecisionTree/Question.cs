namespace CompositePattern.DecisionTree
{
    public class Question : Node
    {
        public Question(
            string content, 
            Node positive, 
            Node negative) : base(content)
        {
           PositiveResponse = positive;
           NegativeResponse = negative;
        }

        public Node PositiveResponse { get; }
        public Node NegativeResponse {  get; }

        public static bool Response => Console.ReadKey().Key == ConsoleKey.Y;

        public override void Operation()
        {
            Console.WriteLine(Content);

            if (Response)
            {
                PositiveResponse.Operation();
            }
            else
            {
                NegativeResponse.Operation();
            }
        }
    }
}
