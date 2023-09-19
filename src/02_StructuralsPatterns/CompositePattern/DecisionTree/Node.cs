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
}
