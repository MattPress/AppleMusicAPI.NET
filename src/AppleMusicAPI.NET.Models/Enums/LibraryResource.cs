using System.Runtime.Serialization;

namespace AppleMusicAPI.NET.Models.Enums
{
    // TODO - MJP - Can this be shared between ratings and resources? ratings uses library-music-videos, what does resources use
    public enum LibraryResource
    {
        [EnumMember(Value = "albums")]
        Albums,
        [EnumMember(Value = "artists")]
        Artists,
        [EnumMember(Value = "library-music-videos")]
        MusicVideos,
        [EnumMember(Value = "library-playlists")]
        Playlists,
        [EnumMember(Value = "library-songs")]
        Songs,
    }
}