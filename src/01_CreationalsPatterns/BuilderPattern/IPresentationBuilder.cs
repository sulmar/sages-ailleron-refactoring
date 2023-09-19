using System.Collections.Generic;
using System.ComponentModel;

namespace BuilderPattern
{
    // Abstract Product (optional)
    //public abstract class Document
    //{

    //}

    // Abstract Builder
    public interface IPresentationBuilder<T> : ISlide<T>, ISlideOrFooter<T>, IBuld<T>
    {
        ISlide<T> AddHeader(string title);
        //ISlideOrFooter<T> AddSlide(Slide slide);
        //ISlideOrFooter<T> AddSlides(IEnumerable<Slide> slides);
        //IBuld<T> AddFooter(byte[] logo);
        //T Build();
    }

    public interface IHeader<T>
    {
        ISlide<T> AddHeader(string title);
    }

    public interface ISlide<T>
    {
        ISlideOrFooter<T> AddSlide(Slide slide);
        ISlideOrFooter<T> AddSlides(IEnumerable<Slide> slides);
    }

    public interface ISlideOrFooter<T> : ISlide<T>, IFooter<T>
    {

    }

    public interface IFooter<T>
    {
        IBuld<T> AddFooter(byte[] logo);
    }

    public interface IBuld<T>
    {
        T Build();
    }


}
