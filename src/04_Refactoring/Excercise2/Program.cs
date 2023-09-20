
// TODO: Dodaj obliczanie kosztu wydruku do starej drukarki

bool legacy = false;

string document = "Hello World!";
int copies = 3;


if (legacy)
{
    LegacyPrinter printer = new LegacyPrinter();

    for (int i = 0; i < copies; i++)
    {
        printer.PrintDocument(document);
    }
}
else
{
    Printer printer = new Printer();
    printer.Print(document, copies);
}




public class Printer
{
    decimal _costPerCopy = 0.1m; // Cost of 0.10 zł per copy

    public void Print(string document, int copies = 1)
    {
        for (int copy = 1; copy <= copies; copy++)
        {
            Console.WriteLine($"Printer is printing: {document}");
        }

        var cost = CalculateCost(copies);
        Console.WriteLine($"{cost:C2}");
    }

    private decimal CalculateCost(int copies)
    {
        // Calculate total cost based on the number of copies and cost per copy
        return copies * _costPerCopy;
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