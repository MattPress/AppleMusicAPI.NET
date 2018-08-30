using AppleMusicAPI.NET.Models.Core;

namespace AppleMusicAPI.NET.Models.Attributes
{
    /// <summary>
    /// The attributes for an activity object.
    /// https://developer.apple.com/documentation/applemusicapi/activity/attributes
    /// </summary>
    public class ActivityAttributes : IAttributes
    {
        /// <summary>
        /// (Required) The activity artwork.
        /// </summary>
        public Artwork Artwork { get; set; }

        /// <summary>
        /// The notes about the activity that appear in the iTunes Store.
        /// </summary>
        public EditorialNotes EditorialNotes { get; set; }

        /// <summary>
        /// (Required) The localized name of the activity.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// (Required) The URL for sharing an activity in the iTunes Store.
        /// </summary>
        public string Url { get; set; }
    }
}
