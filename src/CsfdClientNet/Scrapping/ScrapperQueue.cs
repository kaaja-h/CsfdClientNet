using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using CsfdClientNet.Cache;
using Microsoft.Extensions.Logging;

namespace CsfdClientNet.Scrapping
{

    internal class ScrapperQueue
    {
        private readonly ICsfdClientCache _cache;
        private readonly TimeSpan _hitInterval;
        private readonly ILogger<ScrapperQueue> _logger;

        private readonly BlockingCollection<ScrapperQueueItem> _queue = new();

        private readonly CancellationTokenSource _source = new();

        public ScrapperQueue(TimeSpan hitInterval, ICsfdClientCache cache,
            ILogger<ScrapperQueue> logger)
        {
            _hitInterval = hitInterval;
            _cache = cache;
            _logger = logger;
        }


        public async Task<T?> ProcessItem<T>(ScrapperQueueItem<T> item, CancellationToken token)
        {
            if (!await item.Precheck(_cache, token))
                _queue.Add(item, token);
            return await item.GetResult(token);
        }

        public void Start()
        {
            Task.Run(() => Process());
        }

        private void Process()
        {
            while (!_source.IsCancellationRequested)
                try
                {
                    var item = _queue.Take(_source.Token);
                    item.Process(_cache, _source.Token);
                    Task.Delay(_hitInterval, _source.Token);
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Error processing queue item");
                }
        }

        public void End()
        {
            _source.Cancel();
        }
    }
}