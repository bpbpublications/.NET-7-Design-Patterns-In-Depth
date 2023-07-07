using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IPhoto photo = new Photo("C:\\sample.png");
            photo.GetPhoto();//returns the original photo

            WatermarkDecorator watermarkDecorator = new WatermarkDecorator(photo, "Sample Watermark");
            watermarkDecorator.GetPhoto();

            BlackWhiteDecorator blackWhiteDecorator = new BlackWhiteDecorator(photo);
            blackWhiteDecorator.GetPhoto();
            Console.Read();
        }
    }
}
