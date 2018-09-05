using System.Runtime.Serialization;

namespace AppleMusicAPI.NET.Models.Enums
{
    public enum ArtistRelationship
    {
        [EnumMember(Value = "albums")]
        Albums,
        [EnumMember(Value = "genres")]
        Genres,
        [EnumMember(Value = "musicVideos")]
        MusicVideos,
        [EnumMember(Value = "playlists")]
        Playlists,
        [EnumMember(Value = "stations")]
        Stations
    }
}