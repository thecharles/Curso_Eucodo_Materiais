using System;
using System.IO;
using System.Net;

namespace CandidateTesting.CharlesAugustoSilva.Converters
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: convert <sourceUrl> <targetPath>");
                return;
            }

            try
            {
                string sourceUrl = args[0];
                string targetPath = args[1];

                RunConvert(sourceUrl, targetPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            Console.ReadKey();
        }

        static async void RunConvert(string sourceUrl, string targetPath)
        {
            var converterService = new ConverterService();
            await converterService.ConvertAsync(sourceUrl, targetPath);
        }
    }
}