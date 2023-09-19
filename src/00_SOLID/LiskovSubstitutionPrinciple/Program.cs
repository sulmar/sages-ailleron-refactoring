// Zasada podstawiania Liskov (Liskov Substitution Principle) - LSP  
// w miejscu klasy bazowej można użyć dowolnej klasy pochodnej (zgodność wszystkich metod).


// Zasada Liskov mówi o tym, że obiekt klasy pochodnej może być używany zamiennie
// w miejscu obiektu klasy bazowej, nie wprowadzając nieoczekiwanych zachowań.

using System.Reflection.Metadata;

Document docPdf = new PDFDocument();
Document docText = new TextDocument();
Document docWord = new WordDocument();

Document doc = docWord;

doc.Print();

if (doc.CanEdit())
{
    doc.Edit();
}


class Document
{
    public virtual void Print()
    {
        Console.WriteLine("Printing a document...");
    }

    public virtual bool CanEdit()
    {
        return false;
    }

    public virtual void Edit()
    {
        Console.WriteLine("Editing a document...");
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

    public override void Edit()
    {
        throw new NotSupportedException();
    }
}

class TextDocument : Document
{
    public override void Print()
    {
        Console.WriteLine("Printing a text document...");
    }

    public override bool CanEdit()
    {
        return true;
    }
}

class WordDocument : Document
{
    public override bool CanEdit()
    {
        return true;
    }
}