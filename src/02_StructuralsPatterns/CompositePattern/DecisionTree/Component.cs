using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern.DecisionTree
{
    // Abstract Component
    public abstract class Node
    {
        public string Content { get; }

        protected Node(string content)
        {
            Content = content;
        }

        public abstract void Operation();
    }

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


    public class Decision : Node
    {
        public Decision(string content) : base(content)
        {
        }

        public override void Operation()
        {
            Console.WriteLine(Content);
        }
    }
}
