using System.Runtime.Serialization;

namespace AppleMusicAPI.NET.Enums
{
#pragma warning disable IDE1006 // Naming Styles
    public enum iCloudMusicLibraryType
#pragma warning restore IDE1006 // Naming Styles
    {
        [EnumMember(Value = "albums")]
        Albums,
        [EnumMember(Value = "music-videos")]
        MusicVideos,
        [EnumMember(Value = "playlists")]
        Playlists,
        [EnumMember(Value = "songs")]
        Songs
    }
}