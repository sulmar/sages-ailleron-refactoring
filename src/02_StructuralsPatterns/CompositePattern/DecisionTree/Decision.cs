using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern.DecisionTree
{

    class FluentNodeBuilder
    {
        private string message;
        private Node positive;
        private Node negative;

        public FluentNodeBuilder AddQuestion(string message)
        {
            this.message = message;
            return this;
        }

        public FluentNodeBuilder WithPositiveResponse(Node positive)
        {
            this.positive = positive;
            return this;
        }

        public FluentNodeBuilder WithNegativeResponse(Node negative)
        {
            this.negative = negative;
            return this;
        }

        public Decision BuildDecision()
        {
            return new Decision(message);
        }

        public Question BuildQuestion()
        {
            return new Question(message, positive, negative);
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
