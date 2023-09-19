using System.Collections.Generic;

namespace BuilderPattern
{
    // Director
    public class Presentation
    {
        private List<Slide> slides = new List<Slide>();

        public void AddSlide(Slide slide)
        {
            slides.Add(slide);
        }

        public void Export<T>(IPresentationBuilder<T> builder)
        {
            builder               
                .AddHeader("Demo")                               
                .AddSlide(new Slide("Copyright"))
                .AddSlides(slides)
                .AddFooter(new byte[] { 1, 2, 3 });            
        }
    }
}
