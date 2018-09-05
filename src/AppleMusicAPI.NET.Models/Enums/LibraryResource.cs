using System.Runtime.Serialization;

namespace AppleMusicAPI.NET.Models.Enums
{
    public enum LibraryResource
    {
        [EnumMember(Value = "albums")]
        Albums,
        [EnumMember(Value = "artists")]
        Artists,
        [EnumMember(Value = "music-videos")]
        MusicVideos,
        [EnumMember(Value = "playlists")]
        Playlists,
        [EnumMember(Value = "songs")]
        Songs,
    }
}