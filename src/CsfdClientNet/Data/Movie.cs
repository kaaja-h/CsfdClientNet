using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CsfdClientNet.Test")]

namespace CsfdClientNet.Data
{

    /// <summary>
    /// Csfd movie
    /// </summary>
    public class Movie
    {
        /// <summary>
        /// Movie contructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public Movie(string id, string name)
        {
            Id = id;
            Name = name;
        }
        
        /// <summary>
        /// Movie ID (csfd URL part)
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Movie name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Movie year
        /// </summary>
        public string? Year { get; internal set; }

    }
}