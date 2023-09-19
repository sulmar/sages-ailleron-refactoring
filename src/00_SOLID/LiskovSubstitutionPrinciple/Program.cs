// Zasada podstawiania Liskov (Liskov Substitution Principle) - LSP  
// w miejscu klasy bazowej można użyć dowolnej klasy pochodnej (zgodność wszystkich metod).

Document docPdf = new PDFDocument();
Document docText = new TextDocument();

docPdf.Print();

((TextDocument)docPdf).Edit(); 


class Document
{
    public virtual void Print()
    {
        Console.WriteLine("Printing a document...");
    }
}

class PDFDocument : Document
{
    public override void Print()
    {
        Console.WriteLine("Printing a PDF document...");
    }

    public void Encrypt()
    {
        Console.WriteLine("Encrypting a PDF document...");
    }
}

class TextDocument : Document
{
    public override void Print()
    {
        Console.WriteLine("Printing a text document...");
    }

    public void Edit()
    {
        Console.WriteLine("Editing a document...");
    }
}