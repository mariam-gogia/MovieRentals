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
    public class DetailsModel : PageModel
    {
        private readonly HW6MovieSharing.Data.HW6MovieSharingContext _context;

        public DetailsModel(HW6MovieSharing.Data.HW6MovieSharingContext context)
        {
            _context = context;
        }

        public BorrowRequest BorrowRequest { get; set; }

        /// <summary>
        /// Shows details of borrowRequest
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
    }
}
