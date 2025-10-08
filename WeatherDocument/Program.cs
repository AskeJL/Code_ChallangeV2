using PdfSharp.Fonts;
using System;
using System.IO;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace WeatherDocument
{
    class Program
    {
        // Directory where we would like to output our PDF files.
        // Example could be "C:/Dev"
        public static string s_outputDirectory = "C:\\Users\\askel\\OneDrive\\Skrivebord\\WeatherDocument";

        static async Task Main(string[] args)
        {
            if (s_outputDirectory is null)
            {
                throw new Exception("Need to define output directory");
            }
            

            await WeatherDocumentService.GenerateWeatherDocument("EKCH", "EKBI");
            await WeatherDocumentService.GenerateWeatherDocument("KJFK", "EHAM", "EKBI");
            await Task.Delay(TimeSpan.FromMilliseconds(100));
            await WeatherDocumentService.GenerateWeatherDocument("RJAA", "KAUS", "KHOU");
            await Task.Delay(TimeSpan.FromMilliseconds(1000));
            await WeatherDocumentService.GenerateWeatherDocument("EKCH", "EKBI");
            await WeatherDocumentService.GenerateWeatherDocument("EKCH", "EKOD");
            await WeatherDocumentService.GenerateWeatherDocument("EKCH", "EKOD", "EKEL");

            Console.ReadLine();
            
        }
    }
}
