using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using CsfdClientNet.Data;

[assembly: InternalsVisibleTo("CsfdClientNet.Test")]

namespace CsfdClientNet.Cache
{

    /// <summary>
    /// In memory cache
    /// </summary>
    public class MemoryCache : ICsfdClientCache
    {
        private readonly ConcurrentDictionary<string, MemoryCacheItem<Creator>> _creatorCache = new();
        private readonly ConcurrentDictionary<string, MemoryCacheItem<CreatorDetail>> _creatorDetailCache = new();

        private readonly ConcurrentDictionary<string, MemoryCacheItem<Movie>> _movieCache = new();

        private readonly ConcurrentDictionary<string, MemoryCacheItem<MovieDetail>> _movieDetailCache = new();
        private readonly TimeSpan _liveTime;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="liveTime">memory item livetime</param>
        public MemoryCache(TimeSpan liveTime)
        {
            _liveTime = liveTime;
        }


        /// <inheritdoc />
        public Task<List<Movie>> FindMovieByName(string name, CancellationToken token)
        {
            return Task.Run(() => GetSimilarFromCache(_movieCache, name), token);
        }

        /// <inheritdoc />
        public Task<MovieDetail?> GetMovieDetail(string id, CancellationToken token)
        {
            return Task.Run(() => GetByIdFromCache(_movieDetailCache, id), token);
        }

        /// <inheritdoc />
        public Task<List<Creator>> FindCreatorByName(string name, CancellationToken token)
        {
            return Task.Run(() => GetSimilarFromCache(_creatorCache, name), token);
        }

        /// <inheritdoc />
        public Task<CreatorDetail?> GetCreatorDetail(string id, CancellationToken token)
        {
            return Task.Run(() => GetByIdFromCache(_creatorDetailCache, id), token);
        }

        /// <inheritdoc />
        public Task SaveMovie(Movie movie, CancellationToken token)
        {
            _movieCache.AddOrUpdate(movie.Id,
                _ => new MemoryCacheItem<Movie>(movie, DateTime.Now, movie.Name),
                (_, data) =>
                {
                    movie.Year ??= data.Value.Year;
                    return new MemoryCacheItem<Movie>(movie, DateTime.Now, movie.Name);
                });
            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task SaveMovieDetail(MovieDetail movieDetail, CancellationToken token)
        {
            _movieDetailCache.AddOrUpdate(movieDetail.Movie.Id,
                _ => new MemoryCacheItem<MovieDetail>(movieDetail, DateTime.Now, movieDetail.Movie.Name),
                (_, _) => new MemoryCacheItem<MovieDetail>(movieDetail, DateTime.Now, movieDetail.Movie.Name)
            );
            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task SaveCreator(Creator creator, CancellationToken token)
        {
            _creatorCache.AddOrUpdate(creator.Id,
                _ => new MemoryCacheItem<Creator>(creator, DateTime.Now, creator.Name),
                (_, _) => new MemoryCacheItem<Creator>(creator, DateTime.Now, creator.Name)
            );
            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task SaveCreatorDetail(CreatorDetail detail, CancellationToken token)
        {
            _creatorDetailCache.AddOrUpdate(detail.Creator.Id,
                _ => new MemoryCacheItem<CreatorDetail>(detail, DateTime.Now, detail.Creator.Name),
                (_, _) => new MemoryCacheItem<CreatorDetail>(detail, DateTime.Now, detail.Creator.Name)
            );
            return Task.CompletedTask;
        }
        

        private List<T> GetSimilarFromCache<T>(ConcurrentDictionary<string, MemoryCacheItem<T>> cache, string name)
            where T : class
        {
            var normalizedName = CacheUtils.Normalize(name);
            var maxAge = DateTime.Now - _liveTime;
            return cache.Where(d => d.Value.NormalizedName.Contains(normalizedName) && d.Value.Inserted > maxAge)
                .Select(d => d.Value.Value).ToList();
        }

        private T? GetByIdFromCache<T>(IDictionary<string, MemoryCacheItem<T>> cache, string id) where T : class
        {
            if (cache.TryGetValue(id, out var item))
            {
                var maxAge = DateTime.Now + _liveTime;
                if (item.Inserted > maxAge)
                    return item.Value;
            }

            return default;
        }
    }
}