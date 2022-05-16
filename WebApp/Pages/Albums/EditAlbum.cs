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
    public class EditAlbumModel : SelectionPageModel
    {
        private Chinook db;

        public EditAlbumModel(Chinook injectedContext)
        {
            db = injectedContext;
        }
        [BindProperty]
        public Album Album { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            PopulateArtistsDropDownList(db);//adds Artists to the dropdown list

            if (id == null)
            {
                return NotFound();//returns error if none exist
            }

            Album = await db.Albums.SingleOrDefaultAsync(m => m.AlbumID == id);//Gets album by ID

            if (Album == null)
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

            db.Attach(Album).State = EntityState.Modified;//Confirms edits

            try
            {
                await db.SaveChangesAsync();//Saves edits
            }
            catch (DbUpdateConcurrencyException)
            {
                
            }

            return RedirectToPage("Albums");//Returns user ro album page
        }
        
    }
}

//David MacDonald

/*Method below for dispalying data as integers and not dropdowns(Saved for future reference)
        
        public void OnGet(int? id)
        {
            PopulateArtistsDropDownList(db);

            if (id != null)
            {
                var data = (from album in db.Albums
                            where album.AlbumID == id
                            select album).SingleOrDefault();
                            Album = data;
            }
        }
        public ActionResult OnPost()
        {
            var album = Album;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            db.Entry(album).Property(a => a.Title).IsModified =true;
            db.SaveChanges();
            return RedirectToPage("/Albums");
        }*/