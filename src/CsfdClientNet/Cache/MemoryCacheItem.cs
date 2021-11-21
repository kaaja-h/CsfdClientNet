using System;

namespace CsfdClientNet.Cache
{

    internal class MemoryCacheItem<T> where T : class
    {
        public MemoryCacheItem(T value, DateTime inserted, string name)
        {
            Value = value;
            Inserted = inserted;
            NormalizedName = CacheUtils.Normalize(name);
        }

        public T Value { get; }
        public DateTime Inserted { get; }

        public string NormalizedName { get; }
    }
}