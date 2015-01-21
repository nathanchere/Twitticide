using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace System.Collections.Concurrent
{
    public class ConcurrentHashset<T> : ICollection<T>, IEnumerable<T>, IEnumerable
    {
        ConcurrentDictionary<T, byte> storage;

        public ConcurrentHashset()
        {
            storage = new ConcurrentDictionary<T, byte>();
        }

        public ConcurrentHashset(IEnumerable<T> collection)
        {
            storage = new ConcurrentDictionary<T, byte>(collection.Select(_ => new KeyValuePair<T, byte>(_, 0)));
        }

        public ConcurrentHashset(IEqualityComparer<T> comparer)
        {
            storage = new ConcurrentDictionary<T, byte>(comparer);
        }

        public ConcurrentHashset(IEnumerable<T> collection, IEqualityComparer<T> comparer)
        {
            storage = new ConcurrentDictionary<T, byte>(collection.Select(_ => new KeyValuePair<T, byte>(_, 0)), comparer);
        }

        public ConcurrentHashset(int concurrencyLevel, int capacity)
        {
            storage = new ConcurrentDictionary<T, byte>(concurrencyLevel, capacity);
        }

        public ConcurrentHashset(int concurrencyLevel, IEnumerable<T> collection, IEqualityComparer<T> comparer)
        {
            storage = new ConcurrentDictionary<T, byte>(concurrencyLevel, collection.Select(_ => new KeyValuePair<T, byte>(_, 0)), comparer);
        }

        public ConcurrentHashset(int concurrencyLevel, int capacity, IEqualityComparer<T> comparer)
        {
            storage = new ConcurrentDictionary<T, byte>(concurrencyLevel, capacity, comparer);
        }

        public int Count { get { return storage.Count; } }

        public bool IsEmptry { get { return storage.IsEmpty; } }

        public void Clear()
        {
            storage.Clear();
        }

        public bool Contains(T item)
        {
            return storage.ContainsKey(item);
        }

        public bool TryAdd(T item)
        {
            return storage.TryAdd(item, 0);
        }

        public bool TryRemove(T item)
        {
            byte dontCare;
            return storage.TryRemove(item, out dontCare);
        }

        void ICollection<T>.Add(T item)
        {
            ((ICollection<KeyValuePair<T, byte>>)storage).Add(new KeyValuePair<T, byte>(item, 0));
        }

        void ICollection<T>.CopyTo(T[] array, int arrayIndex)
        {
            foreach (KeyValuePair<T, byte> pair in storage)
                array[arrayIndex++] = pair.Key;
        }

        bool ICollection<T>.IsReadOnly
        {
            get { return false; }
        }

        bool ICollection<T>.Remove(T item)
        {
            return TryRemove(item);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return storage.Keys.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return storage.Keys.GetEnumerator();
        }
    }
}

