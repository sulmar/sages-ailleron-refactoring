using System.Collections.Generic;

namespace BuilderPattern
{
    // Concrete Builder B
    public class MoviePresentationBuilder : IPresentationBuilder<Movie>
    {
        private Movie movie = new Movie();

        public IBuld<Movie> AddFooter(byte[] logo)
        {
            throw new System.NotImplementedException();

            return this;
        }

        public ISlide<Movie> AddHeader(string title)
        {
            return this;
        }

        public ISlideOrFooter<Movie> AddSlide(Slide slide)
        {
            movie.AddFrame(slide.Text, 3);

            return this;
        }

        public ISlideOrFooter<Movie> AddSlides(IEnumerable<Slide> slides)
        {
            foreach (Slide slide in slides)
            {
                this.AddSlide(slide);
            }

            return this;
        }

        public Movie Build()
        {
            return GetMovie();
        }

        public Movie GetMovie()
        {
            return movie;
        }
    }
}
