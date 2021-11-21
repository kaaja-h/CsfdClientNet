using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using CsfdClientNet.Cache;
using CsfdClientNet.Data;
using HtmlAgilityPack;

[assembly: InternalsVisibleTo("CsfdClientNet.Test")]

namespace CsfdClientNet.Scrapping
{

    internal abstract class Finder<T> : ScrapperQueueItem<T>
    {
        protected readonly string Query;

        protected Finder(string query, bool useCache, IWebDataReader webDataReader) : base(useCache,webDataReader)
        {
            Query = query;
        }

        protected async Task<(List<Movie> movies, List<Creator> creators)> Find(ICsfdClientCache cache,
            CancellationToken token)
        {
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            queryString.Add(ScrappingConsts.QueryParamName, Query);

            var url = $"{ScrappingConsts.QueryUrl}{queryString}";
            var web = new HtmlWeb();
            var res = await web.LoadFromWebAsync(url, token);
            var movies = res.DocumentNode.SelectNodes(ScrappingConsts.QueryMoviePath);

            var moviesOutput = new List<Movie>();
            foreach (var movie in movies)
            {
                var title = movie.SelectSingleNode(ScrappingConsts.QueryMovieTitlePath);
                if (title == null || !title.Attributes.Contains("href"))
                    continue;
                var m = new Movie(title.Attributes["href"].Value, title.InnerText);
                var year = movie.SelectSingleNode(ScrappingConsts.QueryMovieYearPath);
                if (year != null)
                    m.Year = year.InnerText.Trim().Trim(new[] { '(', ')' });
                await cache.SaveMovie(m, token);
                moviesOutput.Add(m);
            }

            var creators = res.DocumentNode.SelectNodes(ScrappingConsts.QueryCreatorPath)
                ?.Where(d => !string.IsNullOrEmpty(d.Attributes["href"].Value))
                ?.Select(d => new Creator(d.Attributes["href"].Value, d.InnerText))
                ?.ToList() ?? new List<Creator>();
            foreach (var creator in creators)
            {
                await cache.SaveCreator(creator, token);
            }

            return (moviesOutput, creators);
        }
    }
}