using System;
using CsfdClientNet.Cache;
using Microsoft.Extensions.Logging;

namespace CsfdClientNet
{
    /// <summary>
    /// Csfd client options
    /// </summary>
    public class CsfdClientOptions
    {
        /// <summary>
        /// Logger factory
        /// </summary>
        public ILoggerFactory? LoggerFactory { get; set; }

        /// <summary>
        /// Cleint cache, Default MemoryCache <see cref="MemoryCache"/>
        /// </summary>
        public ICsfdClientCache? Cache { get; set; }

        /// <summary>
        /// Delay between requests
        /// </summary>
        public TimeSpan? RequestDelay { get; set; }
    }
}