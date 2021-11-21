using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CsfdClientNet.Cache;
using CsfdClientNet.Data;
using CsfdClientNet.Scrapping;
using Microsoft.Extensions.Logging;

namespace CsfdClientNet
{
    /// <summary>
    /// Csfd client
    /// </summary>
    public class CsfdClient
    {
        private readonly ICsfdClientCache _cache;
        private readonly ILoggerFactory _loggerFactory;
        private readonly ScrapperQueue _scrapperQueue;
        private readonly IWebDataReader _webDataReader;

        /// <summary>
        /// constructor with default options
        /// </summary>
        public CsfdClient() : this(new CsfdClientOptions())
        {
        }

        /// <summary>
        /// constructor with option settings
        /// </summary>
        /// <param name="options"></param>
        public CsfdClient(CsfdClientOptions options)
        {
            _cache = options.Cache ?? new MemoryCache(TimeSpan.FromMinutes(50));
            ;
            _loggerFactory = options.LoggerFactory ?? LoggerFactory.Create(_ => { });
            ;
            _scrapperQueue = new ScrapperQueue(options.RequestDelay ?? TimeSpan.FromSeconds(1), _cache,
                _loggerFactory.CreateLogger<ScrapperQueue>());
            _scrapperQueue.Start();
            _webDataReader = new WebDataReader();
        }

        /// <summary>
        /// Find movies by name
        /// </summary>
        /// <param name="name">movie name</param>
        /// <param name="useCache">use cache</param>
        /// <returns>movie list</returns>
        public Task<List<Movie>?> FindMovies(string name, bool useCache = true) =>
            FindMovies(name, CancellationToken.None);

        /// <summary>
        /// Find movies by name
        /// </summary>
        /// <param name="name">movie name</param>
        /// <param name="token">async cancelation token</param>
        /// <param name="useCache">use cache</param>
        /// <returns>movie list</returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<List<Movie>?> FindMovies(string name, CancellationToken token, bool useCache = true)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("name shouldnt be empty", nameof(name));
            var finder = new MovieFinder(name, useCache, _webDataReader);
            return await _scrapperQueue.ProcessItem(finder, token);
        }

        /// <summary>
        /// find creator by name
        /// </summary>
        /// <param name="name">creator name</param>
        /// <param name="useCache">use cache</param>
        /// <returns>Creators list</returns>
        public Task<List<Creator>?> FindCreator(string name, bool useCache = true) =>
            FindCreator(name, CancellationToken.None);

        /// <summary>
        /// find creator by name
        /// </summary>
        /// <param name="name">creator name</param>
        /// <param name="token">async cancellation token</param>
        /// <param name="useCache">use cache</param>
        /// <returns>Creators list</returns>
        public async Task<List<Creator>?> FindCreator(string name, CancellationToken token, bool useCache = true)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("name shouldnt be empty", nameof(name));
            var finder = new CreatorFinder(name, useCache, _webDataReader);
            return await _scrapperQueue.ProcessItem(finder, token);
        }

        /// <summary>
        /// Get movie detail
        /// </summary>
        /// <param name="movie">movie for detail</param>
        /// <param name="useCache">use cache</param>
        /// <returns>Movie detail</returns>
        public Task<MovieDetail?> GetMovieDetail(Movie movie, bool useCache = true) =>
            GetMovieDetail(movie, CancellationToken.None, useCache);

        /// <summary>
        /// Get movie detail
        /// </summary>
        /// <param name="movie">movie for detail</param>
        /// <param name="token">async cancellation token</param>
        /// <param name="useCache">use cache</param>
        /// <returns>Movie detail</returns>
        public async Task<MovieDetail?> GetMovieDetail(Movie movie, CancellationToken token, bool useCache = true)
        {
            MovieDetailReader r = new MovieDetailReader(movie, useCache, _webDataReader);
            await _scrapperQueue.ProcessItem(r, token);
            return await r.GetResult(token);
        }

        /// <summary>
        /// Get creator detail
        /// </summary>
        /// <param name="creator">creator</param>
        /// <param name="useCache">use cache</param>
        /// <returns>Creator detail</returns>
        Task<CreatorDetail?> GetCreatorDetail(Creator creator, bool useCache) =>
            GetCreatorDetail(creator, CancellationToken.None, useCache);

        /// <summary>
        /// Get creator detail
        /// </summary>
        /// <param name="creator">creator</param>
        /// <param name="token">async cancellation token</param>
        /// <param name="useCache">use cache</param>
        /// <returns>Creator detail</returns>
        public async Task<CreatorDetail?> GetCreatorDetail(Creator creator, CancellationToken token,
            bool useCache = true)
        {
            CreatorDetailReader r = new CreatorDetailReader(creator, useCache, _webDataReader);
            await _scrapperQueue.ProcessItem(r, token);
            return await r.GetResult(token);
        }
    }
}