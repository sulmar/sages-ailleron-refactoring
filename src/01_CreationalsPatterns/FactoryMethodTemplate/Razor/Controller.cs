using FactoryMethodTemplate.Hugo;
using System.Collections.Generic;

namespace FactoryMethodTemplate.Razor
{
    public class Controller
    {
        private readonly IViewEngine viewEngine;

        public string Render(string viewName, IDictionary<string, object> context)
        {
            IViewEngine engine = CreateViewEngine(); // Factory Method
            var html = engine.Render(viewName, context);

            return html;
        }

        protected virtual IViewEngine CreateViewEngine()
        {
            return new RazorViewEngine();
        }
    }

    public class HugoController : Controller
    {
        protected override IViewEngine CreateViewEngine()
        {
            return new HugoViewEngine();
        }
    }
}
