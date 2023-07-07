using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_Design_Patterns.Chapter1.SOLID
{
    //public class FileManager
    //{
    //    public virtual void Read() => Console.WriteLine("Reading from file...");
    //    public virtual void Write() => Console.WriteLine("Writting to file...");
    //}
    //public class TextFileManager : FileManager
    //{
    //    public override void Read()
    //    {
    //        Console.WriteLine("Reading from text file...");
    //        base.Read();
    //    }
    //    public override void Write()
    //    {
    //        Console.WriteLine("Writting to text file...");
    //        base.Write();
    //    }
    //}
    //public class XmlFileManager : FileManager
    //{
    //    public override void Write() => throw new NotImplementedException();
    //}
    public interface IFileReader
    {
        void Read();
    }
    public interface IFileWriter
    {
        void Write();
    }
    public class FileManager : IFileReader, IFileWriter
    {
        public void Read() => Console.WriteLine("Reading from file...");
        public void Write() => Console.WriteLine("Writting to file...");
    }
    public class TextFileManager : IFileReader, IFileWriter
    {
        public void Read() => Console.WriteLine("Reading text file...");
        public void Write() => Console.WriteLine("Writting to text file...");
    }
    public class XmlFileManager : IFileReader
    {
        public void Read() => Console.WriteLine("Reading from file...");
    }
}
