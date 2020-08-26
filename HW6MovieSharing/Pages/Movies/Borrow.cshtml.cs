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
    public class BorrowModel : BasePageModel
    {
        public BorrowModel(HW6MovieSharing.Data.HW6MovieSharingContext context) : base(context)
        {
        }
        [BindProperty]
        public Movie Movie { get; set; }
        [BindProperty]
        public BorrowRequest BorrowRequest { get; set; }

        /// <summary>
        /// Retrievs and looks for a movie by its id
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

            if (this.Movie == null)
            {
                return NotFound();
            }
            return Page();
        }
        /// <summary>
        /// Submits borrow request to borrowRequsts table in database
        /// </summary>
        /// <param name="id"> Movie id </param>
        /// <returns> Task </returns>
        public async Task<IActionResult> OnPostAsync(long? id)
        {
            // Retrieve the movie user wants to borrow
            var borrowedMovie = await Context.Movie.FirstOrDefaultAsync(m => m.ID == id);

            // Check in borrowRequests table if such request already exists and that is active
            var checkDuplicates = await Context.BorrowRequest.FirstOrDefaultAsync(m => m.Title == borrowedMovie.Title
                                                             && m.UserID == AuthenticatedUserInfo.ObjectIdentifier &&
                                                             m.RequestStatus != "Expired - Movie Returned");

            // If active request exists tell the user that their previous request is pending approva
            if (checkDuplicates != null && checkDuplicates.RequestStatus != "Declined") 
            {
                return RedirectToPage("./WarningPage");
            }

            // Assamble borrow request 
            BorrowRequest = new BorrowRequest
            {
                Title = borrowedMovie.Title,
                Category = borrowedMovie.Category,
                RequestDate = DateTime.UtcNow,
                SharedWithFirstName = AuthenticatedUserInfo.FirstName,
                SharedWithLastName = AuthenticatedUserInfo.LastName,
                UserID = AuthenticatedUserInfo.ObjectIdentifier,
                SharedwithEmailAddress = AuthenticatedUserInfo.EmailAddress,
                RequestStatus = "Review Pending"
            };
           
            // Add request to Borrow Request Table
            Context.BorrowRequest.Add(BorrowRequest);
            await Context.SaveChangesAsync();
           
            return RedirectToPage("./Index");
        }
    }
}
