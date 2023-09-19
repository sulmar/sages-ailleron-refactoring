namespace BuilderPattern
{
    // Abstract Product (optional)
    //public abstract class Document
    //{

    //}

    // Abstract Builder
    public interface IPresentationBuilder<T>
    {
        void AddHeader(string title);
        void AddSlide(Slide slide);
        void AddFooter(byte[] logo);

        T Build();
    }
}
