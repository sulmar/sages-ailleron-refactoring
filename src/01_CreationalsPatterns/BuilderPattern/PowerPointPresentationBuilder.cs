using System.Collections.Generic;

namespace BuilderPattern
{
    // Concrete Builder C
    public class PowerPointPresentationBuilder : IPresentationBuilder<PowerPoint>
    {
        private PowerPoint ppx = new PowerPoint();

        public IPresentationBuilder<PowerPoint> AddFooter(byte[] logo)
        {
            // 
            return this;
        }

        public IPresentationBuilder<PowerPoint> AddHeader(string title)
        {
            return this;
        }

        public IPresentationBuilder<PowerPoint> AddSlide(Slide slide)
        {
            ppx.Add(slide.Text);

            return this;
        }

        public IPresentationBuilder<PowerPoint> AddSlides(IEnumerable<Slide> slides)
        {
            foreach (Slide slide in slides)
            {
                this.AddSlide(slide);
            }

            return this;
        }

        public PowerPoint Build()
        {
            return GetPowerPoint();
        }

        public PowerPoint GetPowerPoint()
        {
            return ppx;
        }

        
    }
}
