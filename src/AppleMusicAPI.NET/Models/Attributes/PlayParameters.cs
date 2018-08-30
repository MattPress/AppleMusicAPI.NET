
namespace AppleMusicAPI.NET.Models.Attributes
{
    /// <summary>
    /// An object that represents play parameters for resources.
    /// https://developer.apple.com/documentation/applemusicapi/playparameters
    /// </summary>
    public class PlayParameters
    {
        /// <summary>
        /// (Required) The ID of the content to use for playback.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// (Required) The kind of the content to use for playback.
        /// </summary>
        public string Kind { get; set; }
    }
}
