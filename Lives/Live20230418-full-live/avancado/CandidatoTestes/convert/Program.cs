using CandidateTesting.CharlesAugustoSilva.Convert.Converters.AgoraFormat;
using System;
using System.IO;
using System.Net;

namespace CandidateTesting.CharlesAugustoSilva.Convert
{
    class Program
    {
        private const string usageText = "Usage: convert <sourceUrl> <targetPath>";

        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine(usageText);
                return;
            }

            try
            {
                string sourceUrl = args[0];
                string targetPath = args[1];

                RunConvert(sourceUrl, targetPath);

                Console.WriteLine("The CDN log has been successfully converted to Agora format.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        static void RunConvert(string sourceUrl, string targetPath)
        {
            var converterService = new ConverterService(new ConvertCDNLogToAgoraFormat());
            var result = converterService.Convert(sourceUrl, targetPath);
            if(!result.Success)
            {
                throw new Exception(result.Message);
            }
        }
    }
}