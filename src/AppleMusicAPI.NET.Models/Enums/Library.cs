using System.Runtime.Serialization;

namespace AppleMusicAPI.NET.Models.Enums
{
    public enum Library
    {
        [EnumMember(Value = "library-music-videos")]
        MusicVideos,
        [EnumMember(Value = "library-playlists")]
        Playlists,
        [EnumMember(Value = "library-songs")]
        Songs
    }
}