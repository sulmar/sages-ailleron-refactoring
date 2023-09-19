using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{

    public class Slide
    {
        public string Text { get; }

        public Slide(string text)
        {
            Text = text;
        }
    }

    public class Presentation
    {
        private List<Slide> slides = new List<Slide>();

        public void AddSlide(Slide slide)
        {
            slides.Add(slide);
        }

        public void Export<T>(IPresentationBuilder<T> builder)
        {
            builder.AddSlide(new Slide("Copyright"));
            foreach (Slide slide in slides)
            {
                builder.AddSlide(slide);
            }
        }
    }

    

    // Concrete Product
    public class PdfDocument 
    {
        public void AddPage(string text)
        {
            Console.WriteLine($"Add a {text} page to PDF");
        }
    }

    public class Movie 
    {
        public void AddFrame(string text, int duration)
        {
            Console.WriteLine($"Add a frame to the movie");
        }
    }

    public class PowerPoint
    {
        public void Add(string text)
        {
            Console.WriteLine($"Add a text to the powerpoint");
        }
    }
}
