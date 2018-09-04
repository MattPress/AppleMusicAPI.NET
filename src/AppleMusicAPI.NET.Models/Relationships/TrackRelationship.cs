using System.Collections.Generic;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Resources;
using Newtonsoft.Json;

namespace AppleMusicAPI.NET.Models.Relationships
{
    /// <summary>
    /// An object that represents the track relationship for a Resource object.
    /// https://developer.apple.com/documentation/applemusicapi/trackrelationship
    /// </summary>
    /// <inheritdoc />
    public class TrackRelationship : Relationship
    {
        [JsonIgnore]
        public List<Song> SongsData => GetDataOfType<Song>();

        [JsonIgnore]
        public List<MusicVideo> MusicVideoData => GetDataOfType<MusicVideo>();
    }
}
