using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTesting.CharlesAugustoSilva.Converters.Tests
{
    public class AgoraFormatCreatorTests
    {
        [Fact]
        public void TestAddOneByOne()
        {
            var creator = new AgoraFormatCreator();
            creator.AddField("a");
            creator.AddField("a");
            creator.AddField("B");
            var result = creator.GetFieldsFormatted();
            Assert.True(result == "a a B");
        }

        [Fact]
        public void TestDecimal()
        {
            var creator = new AgoraFormatCreator();
            creator.AddField(100.25m);
            creator.AddField(10000.25m); // cant have thousands separator
            var result = creator.GetFieldsFormatted();
            Assert.True(result == "100.25 10000.25");
        }

        [Fact]
        public void TestAddList()
        {
            var creator = new AgoraFormatCreator();
            creator.AddFields("a,a,B".Split(',').ToList());
            var result = creator.GetFieldsFormatted();
            Assert.True(result == "a a B");
        }
    }
}
