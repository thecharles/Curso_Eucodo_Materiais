﻿using CandidateTesting.CharlesAugustoSilva.Convert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTesting.CharlesAugustoSilva.Convert.Converters.AgoraFormat
{
    /// <summary>
    /// Responsiable to convert CDN files to Agora format.
    /// </summary>
    public class ConvertCDNLogToAgoraFormat : ILogConverter
    {
        public string? Convert(string cdnLog)
        {
            var cdnObject = new CDNLog(cdnLog);
            if (!cdnObject.IsValid)
                return null;

            return ConvertFromObject(cdnObject);
        }

        public string? ConvertFromObject(CDNLog obj)
        {
            var creator = new AgoraFormatCreator();

            creator.AddField("\"MINHA CDN\"");
            creator.AddField(obj.HttpMethod);
            creator.AddField(obj.StatusCode);
            creator.AddField(obj.UriPath);
            creator.AddField(obj.TimeTaken);
            creator.AddField(obj.ResponseSize);
            creator.AddField(obj.CacheStatus);

            var result = creator.GetFieldsFormatted();

            return result;
        }
    }
}
