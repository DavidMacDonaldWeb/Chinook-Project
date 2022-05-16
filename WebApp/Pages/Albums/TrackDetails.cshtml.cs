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
    public class TrackDetailsModel : PageModel
    {
        private Chinook db;
        public TrackDetailsModel(Chinook injectedContext)
        {
            db = injectedContext;
        }

        public Album Album { get; set; }

        public Track Track { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Album = await db.Albums.Include(t => t.Tracks).FirstOrDefaultAsync(m => m.AlbumID == id);

            if (Album == null)
            {
                return NotFound();
            }
            return Page();
        }
         public ActionResult OnGetDelete(int? id)
        {
            if (id != null)
            {
                var data = (from track in db.Tracks
                            where track.TrackID == id
                            select track).SingleOrDefault();
                db.Remove(data);
                db.SaveChanges();
            }
            return RedirectToPage("Albums");
        }
    }
}
//David MacDonald