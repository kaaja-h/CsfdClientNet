using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using CsfdClientNet.Cache;
using CsfdClientNet.Data;
using HtmlAgilityPack;
[assembly: InternalsVisibleTo("CsfdClientNet.Test")]

namespace CsfdClientNet.Scrapping
{

    internal class CreatorDetailReader : ScrapperQueueItem<CreatorDetail?>
    {
        private readonly Creator _creator;

        public CreatorDetailReader(Creator creator, bool useCache, IWebDataReader webDataReader) : base(useCache,webDataReader)
        {
            _creator = creator;
        }

        protected override async Task<CreatorDetail?> ProcessInternal(ICsfdClientCache cache, CancellationToken token)
        {
            var url = string.Format(ScrappingConsts.CreatorDetailUrl, _creator.Id);
            var web = new HtmlWeb();
            var document = await web.LoadFromWebAsync(url, token);
            var biography = document.DocumentNode.SelectNodes(ScrappingConsts.CreatorDetailBiographyPath);
            var res = new CreatorDetail(_creator);
            if (biography != null)
            {
                var u = biography.Select(d => d.InnerText.Trim());
                res.Biography = string.Join("\n", u);
            }

            var professions = document.DocumentNode.SelectNodes(ScrappingConsts.CreatorDetailFilmographyPath);
            if (professions != null)
            {
                foreach (var profession in professions)
                {
                    var name = profession.SelectSingleNode(ScrappingConsts.CreatorDetailFilmographyNamePath);

                    var movies = profession.SelectNodes(ScrappingConsts.CreatorDetailFilmographyMoviePath);
                    if (movies==null)
                        continue;
                    string lastYear = string.Empty;
                    foreach (var movie in movies)
                    {
                        var year = movie.SelectSingleNode(ScrappingConsts.CreatorDetailFilmographyMovieYearPath);

                        var m = movie.SelectSingleNode(ScrappingConsts.CreatorDetailFilmographyMovieNamePath);
                        if (year == null||m==null)
                            continue;
                        var y = year.InnerText.Trim();
                        if (!string.IsNullOrWhiteSpace(y))
                            lastYear = y;
                        var mov = new Movie(m.Attributes["href"].Value, m.InnerText.Trim());
                        if (!string.IsNullOrWhiteSpace(lastYear))
                            mov.Year = lastYear;

                    }
                    
                }
            }

            return res;
        }

        protected override async Task<CreatorDetail?> CheckCache(ICsfdClientCache cache, CancellationToken token)
        {
            return await cache.GetCreatorDetail(_creator.Id, token);
        }
    }
}