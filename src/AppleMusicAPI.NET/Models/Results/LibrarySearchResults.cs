using System;
using System.Collections.Generic;
using System.Text;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Resources;
using AppleMusicAPI.NET.Models.Responses;
using Newtonsoft.Json;

namespace AppleMusicAPI.NET.Models.Results
{
    public class LibrarySearchResults : IResults
    {
        [JsonProperty("library-albums")]
        public LibraryAlbum[] LibraryAlbums { get; set; }

        [JsonProperty("library-artists")]
        public LibraryArtist[] LibraryArtists { get; set; }

        [JsonProperty("library-music-videos")]
        public LibraryMusicVideo[] LibraryMusicVideos { get; set; }

        [JsonProperty("library-playlists")]
        public LibraryPlaylistResponse[] LibraryPlaylists { get; set; }

        [JsonProperty("library-songs")]
        public LibrarySong[] LibrarySongs { get; set; }
    }
}
