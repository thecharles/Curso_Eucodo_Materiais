using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTesting.CharlesAugustoSilva.Converters.Tests
{
    public  class ConvertCDNLogToAgoraFormatTests
    {
        [Fact]
        public void TestLineHit()
        {
            var obj = new CDNLog("312|200|HIT|\"GET /robots.txt HTTP/1.1\"|100.2");
            string? agoraFormat = new ConvertCDNLogToAgoraFormat().ConvertFromObject(obj);
            Assert.True(agoraFormat == "\"MINHA CDN\" GET 200 /robots.txt 100 312 HIT");
        }
    }
}
