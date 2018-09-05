using System.Runtime.Serialization;

namespace AppleMusicAPI.NET.Models.Enums
{
    public enum LibraryAlbumRelationship
    {
        [EnumMember(Value = "artists")]
        Artists,
        [EnumMember(Value = "tracks")]
        Tracks
    }
}