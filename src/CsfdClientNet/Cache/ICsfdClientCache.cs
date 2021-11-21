using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CsfdClientNet.Data;

namespace CsfdClientNet.Cache
{

    /// <summary>
    /// Csfd data Cache interface
    /// </summary>
    public interface ICsfdClientCache
    {
        /// <summary>
        /// Finds movie by name
        /// </summary>
        /// <param name="name">movie name</param>
        /// <param name="token">async cancellation token</param>
        /// <returns>list of movies</returns>
        public Task<List<Movie>> FindMovieByName(string name, CancellationToken token);

        /// <summary>
        /// Get movie by detail
        /// </summary>
        /// <param name="id">movie id</param>
        /// <param name="token">async cancellation token</param>
        /// <returns>movie detail</returns>
        public Task<MovieDetail?> GetMovieDetail(string id, CancellationToken token);

        /// <summary>
        /// Find creator by name
        /// </summary>
        /// <param name="name">creator name</param>
        /// <param name="token">async cancellation token</param>
        /// <returns>list of creators</returns>
        public Task<List<Creator>> FindCreatorByName(string name, CancellationToken token);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">creator id</param>
        /// <param name="token">async cancellation token</param>
        /// <returns>creator detail</returns>
        public Task<CreatorDetail?> GetCreatorDetail(string id, CancellationToken token);

        /// <summary>
        /// Save movie to cache
        /// </summary>
        /// <param name="movie">movie to save</param>
        /// <param name="token">async cancellation token</param>
        /// <returns></returns>
        public Task SaveMovie(Movie movie, CancellationToken token);
        
        /// <summary>
        /// Save movie detail to cache
        /// </summary>
        /// <param name="movieDetail">movie detail to save</param>
        /// <param name="token">async cancellation token</param>
        /// <returns></returns>
        public Task SaveMovieDetail(MovieDetail movieDetail, CancellationToken token);
        
        /// <summary>
        /// Save Creator to cache
        /// </summary>
        /// <param name="creator">creator to save</param>
        /// <param name="token">async cancellation token</param>
        /// <returns></returns>
        public Task SaveCreator(Creator creator, CancellationToken token);
        
        /// <summary>
        /// Save CreatorDetail to cache
        /// </summary>
        /// <param name="detail">CreatorDetail to save</param>
        /// <param name="token">async cancellation token</param>
        /// <returns></returns>
        public Task SaveCreatorDetail(CreatorDetail detail, CancellationToken token);

        
    }
}