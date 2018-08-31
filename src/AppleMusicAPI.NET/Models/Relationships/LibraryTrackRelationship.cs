using System.Collections.Generic;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.LibraryResources;
using Newtonsoft.Json;

namespace AppleMusicAPI.NET.Models.Relationships
{
    /// <summary>
    /// An object that represents the library track relationship for a Resource object.
    /// https://developer.apple.com/documentation/applemusicapi/librarytrackrelationship
    /// </summary>
    /// <inheritdoc />
    public class LibraryTrackRelationship : Relationship
    {
        [JsonIgnore]
        public List<LibrarySong> LibrarySongsData => GetDataOfType<LibrarySong>();

        [JsonIgnore]
        public List<LibraryMusicVideo> LibraryMusicVideosData => GetDataOfType<LibraryMusicVideo>();
    }
}
