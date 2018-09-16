using System.Runtime.Serialization;

namespace AppleMusicAPI.NET.Models.Enums
{
    public enum LibraryResource
    {
        [EnumMember(Value = "library-albums")]
        Albums,
        [EnumMember(Value = "library-artists")]
        Artists,
        [EnumMember(Value = "library-music-videos")]
        MusicVideos,
        [EnumMember(Value = "library-playlists")]
        Playlists,
        [EnumMember(Value = "library-songs")]
        Songs
    }
}