using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HW6MovieSharing.Data;
using HW6MovieSharing.Models;

namespace HW6MovieSharing.Pages.Requests
{
    public class DeleteModel : PageModel
    {
        private readonly HW6MovieSharing.Data.HW6MovieSharingContext _context;

        public DeleteModel(HW6MovieSharing.Data.HW6MovieSharingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BorrowRequest BorrowRequest { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BorrowRequest = await _context.BorrowRequest.FirstOrDefaultAsync(m => m.ID == id);

            if (BorrowRequest == null)
            {
                return NotFound();
            }
            return Page();
        }
        /// <summary>
        /// Deletes borrow Request
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BorrowRequest = await _context.BorrowRequest.FindAsync(id);

            if (BorrowRequest != null)
            {
                _context.BorrowRequest.Remove(BorrowRequest);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
