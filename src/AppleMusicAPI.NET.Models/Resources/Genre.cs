using AppleMusicAPI.NET.Models.Attributes;
using AppleMusicAPI.NET.Models.Core;

namespace AppleMusicAPI.NET.Models.Resources
{
    /// <summary>
    /// An object that represents a genre for resources.
    /// https://developer.apple.com/documentation/applemusicapi/genre
    /// </summary>
    /// <inheritdoc />
    public class Genre : Resource<GenreAttributes>
    {
        /// <summary>
        /// (Required) This value will always be genres.
        /// Value: genres
        /// </summary>
        public override string Type => Constants.Resources.Genres;
    }
}
