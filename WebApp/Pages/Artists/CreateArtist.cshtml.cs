using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using UWS.Shared;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace UWS.Shared
{//Create Artist method 
    public class CreateArtistModel : PageModel 
    {
        private Chinook db;

        public CreateArtistModel(Chinook injectedContext)
        {
            db = injectedContext;
        }
     
         [BindProperty]
         public Artist Artist { get; set; }
         public void OnGet()
         {
           
         }
         public ActionResult OnPost()
         {
            var artist = Artist;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            var result = db.Add(Artist);
             db.SaveChanges();
                return RedirectToPage("Artists");
           
         }
    }

}
//David MacDonald