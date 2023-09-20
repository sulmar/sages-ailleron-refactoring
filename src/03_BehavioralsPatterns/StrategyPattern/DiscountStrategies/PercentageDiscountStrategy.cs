namespace StrategyPattern.DiscountStrategies
{
    public class PercentageDiscountStrategy : IDiscountStrategy
    {
        private decimal percentage;

        public PercentageDiscountStrategy(decimal percentage)
        {
            this.percentage = percentage;
        }

        public decimal Discount(Order order)
        {
            return order.Amount * percentage;
        }

        public decimal NoDiscount()
        {
            return decimal.Zero;
        }
    }

    // Lua
    /*
    public interface IScriptRuntimeAdapter
    {
        public decimal Execute(string script);
    }

    public class LuaScriptRuntimeAdapter : IScriptRuntimeAdapter
    {
        private Lua state = new Lua();
        public decimal Execute(string script)
        {
            var res = state.DoString(script);

            return res;
        }
    }

    public class DynamicDiscountStrategy : IDiscountStrategy
    {
        string script = "order.Amount * percentage";

        private ScriptRuntime scriptRuntime = new ScriptRuntime();

        public decimal Discount(Order order)
        {
            // TODO: C# 
            scriptRuntime.Execute()
        }

        public decimal NoDiscount()
        {
            // TODO: C#
        }
    }
    */
}
