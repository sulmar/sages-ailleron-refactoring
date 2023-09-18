using System.Collections.Generic;

namespace FactoryMethodTemplate
{
    // Abstract Product
    public interface IViewEngine
    {
        string Render(string viewName, IDictionary<string, object> context);
    }
}
