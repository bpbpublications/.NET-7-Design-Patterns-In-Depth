using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ExportContext export = new ExportContext(new XMLExporter());
            export.Process(new { Name = "Vahid", LastName = "Farahmandian" });
            //ExportContext export = new(new Export(Exporter.XMLExport));
            //export.Process(new { Name = "Vahid", LastName = "Farahmandian" });
            Console.Read();
        }
    }
}
