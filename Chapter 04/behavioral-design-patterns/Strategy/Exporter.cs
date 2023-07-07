using System;
public interface IExporter
{
    void Export(object data);
}

public class XMLExporter : IExporter
{
    public void Export(object data) => Console.WriteLine("data exported to xml");
}
public class CSVExporter : IExporter
{
    public void Export(object data) => Console.WriteLine("data exported to csv");
}
public class TXTExporter : IExporter
{
    public void Export(object data) => Console.WriteLine("data exported to txt");
}
public class ExportContext
{
    private readonly IExporter _strategy;
    public ExportContext(IExporter strategy) => this._strategy = strategy;
    public void Process(object data) => _strategy.Export(data);
}

//public delegate void Export(object data);
//public class Exporter
//{
//    public static void XMLExport(object data) { Console.WriteLine("data exported to xml"); }
//    public static void CSVExport(object data) { Console.WriteLine("data exported to csv"); }
//    public static void TXTExport(object data) { Console.WriteLine("data exported to txt"); }
//}
//public class ExportContext
//{
//    private Export _strategy;
//    public ExportContext(Export strategy) => this._strategy = strategy;
//    public void Process(object data) => _strategy(data);
//}
