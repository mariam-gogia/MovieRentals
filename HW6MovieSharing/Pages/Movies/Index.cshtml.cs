using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HW6MovieSharing.Data;
using HW6MovieSharing.Models;
using HW6MovieSharing.Pages.Shared;

namespace HW6MovieSharing.Pages.Movies
{
    public class IndexModel : BasePageModel
    {
        /// <summary>
        /// Initialize a new instance of IndexModel
        /// </summary>
        /// <param name="context"> database </param>
        public IndexModel(HW6MovieSharing.Data.HW6MovieSharingContext context) : base(context)
        {
        }  

        /// <summary>
        /// Gets or sets the move
        /// </summary>
        public IList<Movie> Movie { get; set; }
        public IList<Movie> MyMovies { get; set; }
        public Movie CurrentMovie { get; set; }

        /// <summary>
        /// Gets list of movies
        /// </summary>
        /// <returns> Task </returns>

        public async Task OnGetAsync()
        {
            // If owner is signed in - list all the movies
            if (User.ObjectIdentifier() == "c17f0d89-9862-45ca-beca-5b0c5ca2ae7e")
            {
                Movie = await Context.Movie.ToListAsync();
            }
            // Otherwise show only sharable movies
            else
            {
                Movie = await Context.Movie.Where(_ => _.IsShareable == true).ToListAsync();

                // Under MyMovies, display the movies owned by the specific user only
                MyMovies = await Context.Movie.Where(_ => _.UserID == AuthenticatedUserInfo.ObjectIdentifier).ToListAsync();
            }
        }
    }
}
