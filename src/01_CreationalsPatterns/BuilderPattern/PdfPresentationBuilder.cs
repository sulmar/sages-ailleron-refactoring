namespace BuilderPattern
{
    // Concrete Builder A
    public class PdfPresentationBuilder : IPresentationBuilder<PdfDocument>
    {
        private PdfDocument pdf = new PdfDocument();
        public void AddSlide(Slide slide)
        {
            pdf.AddPage(slide.Text);
        }

        public PdfDocument Build()
        {
            return GetPdfDocument();
        }

        // Zwracamy Product
        public PdfDocument GetPdfDocument()
        {
            return pdf;
        }
    }
}
