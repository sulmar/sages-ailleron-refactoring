using System.Collections.Generic;

namespace FactoryMethodTemplate.Razor
{
    // Creator
    public class Controller
    {
        private readonly IViewEngine viewEngine;

        public string Render(string viewName, IDictionary<string, object> context)
        {
            // Product
            IViewEngine engine = CreateViewEngine(); // Factory Method
            var html = engine.Render(viewName, context);

            return html;
        }

        protected virtual IViewEngine CreateViewEngine()
        {
            return new RazorViewEngine();
        }
    }
}
