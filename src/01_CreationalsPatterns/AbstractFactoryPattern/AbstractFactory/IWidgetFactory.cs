namespace AbstractFactoryPattern.AbstractFactory
{
    // Abstract Factory
    public interface IWidgetFactory
    {
        IButton CreateButton();
        ITextBox CreateTextBox();
    }
}
