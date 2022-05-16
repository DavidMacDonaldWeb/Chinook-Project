using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using UWS.Shared;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace UWS.Shared
{//Method used to edit artist details by getting the PK
    public class EditArtistModel : PageModel
    {
        private Chinook db;

        public EditArtistModel(Chinook injectedContext)
        {
            db = injectedContext;
        }
        [BindProperty]
        public Artist Artist { get; set; }

        public void OnGet(int? id)
        {
            if (id != null)
            {
                var data = (from artist in db.Artists
                            where artist.ArtistID == id
                            select artist).SingleOrDefault();
                            Artist = data;
            }
        }
        public ActionResult OnPost()
        {
            var artist = Artist;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            db.Entry(artist).Property(c => c.Name).IsModified =true;
            db.SaveChanges();
            return RedirectToPage("Artists");
        }
        
    }
}
//David MacDonald