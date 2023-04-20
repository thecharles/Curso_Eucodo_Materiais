using CandidateTesting.CharlesAugustoSilva.Convert.Converters;
using convert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace CandidateTesting.CharlesAugustoSilva.Convert
{
    /// <summary>
    /// I am assuming that the file can be any size. Because of that, i am reading like a stream of file and write imediatally
    /// without accumulating everything in memory.
    /// 
    /// I dont like mix download with writing on the HD, but in order to be able to read big files, i did this way. 
    /// </summary>
    public class ConverterService
    {
        private readonly string _version = "1.0";

        private static readonly HttpClient httpClient = new HttpClient();
        private readonly ILogConverter logConverter;

        public ConverterService(ILogConverter _converter) 
        {
            this.logConverter = _converter;
        }

        public ConversionResult Convert(string urlFileCDN, string filePathAgoraFormatToSave)
        {
            var conversionResult = new ConversionResult();

            try
            {
                httpClient.Timeout = TimeSpan.FromHours(1);

                using (HttpResponseMessage response = httpClient.GetAsync(urlFileCDN).Result)
                {
                    response.EnsureSuccessStatusCode();

                    using (Stream responseStream = response.Content.ReadAsStreamAsync().Result)
                    {
                        using (StreamReader sr = new StreamReader(responseStream))
                        {
                            using (StreamWriter sw = new StreamWriter(filePathAgoraFormatToSave))
                            {
                                WriteHeaders(sw);

                                string line;
                                while ((line = sr.ReadLine()) != null)
                                {
                                    var result = this.logConverter.Convert(line);
                                    if (string.IsNullOrEmpty(result))
                                        continue;
                                    sw.WriteLine(result);
                                }
                            }
                        }
                    }
                }

                conversionResult.Success = true;
            }
            catch (HttpRequestException e)
            {
                conversionResult.Success = false;
                conversionResult.Message = $"Error on converting the log CDN to Agora format: {e.Message}";
            }
            catch (Exception e)
            {
                conversionResult.Success = false;
                conversionResult.Message = $"Error on converting the log CDN to Agora format: {e.Message}";
            }

            return conversionResult;
        }

        private void WriteHeaders(StreamWriter sw)
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
                sw.WriteLine(header);
            }
        }
    }
}
