using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace UWS.Shared
{
    public class CreateAlbumModel : SelectionPageModel
    {
        private Chinook db;

        public CreateAlbumModel(Chinook injectedContext)
        {
            db = injectedContext;
        }
    
       // public IEnumerable<string> Albums { get; set; }
        
        public IActionResult OnGet()
        {
            PopulateArtistsDropDownList(db);//Adds artists names to the dropdown list
            return Page();
       
        }
         [BindProperty]
         public Album Album { get; set; }
    
        
        public ActionResult OnPost()
         {
             var album = Album;
             if (!ModelState.IsValid)
             {
                 return Page();
             }

             var result = db.Add(Album);//Used to add a new album and return user ro the albums page
             db.SaveChanges();
                return RedirectToPage("Albums");

         }

    }

}
//*David MacDonald 