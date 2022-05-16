using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace UWS.Shared
{
    public class TracksModel : SelectionPageModel
    {
        private Chinook db;

            public TracksModel(Chinook injectedContext)
            {
                db = injectedContext;
            }
            public List<Track> TrackList { get; set; }
            public void OnGet()
            {
                var data = (from tracklist in db.Tracks
                            select tracklist).ToList();
                TrackList = data;
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
            return RedirectToPage("Tracks");
        }
    }
}
//David MacDonald