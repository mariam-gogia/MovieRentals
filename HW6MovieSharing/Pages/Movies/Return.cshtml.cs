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
    public class ReturnModel : BasePageModel
    {
        public ReturnModel(HW6MovieSharing.Data.HW6MovieSharingContext context) : base(context)
        {     
        }

        [BindProperty]
        public Movie Movie { get; set; }
        [BindProperty]
        public BorrowRequest BorrowRequest { get; set; }
        /// <summary>
        /// Gets the movie from the database and checks if it exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            this.Movie = await Context.Movie.FirstOrDefaultAsync(m => m.ID == id);

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }
        /// <summary>
        /// Returns movie
        /// </summary>
        /// <param name="id">Movie ID</param>
        /// <returns></returns>
        public async Task <IActionResult> OnPostAsync(long? id)
        {
            // Retrieve movie by its ID and remove ownership fields
            Movie = await Context.Movie.FirstOrDefaultAsync(m => m.ID == id);
            Movie.IsShareable = true;
            Movie.SharedWithFirstName = "";
            Movie.SharedWithLastName = "";
            Movie.SharedwithEmailAddress = "";
            Movie.UserID = "";
            Movie.Request = "";

            // If the user (other than the owner) is returning the movie, retrieve borrowRequest and change its status to "Expired - Returned" 
            if (AuthenticatedUserInfo.ObjectIdentifier != "c17f0d89-9862-45ca-beca-5b0c5ca2ae7e")
            {
                this.BorrowRequest = await Context.BorrowRequest.FirstOrDefaultAsync(m => m.Title == Movie.Title
                                                               && m.UserID == AuthenticatedUserInfo.ObjectIdentifier &&
                                                               m.RequestStatus != "Expired - Movie Returned");
            }

            // Same function but for the owner
            else
            {
                this.BorrowRequest = await Context.BorrowRequest.FirstOrDefaultAsync(m => m.Title == Movie.Title &&
                                                                    m.RequestStatus != "Expired - Movie Returned");
            }
          
            BorrowRequest.RequestStatus = "Expired - Movie Returned";

            // Update entities in the database
            Context.Attach(BorrowRequest).State = EntityState.Modified;
            Context.Attach(Movie).State = EntityState.Modified;
           
            await Context.SaveChangesAsync();
           
            return RedirectToPage("./Index");
        }
    }
}
