using FactoryMethodTemplate.Hugo;
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

    // Concrete Creator
    public class HugoController : Controller
    {
       
        protected override IViewEngine CreateViewEngine() // Factory Method
        {
            return new HugoViewEngine(); 
        }
    }
}
