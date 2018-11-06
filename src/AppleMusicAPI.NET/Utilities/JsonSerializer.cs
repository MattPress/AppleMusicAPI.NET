using System;
using System.Collections.Generic;
using System.Text;
using AppleMusicAPI.NET.Models.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AppleMusicAPI.NET.Utilities
{
    public class JsonSerializer : IJsonSerializer
    {
        private static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        private static readonly JsonSerializerSettings JsonDeserializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            TypeNameHandling = TypeNameHandling.Auto,
            NullValueHandling = NullValueHandling.Ignore
        };

        public string Serialize(object request)
        {
            return JsonConvert.SerializeObject(request, JsonSerializerSettings);
        }

        public T Deserialize<T>(string response)
        {
            return JsonConvert.DeserializeObject<T>(response, JsonDeserializerSettings);
        }
    }
}
