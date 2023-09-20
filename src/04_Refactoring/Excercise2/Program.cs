
// TODO: Dodaj obliczanie kosztu wydruku do starej drukarki

using System;

bool legacy = false;

string document = "Hello World!";
int copies = 3;

IPrinterAdapter printer = new PrinterProxy(PrinterAdapterFactory.Create(legacy));
printer.Print(document, copies);


public class PrinterAdapterFactory
{
    public static IPrinterAdapter Create(bool legacy)
    {
        if (legacy)
        {
            return new LegacyPrinterAdapter());            
        }
        else
        {
            return new Printer();            
        }
    }
}

// Abstract Adapter - powstał na podstawie klasy Printer, czyli nowej drukarki - chcemy dostosować starą drukarkę do nowej a nie odwrotnie :)
public interface IPrinterAdapter
{
    void Print(string document, int copies = 1);
}


public class Printer : IPrinterAdapter
{
    decimal _costPerCopy = 0.1m; // Cost of 0.10 zł per copy

    public void Print(string document, int copies = 1)
    {
        for (int copy = 1; copy <= copies; copy++)
        {
            Console.WriteLine($"Printer is printing: {document}");
        }        
    }  
}


// Nie zmieniaj kodu tej starej klasy!
public class LegacyPrinter
{
    public void PrintDocument(string document)
    {
        Console.WriteLine($"Legacy Printer is printing: {document}");
    }
}

// Proxy
public class PrinterProxy : IPrinterAdapter
{
    // Real Subject
    private readonly IPrinterAdapter printer;

    public PrinterProxy(IPrinterAdapter printer)
    {
        this.printer = printer;
    }



    decimal _costPerCopy = 0.1m; // Cost of 0.10 zł per copy

    public void Print(string document, int copies = 1)
    {
        printer.Print(document, copies);

        var cost = CalculateCost(copies);
        Console.WriteLine($"{cost:C2}");
    }

    private decimal CalculateCost(int copies)
    {
        // Calculate total cost based on the number of copies and cost per copy
        return copies * _costPerCopy;
    }
}


// Concrete Adapter
public class LegacyPrinterAdapter : IPrinterAdapter
{
    private readonly LegacyPrinter printer;

    public LegacyPrinterAdapter()
    {
        printer = new LegacyPrinter();
    }

    public void Print(string document, int copies = 1)
    {
        for (int i = 0; i < copies; i++)
        {
            printer.PrintDocument(document);
        }
    }
}