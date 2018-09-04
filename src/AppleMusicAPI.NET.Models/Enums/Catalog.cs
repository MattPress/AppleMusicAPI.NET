using System.Runtime.Serialization;

namespace AppleMusicAPI.NET.Models.Enums
{
    public enum Catalog
    {
        [EnumMember(Value = "albums")]
        Albums,
        [EnumMember(Value = "library-music-videos")]
        LibraryMusicVideos,
        [EnumMember(Value = "playlists")]
        Playlists,
        [EnumMember(Value = "songs")]
        Songs,
        [EnumMember(Value = "stations")]
        Stations,
        [EnumMember(Value = "music-videos")]
        MusicVideos
    }
}