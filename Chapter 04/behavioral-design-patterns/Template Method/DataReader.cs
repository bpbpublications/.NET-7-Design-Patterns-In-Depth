using System;

public abstract class DataReader
{
    public void Import()
    {
        Connect();
        Validate();
        Read();
        Convert();
    }
    public abstract void Connect();
    public abstract void Validate();
    public abstract void Read();
    public abstract void Convert();
}
public class TXTReader : DataReader
{
    public override void Connect() => Console.WriteLine("Connected to txt file");
    public override void Validate() => Console.WriteLine("Data has valid txt format");
    public override void Read() => Console.WriteLine("Data from txt file read done");
    public override void Convert() => Console.WriteLine("Data converted from txt to destination type");
}
public class XMLReader : DataReader
{
    public override void Connect() => Console.WriteLine("Connected to xml file");
    public override void Validate() => Console.WriteLine("Data has valid xml format");
    public override void Read() => Console.WriteLine("Data from xml file read done");
    public override void Convert() => Console.WriteLine("Data converted from xml to destination type");
}
public class CSVReader : DataReader
{
    public override void Connect() => Console.WriteLine("Connected to csv file");
    public override void Validate() => Console.WriteLine("Data has valid csv format");
    public override void Read() => Console.WriteLine("Data from csv file read done");
    public override void Convert() => Console.WriteLine("Data converted from  to destination type");
}