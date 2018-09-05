using System.Runtime.Serialization;

namespace AppleMusicAPI.NET.Models.Enums
{
    public enum AlbumRelationship
    {
        [EnumMember(Value = "artists")]
        Artists,
        [EnumMember(Value = "genres")]
        Genres,
        [EnumMember(Value = "tracks")]
        Tracks
    }
}