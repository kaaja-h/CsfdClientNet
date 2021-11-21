using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CsfdClientNet.Cache;
using CsfdClientNet.Data;

namespace CsfdClientNet.Scrapping
{

    internal class CreatorFinder : Finder<List<Creator>>
    {
        public CreatorFinder(string query, bool useCache, IWebDataReader webDataReader) : base(query, useCache,webDataReader)
        {
        }

        protected override async Task<List<Creator>?> ProcessInternal(ICsfdClientCache cache, CancellationToken token)
        {
            var (_, creators) = await Find(cache, token);
            return creators;
        }

        protected override async Task<List<Creator>?> CheckCache(ICsfdClientCache cache, CancellationToken token)
        {
            var res = await cache.FindCreatorByName(Query, token);
            if (!res.Any())
                return null;
            return res;
        }
    }
}