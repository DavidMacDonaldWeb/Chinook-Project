using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UWS.Shared;

namespace UWS.Shared
{
    public class EditTrackModel : SelectionPageModel
    {
        private Chinook db;

        public EditTrackModel(Chinook injectedContext)
        {
            db = injectedContext;
        }
        [BindProperty]
        public Track Track { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
			PopulateAlbumsDropDownList(db);
            PopulateMediaTypesDropDownList(db);
            PopulateGenresDropDownList(db);
			
            if (id == null)
            {
                return NotFound();
            }

            Track = await db.Tracks.SingleOrDefaultAsync(m => m.TrackID == id);

            if (Track == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            db.Attach(Track).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                
            }

            return RedirectToPage("Tracks");
        }

    }
}

//David MacDonald

       /*Code works without dropdowns (Saved for future reference)
       
       public void OnGet(int? id)
        {
            if (id != null)
            {
                var data = (from track in db.Tracks
                            where track.TrackID == id
                            select track).SingleOrDefault();
                            Track = data;
            }
        }
          public ActionResult OnPost()
        {
            var track = Track;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            db.Entry(track).Property(a => a.Name).IsModified =true;
            db.Entry(track).Property(a => a.Composer).IsModified =true;
            db.Entry(track).Property(a => a.AlbumID).IsModified =true;
            db.Entry(track).Property(a => a.MediaTypeID).IsModified =true;
            db.Entry(track).Property(a => a.GenreID).IsModified =true;
            db.Entry(track).Property(a => a.Milliseconds).IsModified =true;
            db.Entry(track).Property(a => a.Bytes).IsModified =true;
            db.Entry(track).Property(a => a.UnitPrice).IsModified =true;
            db.SaveChanges();
            return RedirectToPage("Tracks");
        }*/