using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using CsfdClientNet.Cache;
using CsfdClientNet.Data;
using CsfdClientNet.Scrapping;
using Xunit;
using FluentAssertions;


namespace CsfdClientNet.Test
{
    public class MovieDetailReaderTest
    {
        public static IEnumerable<object[]> Data =>new List<object[]>{
            new Object []{new TestData()
            {
                FileName = "PokusOVrazdu.html", 
                QueryName = "pokus", 
                UseCache = false, 
                Movie = new Movie("/film/8317-pokus-o-vrazdu/","Pokus o vraždu"),
                Genres = new[]{ "Krimi","Psychologický" },
                Length = "106 min",
                 Origin = "Československo",
                 PlotCount = 1,
                 ProfessionsCount = new Dictionary<string, int>()
                 {
                     {"Kostýmy",1},
                     {"Scénografie",1},
                     {"Hrají",47},
                     {"Hudba",1},
                     {"Kamera",1},
                     {"Scénář",1},
                     {"Předloha",1},
                     {"Režie",1}
                 }
            }
            }
        };

        [Theory]
        [MemberData(nameof(Data))]
        public async Task ProcessTest(TestData data)
        {
            var reader = TestHelper.PrepareReader(data.FileName);
            var r = new MovieDetailReader(data.Movie, data.UseCache, reader);
            await r.Process(new MemoryCache(TimeSpan.FromMinutes(5)), CancellationToken.None);
            var res = await r.GetResult(CancellationToken.None);
            res.Should().NotBeNull();
            res.Movie.Should().NotBeNull();
            res.Movie.Id.Should().Be(data.Movie.Id);
            res.Movie.Name.Should().Be(data.Movie.Name);
            res.Genres.Should().BeEquivalentTo(data.Genres);
            res.Length.Should().Be(data.Length);
            res.Origin.Should().Be(data.Origin);
            res.Plots.Should().HaveCount(data.PlotCount);
            res.Professions.Keys.Should().BeEquivalentTo(data.ProfessionsCount.Keys);
            var counts = res.Professions.ToDictionary(d => d.Key, d => d.Value.Count);
            counts.Should().Equal(data.ProfessionsCount);
            res.RatingAverage.Should().Be(64.150943396226M);
            res.RatingCount.Should().Be(1060);

        }

        public class TestData
        {
            public string FileName { get; set; }
            public string QueryName { get; set; }
            public bool UseCache { get; set; }
            public Movie Movie { get; set; }
            public string[] Genres { get; set; }
            public string Length { get; set; }
            public string Origin { get; set; }
            public int PlotCount { get; set; }
            
            public Dictionary<string,int> ProfessionsCount { get; set; }
        }
    }
}