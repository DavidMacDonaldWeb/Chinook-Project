using System.Collections.Generic;
using System.Diagnostics;


namespace UWS.Shared
{
   //[Table("Artists")]
    public class Artist
    {
       //[Display(Name = "Name")]
       public int ArtistID { get; set; }
      //[Required(ErrorMessage = "Enter Name")]
       public string Name { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
       
    }
}