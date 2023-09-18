using System.Collections.Generic;

namespace FactoryMethodTemplate
{
    public interface IViewEngine
    {
        string Render(string viewName, IDictionary<string, object> context);
    }
}
