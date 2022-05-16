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
    public class AlbumDetailsModel : PageModel
    {
         private Chinook db;

        public AlbumDetailsModel(Chinook injectedContext)
        {
            db = injectedContext;
        }

        public Album Album { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Album = await db.Albums.Include(b => b.Tracks)
                .Include(a => a.Artist).FirstOrDefaultAsync(m => m.AlbumID == id);//method to include tracks and artists in the details page

            if (Album == null)
            {
                return NotFound();
            }
            return Page();//returns not found if album no longer exsists
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
            return RedirectToPage("Albums");//Method used to delete tracks in the album details page
        }
    }
    //David MacDonald
}