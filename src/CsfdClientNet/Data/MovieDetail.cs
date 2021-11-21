using System.Collections.Generic;

namespace CsfdClientNet.Data
{
/// <summary>
/// Movie detail
/// </summary>
    public class MovieDetail
    {
        internal MovieDetail(Movie movie)
        {
            Movie = movie;
        }

        /// <summary>
        /// Creator of movie sorted by profession
        /// </summary>
        public Dictionary<string, List<Creator>> Professions { get; } = new Dictionary<string, List<Creator>>();
        
        /// <summary>
        /// Movie plots 
        /// </summary>
        public IReadOnlyList<string> Plots { get; internal set; } = new List<string>();

        /// <summary>
        /// Average rating (percent)
        /// </summary>
        public decimal RatingAverage { get; internal set; }
        
        /// <summary>
        /// Rating count
        /// </summary>
        public int RatingCount { get; internal set; }
        
        /// <summary>
        /// List of genres
        /// </summary>
        public IReadOnlyList<string> Genres { get; internal set; } = new List<string>();
        
        /// <summary>
        /// Date created 
        /// </summary>
        public string? DateCreated { get; internal set; }
        
        /// <summary>
        /// Movie origin
        /// </summary>
        public string? Origin { get; internal set; }
        
        /// <summary>
        /// Movie length
        /// </summary>
        public string? Length { get; internal set; }
        
        /// <summary>
        /// Movie
        /// </summary>
        public Movie Movie { get; }
    }
}