using System;
using System.Collections.Generic;
using System.Text;
using AppleMusicAPI.NET.Enums;

namespace AppleMusicAPI.NET.Extensions
{
    public static class CatalogExtensions
    {
        public static string ToCatalogString(this Catalog catalog)
        {
            switch (catalog)
            {
                case Catalog.Albums:
                    return "albums";
                case Catalog.LibraryMusicVideos:
                    return "library-music-videos";
                case Catalog.Playlists:
                    return "playlists";
                case Catalog.Songs:
                    return "songs";
                case Catalog.Stations:
                    return "stations";
                case Catalog.MusicVideos:
                    return "music-videos";
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
