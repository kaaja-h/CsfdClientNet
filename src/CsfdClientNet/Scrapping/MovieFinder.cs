using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CsfdClientNet.Cache;
using CsfdClientNet.Data;

namespace CsfdClientNet.Scrapping
{

    internal class MovieFinder : Finder<List<Movie>>
    {
        public MovieFinder(string query, bool useCache, IWebDataReader webDataReader) : base(query, useCache, webDataReader)
        {
        }

        protected override async Task<List<Movie>?> ProcessInternal(ICsfdClientCache cache, CancellationToken token)
        {
            var (movies, _) = await Find(cache, token);
            return movies;
        }

        protected override async Task<List<Movie>?> CheckCache(ICsfdClientCache cache, CancellationToken token)
        {
            var res = await cache.FindMovieByName(Query, token);
            if (!res.Any())
                return null;
            return res;
        }
    }
}