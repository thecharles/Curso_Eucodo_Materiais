using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTesting.CharlesAugustoSilva.Converters.Tests
{
    public class CDNLogTests
    {
        [Fact]
        public void TestLineHit()
        {
            var obj = new CDNLog("312|200|HIT|\"GET /robots.txt HTTP/1.1\"|100.2");

            Assert.True(obj.ResponseSize == "312");
            Assert.True(obj.StatusCode == "200");
            Assert.True(obj.CacheStatus == "HIT");
            Assert.True(obj.RequestLine == "GET /robots.txt HTTP/1.1");
            Assert.True(obj.TimeTaken == decimal.Parse("100,2"));
        }

        [Fact]
        public void TestLineInvalidate()
        {
            var obj = new CDNLog("312|200|INVALIDATE|\"GET /robots.txt HTTP/1.1\"|245.1");

            Assert.True(obj.ResponseSize == "312");
            Assert.True(obj.StatusCode == "200");
            Assert.True(obj.CacheStatus == "REFRESH_HIT");
            Assert.True(obj.RequestLine == "GET /robots.txt HTTP/1.1");
            Assert.True(obj.TimeTaken == decimal.Parse("245,1"));
        }
    }
}
