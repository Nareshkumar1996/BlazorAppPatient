using System.Collections;

namespace Healthware.Assist.Core.Utility
{
    public interface IContext
    {
        bool Contains<T>(IKey<T> key);
        void Add<T>(IKey<T> key, T value);
        T GetValueFor<T>(IKey<T> key);
        void Remove<T>(IKey<T> key);
    }

    public class DictionaryContext : IContext
    {
        readonly IDictionary items = new Hashtable();

        public bool Contains<T>(IKey<T> key)
        {
            return key.IsFoundIn(items);
        }

        public void Add<T>(IKey<T> key, T value)
        {
            key.AddValueTo(items, value);
        }

        public T GetValueFor<T>(IKey<T> key)
        {
            return key.ParseFrom(items);
        }

        public void Remove<T>(IKey<T> key)
        {
            key.RemoveFrom(items);
        }

        public int Count()
        {
            return items.Count;
        }
    }
}