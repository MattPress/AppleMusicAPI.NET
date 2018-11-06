using System;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.LibraryResources;
using AppleMusicAPI.NET.Models.Resources;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AppleMusicAPI.NET.Models.JsonConverters
{
    public class ResourceJsonConverter : JsonConverter
    {
        public override bool CanWrite => false;
        public override bool CanRead => true;

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(IResource);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new InvalidOperationException("Use default serialization.");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            var resource = default(IResource);
            switch (jsonObject["type"].Value<string>())
            {
                case Constants.Resources.Activities:
                    resource = new Activity();
                    break;
                case Constants.Resources.Albums:
                    resource = new Album();
                    break;
                case Constants.Resources.AppleCurators:
                    resource = new AppleCurator();
                    break;
                case Constants.Resources.Artists:
                    resource = new Artist();
                    break;
                case Constants.Resources.Curators:
                    resource = new Curator();
                    break;
                case Constants.Resources.Genres:
                    resource = new Genre();
                    break;
                case Constants.Resources.LibraryAlbums:
                    resource = new LibraryAlbum();
                    break;
                case Constants.Resources.LibraryArtists:
                    resource = new LibraryArtist();
                    break;
                case Constants.Resources.LibraryMusicVideos:
                    resource = new LibraryMusicVideo();
                    break;
                case Constants.Resources.LibraryPlaylists:
                    resource = new LibraryPlaylist();
                    break;
                case Constants.Resources.LibrarySongs:
                    resource = new LibrarySong();
                    break;
                case Constants.Resources.MusicVideos:
                    resource = new MusicVideo();
                    break;
                case Constants.Resources.Ratings:
                    resource = new Rating();
                    break;
                case Constants.Resources.Recommendation:
                    resource = new Recommendation();
                    break;
                case Constants.Resources.Playlists:
                    resource = new Playlist();
                    break;
                case Constants.Resources.Songs:
                    resource = new Song();
                    break;
                case Constants.Resources.Stations:
                    resource = new Station();
                    break;
                case Constants.Resources.Storefronts:
                    resource = new Storefront();
                    break;
                default:
                    throw new NotSupportedException();
            }
            serializer.Populate(jsonObject.CreateReader(), resource);
            return resource;
        }
    }
}
