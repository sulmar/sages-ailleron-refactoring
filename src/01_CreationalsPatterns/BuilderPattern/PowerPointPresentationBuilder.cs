namespace BuilderPattern
{
    // Concrete Builder C
    public class PowerPointPresentationBuilder : IPresentationBuilder<PowerPoint>
    {
        private PowerPoint ppx = new PowerPoint();
        public void AddSlide(Slide slide)
        {
            ppx.Add(slide.Text);
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
