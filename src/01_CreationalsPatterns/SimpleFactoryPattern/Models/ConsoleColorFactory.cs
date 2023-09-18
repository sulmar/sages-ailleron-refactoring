namespace SimpleFactoryPattern
{
    // Factory
    public class ConsoleColorFactory
    {
        public static ConsoleColor Create(decimal amount) => amount switch
        {
            0 => ConsoleColor.Green,
            >= 200 => ConsoleColor.Red,
            _ => ConsoleColor.White,
        };
    }
}
