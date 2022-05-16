using System.Collections.Generic;


namespace UWS.Shared
{
    public class Album
    {
      
        public int AlbumID { get; set; }
        public string Title { get; set; }
        public int ArtistID { get; set; }
        
        //related entities
        public Artist Artist { get; set; }
         public virtual ICollection<Track> Tracks { get; set; }
    }
}
