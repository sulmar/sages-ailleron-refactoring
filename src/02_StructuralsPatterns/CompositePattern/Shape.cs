namespace CompositePattern;


// Abstract Component
public abstract class Component
{
    public abstract void Render();
}

// Concrete Component A
// Leaf
public class Shape : Component
{
    public override void Render()
    {
        Console.WriteLine("Render shape");
    }
}