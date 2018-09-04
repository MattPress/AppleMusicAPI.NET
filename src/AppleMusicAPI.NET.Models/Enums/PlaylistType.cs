using System.Runtime.Serialization;

namespace AppleMusicAPI.NET.Models.Enums
{
    /// <summary>
    /// The type of playlist.
    /// </summary>
    public enum PlaylistType
    {
        /// <summary>
        /// A playlist created and shared by an Apple Music user.
        /// </summary>
        [EnumMember(Value = "user-shared")]
        UserShared,

        /// <summary>
        /// A playlist created by an Apple Music curator.
        /// </summary>
        [EnumMember(Value = "editorial")]
        Editorial,

        /// <summary>
        /// A playlist created by a non-Apple curator or brand.
        /// </summary>
        [EnumMember(Value = "external")]
        External,

        /// <summary>
        /// A personalized playlist for an Apple Music user.
        /// </summary>
        [EnumMember(Value = "personal-mix")]
        PersonalMix
    }
}