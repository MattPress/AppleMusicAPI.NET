using System.Collections.Generic;
using System.Linq;
using AppleMusicAPI.NET.Models.JsonConverters;
using Newtonsoft.Json;

namespace AppleMusicAPI.NET.Models.Core
{
    public class Relationship : RelationshipRoot
    {
        /// <summary>
        /// One or more destination objects.
        /// </summary>
        [JsonProperty(ItemConverterType = typeof(ResourceJsonConverter))]
        public List<IResource> Data { get; set; }

        /// <summary>
        /// Get Resources of a specific Type from the Data collection.
        /// Only required when the Data collections may contain multiple Types.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected List<T> GetDataOfType<T>()
        {
            return (Data ?? new List<IResource>())
                .OfType<T>()
                .ToList();
        }
    }
}
