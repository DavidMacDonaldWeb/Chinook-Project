using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UWS.Shared
{
    public class CreateTrackModel : SelectionPageModel
    {
        private Chinook db;

        public CreateTrackModel(Chinook injectedContext)
        {
            db = injectedContext;
        }
        
        public IActionResult OnGet()
        {
            PopulateAlbumsDropDownList(db);
            PopulateMediaTypesDropDownList(db);//Used to populate dropdown lists
            PopulateGenresDropDownList(db);
            return Page();
        }

        [BindProperty]
        public Track Track { get; set; }
        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            db.Tracks.Add(Track);//Adds new track to the database
            db.SaveChanges();
                return RedirectToPage("Tracks");
        }
        
    }
}
//David MacDonald