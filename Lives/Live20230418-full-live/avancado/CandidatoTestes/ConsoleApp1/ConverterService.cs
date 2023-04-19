using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTesting.CharlesAugustoSilva.Converters
{
    /// <summary>
    /// I am assuming that the file can be any size. Because of that, i am reading like a stream of file and write imediatally
    /// without accumulating everything in memory.
    /// 
    /// I dont like mix download with writing on the HD, but in order to be able to read big files, i did this way. 
    /// </summary>
    internal class ConverterService
    {
        private readonly string _version = "1.0";

        private static readonly HttpClient httpClient = new HttpClient();

        public async Task ConvertAsync(string urlFileCDN, string filePathAgoraFormatToSave)
        {
            try
            {
                httpClient.Timeout = TimeSpan.FromHours(1);

                using (HttpResponseMessage response = await httpClient.GetAsync(urlFileCDN))
                {
                    response.EnsureSuccessStatusCode();

                    using (Stream responseStream = await response.Content.ReadAsStreamAsync())
                    {
                        using (StreamReader sr = new StreamReader(responseStream))
                        {
                            using (StreamWriter sw = new StreamWriter(filePathAgoraFormatToSave))
                            {
                                await WriteHeadersAsync(sw);

                                string line;
                                while ((line = await sr.ReadLineAsync()) != null)
                                {
                                    var result = new ConvertCDNLogToAgoraFormat().ConvertFromString(line);
                                    if (string.IsNullOrEmpty(result))
                                        continue;
                                    await sw.WriteLineAsync(result);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error on converting the log CDN to Agora format: {e.Message}");
            }
        }

        private async Task WriteHeadersAsync(StreamWriter sw)
        {
            // Write the headers to the StreamWriter here
            var headers = new string[]
            {
                $"#Version: {_version}",
                $"#Date: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}",
                "#Fields: provider http-method status-code uri-path time-taken response-size cache-status"
            };

            foreach (var header in headers)
            {
                await sw.WriteLineAsync(header);
            }
        }
    }
}
