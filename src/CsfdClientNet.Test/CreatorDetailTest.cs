using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CsfdClientNet.Cache;
using CsfdClientNet.Data;
using CsfdClientNet.Scrapping;
using FluentAssertions;
using Xunit;

namespace CsfdClientNet.Test
{
    public class CreatorDetailTest
    {
        public static IEnumerable<object[]> Data => new List<object[]>
        {
            new Object[]
            {
                new TestData()
                {
                    FileName = "KarelHoger.html", 
                    QueryName = "Karel Hoger", 
                    UseCache = false, 
                    Creator = new Creator("/tvurce/1570-karel-hoger/","Karel Höger")
                }
            }
        };

        [Theory]
        [MemberData(nameof(Data))]
        public async Task ProcessTest(TestData data)
        {
            var reader = TestHelper.PrepareReader(data.FileName);
            var r = new CreatorDetailReader(data.Creator, data.UseCache, reader);
            await r.Process(new MemoryCache(TimeSpan.FromMinutes(5)), CancellationToken.None);
            var res = await r.GetResult(CancellationToken.None);
            res.Creator.Id.Should().Be(data.Creator.Id);
            res.Creator.Name.Should().Be(data.Creator.Name);
            res.Biography.Should().HaveLength(4934);
        }
        
        public class TestData
        {
            public string FileName { get; set; }
            public string QueryName { get; set; }
            public bool UseCache { get; set; }
            public Creator Creator { get; set; }
        }
    }
}