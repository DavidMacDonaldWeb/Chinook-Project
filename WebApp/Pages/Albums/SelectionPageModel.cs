using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UWS.Shared;

namespace UWS.Shared
{//Selection Model used to query database for seperate tables to add into the dropdown lists
    public class SelectionPageModel : PageModel
    {
        public SelectList ArtistNameSL { get; set; }
        public SelectList AlbumNameSL { get; set; }
        public SelectList MediaTypeNameSL { get; set; }
        public SelectList GenreNameSL { get; set; }
        
        public void PopulateArtistsDropDownList(Chinook db,
            object selectedArtist = null)
            {
                var artistsQuery = from a in db.Artists
                                        orderby a.Name
                                        select a;

                ArtistNameSL = new SelectList(artistsQuery, "ArtistID", "Name");
            }

             public void PopulateAlbumsDropDownList(Chinook db,
            object selectedAlbum = null)
            {
                var albumsQuery = from a in db.Albums
                                orderby a.Title
                                select a;
                
                AlbumNameSL = new SelectList(albumsQuery, "AlbumID", "Title");
            }

            public void PopulateMediaTypesDropDownList(Chinook db,
            object selectedMediaType = null)
            {
                var mediaTypesQuery = from m in db.Media_Types
                                    orderby m.Name
                                    select m;

                MediaTypeNameSL = new SelectList(mediaTypesQuery, "MediaTypeID", "Name");
            }

            public void PopulateGenresDropDownList(Chinook db,
            object selectedGenre = null)
            {
                var GenresQuery = from m in db.Genres
                                orderby m.Name
                                select m;

                GenreNameSL = new SelectList(GenresQuery, "GenreID", "Name");
            }


        
    }
}
//David MacDonald