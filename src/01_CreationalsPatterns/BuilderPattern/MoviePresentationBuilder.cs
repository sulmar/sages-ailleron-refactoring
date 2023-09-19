namespace BuilderPattern
{
    // Concrete Builder B
    public class MoviePresentationBuilder : IPresentationBuilder<Movie>
    {
        private Movie movie = new Movie();
        public void AddSlide(Slide slide)
        {
            movie.AddFrame(slide.Text, 3);
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
