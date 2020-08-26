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
    public class DeleteModel : BasePageModel
    {

        public DeleteModel(HW6MovieSharing.Data.HW6MovieSharingContext context) : base(context)
        {
        }

        [BindProperty]
        public Movie Movie { get; set; }

        /// <summary>
        /// Displays details of the movie
        /// </summary>
        /// <param name="id"> Movie ID </param>
        /// <returns></returns>
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await Context.Movie.FirstOrDefaultAsync(m => m.ID == id);

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }
        
        /// <summary>
        /// Deletes the movie
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await Context.Movie.FindAsync(id);

            if (Movie != null)
            {
                Context.Movie.Remove(Movie);
                await Context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
