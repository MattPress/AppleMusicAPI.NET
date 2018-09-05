using System;
using System.Collections.Generic;
using System.Linq;

namespace AppleMusicAPI.NET.Extensions
{
    public static class DictionaryExtensions
    {
        public static void Merge<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, IDictionary<TKey, TValue> dictionaryToMerge)
        {
            foreach (var item in dictionaryToMerge.Where(x => !dictionary.ContainsKey(x.Key)))
            {
                dictionary[item.Key] = item.Value;
            }
        }
    }
}
