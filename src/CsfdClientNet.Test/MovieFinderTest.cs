using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CsfdClientNet.Cache;
using CsfdClientNet.Scrapping;
using Xunit;

namespace CsfdClientNet.Test
{
    public class MovieFinderTest
    {

        public static IEnumerable<object[]> Data =>new List<object[]>{
            new Object []{new TestData()
            {
                FileName = "searchPokus.html", 
                QueryName = "pokus", 
                UseCache = false, 
                Count = 14, 
                Id = "/film/8317-pokus-o-vrazdu/",
                Name = "Pokus o vraždu",
                Year = "1973"
            }}
        };


        [Theory]
        [MemberData(nameof(Data))]
        public async Task ProcessTest(TestData data)
        {
            var reader = TestHelper.PrepareReader(data.FileName);
            MovieFinder mf = new MovieFinder(data.QueryName, data.UseCache, reader);
            var cache = new MemoryCache(TimeSpan.FromHours(5));
            await mf.Process(cache, CancellationToken.None);
            var result = await mf.GetResult(CancellationToken.None);
            Assert.NotNull(result);
            Assert.Equal(data.Count,result.Count);
            var first = result[0];
            Assert.Equal(data.Name,first.Name);
            Assert.Equal(data.Id,first.Id);
            Assert.Equal(data.Year,first.Year);
        }
        
        public class TestData
        {
            public string FileName { get; set; }
            public string QueryName { get; set; }
            public bool UseCache { get; set; }
            
            public int Count { get; set; }
            
            public string Name { get; set; }
            
            public string Id { get; set; }
            
            public string Year { get; set; }
        }
    }
}