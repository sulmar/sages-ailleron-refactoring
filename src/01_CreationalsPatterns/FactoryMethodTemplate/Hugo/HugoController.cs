using FactoryMethodTemplate.Razor;

namespace FactoryMethodTemplate.Hugo
{
    // Concrete Creator
    public class HugoController : Controller
    {

        protected override IViewEngine CreateViewEngine() // Factory Method
        {
            return new HugoViewEngine();
        }
    }
}
