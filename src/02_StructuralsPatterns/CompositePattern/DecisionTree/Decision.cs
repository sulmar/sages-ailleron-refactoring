using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern.DecisionTree
{


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
