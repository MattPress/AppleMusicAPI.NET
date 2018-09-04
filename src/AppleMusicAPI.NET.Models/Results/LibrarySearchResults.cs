using System.Collections.Generic;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.LibraryResources;
using AppleMusicAPI.NET.Models.Responses;
using Newtonsoft.Json;

namespace AppleMusicAPI.NET.Models.Results
{
    public class LibrarySearchResults : IResults
    {
        [JsonProperty("library-albums")]
        public List<LibraryAlbum> LibraryAlbums { get; set; }

        [JsonProperty("library-artists")]
        public List<LibraryArtist> LibraryArtists { get; set; }

        [JsonProperty("library-music-videos")]
        public List<LibraryMusicVideo> LibraryMusicVideos { get; set; }

        [JsonProperty("library-playlists")]
        public List<LibraryPlaylistResponse> LibraryPlaylists { get; set; }

        [JsonProperty("library-songs")]
        public List<LibrarySong> LibrarySongs { get; set; }
    }
}
