namespace BuilderPattern
{
    // Abstract Product (optional)
    //public abstract class Document
    //{

    //}

    // Abstract Builder
    public interface IPresentationBuilder<T>
    {
        void AddSlide(Slide slide);

        T Build();

    }
}
