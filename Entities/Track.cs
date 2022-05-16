using System.Collections.Generic;

namespace UWS.Shared
{
    public class Track
    {
        public int TrackID { get; set; }
        public string Name { get; set; }
        public int AlbumID { get; set; }
        public int? MediaTypeID { get; set; }
        public int? GenreID { get; set; }
        public string Composer { get; set; }
        public int Milliseconds { get; set; }
        public int Bytes { get; set; }
        public decimal UnitPrice { get; set; } = 0;

        //Related Entities
        public Album Albums { get; set; }
        //public ICollection<MediaType> MediaTypes { get; set; }
       // public ICollection<Genre> Genres { get; set; }


    }
}