using System.Runtime.Serialization;

namespace AppleMusicAPI.NET.Models.Enums
{
    public enum ResourceType
    {
        [EnumMember(Value = "activities")]
        Activities,
        [EnumMember(Value = "artists")]
        Artists,
        [EnumMember(Value = "albums")]
        Albums,
        [EnumMember(Value = "apple-curators")]
        AppleCurators,
        [EnumMember(Value = "curators")]
        Curators,
        [EnumMember(Value = "genres")]
        Genres,
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