using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HW6MovieSharing.Data;
using HW6MovieSharing.Models;
using HW6MovieSharing.Pages.Shared;

namespace HW6MovieSharing.Pages.Requests
{
    public class EditModel : BasePageModel
    {
        public EditModel(HW6MovieSharing.Data.HW6MovieSharingContext context) : base(context)
        {
        }

        [BindProperty]
        public BorrowRequest BorrowRequest { get; set; }
        
        
        [BindProperty]
        public Movie Movie { get; set; }

        /// <summary>
        /// Retrieve request by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BorrowRequest = await Context.BorrowRequest.FirstOrDefaultAsync(m => m.ID == id);

            if (BorrowRequest == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
      
        /// <summary>
        /// Updates the borrowRequest Status
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync()
        {
            // Retrieve a movie
            this.Movie = await Context.Movie.FirstOrDefaultAsync(m => m.Title == this.BorrowRequest.Title &&
                                                                        m.Category == this.BorrowRequest.Category);
       
            // If it is already rented out pop the warning
            if(this.Movie.IsShareable == false)
            {
                return RedirectToPage("./ApprovalError");
            }

            // If the request is approved, update the correspnding movie details
            if(this.BorrowRequest.RequestStatus == "Approved")
            {
                this.Movie.IsShareable = false;
                this.Movie.SharedDate = DateTime.UtcNow;
                this.Movie.SharedWithFirstName = this.BorrowRequest.SharedWithFirstName;
                this.Movie.SharedWithLastName = this.BorrowRequest.SharedWithLastName;
                this.Movie.SharedwithEmailAddress = this.BorrowRequest.SharedwithEmailAddress;
                this.Movie.Request = "Approved";
                this.Movie.UserID = this.BorrowRequest.UserID;
            }

            // Save modified entities in database
            Context.Attach(this.BorrowRequest).State = EntityState.Modified;
            Context.Attach(this.Movie).State = EntityState.Modified;

            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BorrowRequestExists(BorrowRequest.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BorrowRequestExists(long id)
        {
            return Context.BorrowRequest.Any(e => e.ID == id);
        }
    }
}
