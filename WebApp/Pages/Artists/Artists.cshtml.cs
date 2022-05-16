using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using UWS.Shared;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

//Method used to query database and display artist details. Delete method at the bottom
namespace UWS.Shared
{
    public class ArtistsModel : PageModel
    {
      private Chinook db;

        public ArtistsModel(Chinook injectedContext)
        {
            db = injectedContext;
        }
        public List<Artist> ArtistList { get; set; }
        public void OnGet()
            {
                 var data = (from artistlist in db.Artists
                            select artistlist).ToList();
                 ArtistList = data;
            }
    
   
       public ActionResult OnGetDelete(int? id)//Method used to delete an artist and their contents
       {
           if (id != null)
           {
               var data = (from artist in db.Artists
                            where artist.ArtistID == id
                            select artist).SingleOrDefault();
                db.Remove(data);
                db.SaveChanges();
               } 
               return RedirectToPage("Artists");
       }
     
    }  
}
//David MacDonald