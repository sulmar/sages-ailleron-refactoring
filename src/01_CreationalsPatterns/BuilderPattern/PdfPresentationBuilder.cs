using System.Collections.Generic;

namespace BuilderPattern
{

   

    // Concrete Builder A
    public class PdfPresentationBuilder : IPresentationBuilder<PdfDocument>
    {
        private PdfDocument pdf = new PdfDocument();

        public IPresentationBuilder<PdfDocument> AddFooter(byte[] logo)
        {
            return this;
        }

        public IPresentationBuilder<PdfDocument> AddHeader(string title)
        {
            pdf.Title = title;
            pdf.Author = "Nieznany";

            return this;
        }

        public IPresentationBuilder<PdfDocument> AddSlide(Slide slide)
        {
            pdf.AddPage(slide.Text);

            return this;
        }

        public IPresentationBuilder<PdfDocument> AddSlides(IEnumerable<Slide> slides)
        {
            foreach (Slide slide in slides)
            {
                this.AddSlide(slide);
            }

            return this;
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
