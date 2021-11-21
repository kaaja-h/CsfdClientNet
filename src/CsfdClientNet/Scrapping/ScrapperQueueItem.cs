using System;
using System.Threading;
using System.Threading.Tasks;
using CsfdClientNet.Cache;

namespace CsfdClientNet.Scrapping
{

    internal abstract class ScrapperQueueItem
    {
        public abstract Task Process(ICsfdClientCache cache, CancellationToken token);

        public abstract Task<bool> Precheck(ICsfdClientCache cache, CancellationToken token);
    }

    internal abstract class ScrapperQueueItem<T> : ScrapperQueueItem
    {
        protected readonly ManualResetEventSlim Waiter = new(false);
        protected readonly bool UseCache;
        protected readonly IWebDataReader WebDataReader;

        protected ScrapperQueueItem(bool useCache, IWebDataReader webDataReader)
        {
            this.UseCache = useCache;
            WebDataReader = webDataReader;
        }

        protected T? Result { get; set; }
        protected abstract Task<T?> ProcessInternal(ICsfdClientCache cache, CancellationToken token);
        protected abstract Task<T?> CheckCache(ICsfdClientCache cache, CancellationToken token);
        private Exception? e;

        public override async Task<bool> Precheck(ICsfdClientCache cache, CancellationToken token)
        {
            if (!UseCache)
                return false;
            var res = await CheckCache(cache, token);
            if (res != null)
            {
                Result = res;
                Waiter.Set();
                return true;
            }

            return false;
        }

        public override async Task Process(ICsfdClientCache cache, CancellationToken token)
        {
            try
            {
                if (UseCache)
                {
                    Result = await CheckCache(cache, token);
                }

                Result = Result ?? await ProcessInternal(cache, token);
            }
            catch (Exception e)
            {
                this.e = e;
            }
            finally
            {
                Waiter.Set();
            }


        }

        public Task<T?> GetResult(CancellationToken token)
        {
            return Task.Run(() =>
            {
                var r = token.Register(() => Waiter.Set());
                Waiter.Wait();
                r.Dispose();
                if (e != null)
                    throw new Exception("error processing item", e);
                return Result;
            }, token);

        }
    }
}