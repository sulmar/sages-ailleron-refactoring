namespace CompositePattern;

// Concrete Component B
public class Group : Component
{
    private List<Component> objects = new List<Component>();

    public void Add(Component shape)
    {
        objects.Add(shape);
    }

    public override void Render()
    {
        Console.WriteLine("Group");

        foreach (var obj in objects)
        {
            obj.Render();            
        }
    }
}