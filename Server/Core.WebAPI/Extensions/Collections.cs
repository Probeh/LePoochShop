using System.Collections.Generic;

namespace Core.WebAPI.Extensions
{
    public static partial class Extension
    {
        public static Dictionary<TKey, TValue> Append<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            dictionary.Add(key, value);
            return dictionary;
        }
    }
}