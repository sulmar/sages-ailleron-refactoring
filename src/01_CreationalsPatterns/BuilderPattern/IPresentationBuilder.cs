using System.Collections.Generic;

namespace BuilderPattern
{
    // Abstract Product (optional)
    //public abstract class Document
    //{

    //}

    // Abstract Builder
    public interface IPresentationBuilder<T>
    {
        IPresentationBuilder<T> AddHeader(string title);
        IPresentationBuilder<T> AddSlide(Slide slide);
        IPresentationBuilder<T> AddSlides(IEnumerable<Slide> slides);
        IPresentationBuilder<T> AddFooter(byte[] logo);

        T Build();
    }
}
