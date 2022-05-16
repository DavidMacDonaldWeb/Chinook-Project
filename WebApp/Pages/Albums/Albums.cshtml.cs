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
    public class AlbumsModel : PageModel
    {
        private Chinook db;

            public AlbumsModel(Chinook injectedContext)
            {
                db = injectedContext;
            }
            public List<Album> Albums { get; set; }
            public async Task OnGetAsync()
            {
                ViewData["Title"] = "Chinook Web site - Albums";
                Albums = await db.Albums.Include(a => a.Artist).ToListAsync();
                /*var data = (from albumlist in db.Albums
                            select albumlist).ToList();
                AlbumList = data;*/
            }

        public ActionResult OnGetDelete(int? id)
        {
            if (id != null)
            {
                var data = (from album in db.Albums
                            where album.AlbumID == id
                            select album).SingleOrDefault();
                db.Remove(data);
                db.SaveChanges();
            }
            return RedirectToPage("Albums");//Method to delete album
        }
        
    }
}
//David MacDonald