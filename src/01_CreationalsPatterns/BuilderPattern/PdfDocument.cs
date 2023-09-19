using System;

namespace BuilderPattern
{
    // Concrete Product
    public class PdfDocument 
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public void AddPage(string text)
        {
            Console.WriteLine($"Add a {text} page to PDF");
        }
    }
}
