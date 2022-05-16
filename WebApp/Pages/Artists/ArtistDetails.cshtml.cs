using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UWS.Shared;

namespace UWS.Shared
{//Method used to get artist details and add albums on display
    public class ArtistDetailsModel : PageModel
    {
         private Chinook db;
        public ArtistDetailsModel(Chinook injectedContext)
        {
            db = injectedContext;
        }

        public Artist Artist { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Artist = await db.Artists.Include(t => t.Albums).FirstOrDefaultAsync(m => m.ArtistID == id);

            if (Artist == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
//David MacDonald