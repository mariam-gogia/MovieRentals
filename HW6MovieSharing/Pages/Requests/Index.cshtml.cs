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
    public class IndexModel : PageModel
    {
        private readonly HW6MovieSharing.Data.HW6MovieSharingContext _context;

        public IndexModel(HW6MovieSharing.Data.HW6MovieSharingContext context)
        {
            _context = context;
        }

        public IList<BorrowRequest> BorrowRequest { get;set; }

        /// <summary>
        /// Display list of borrow requests
        /// </summary>
        /// <returns></returns>
        public async Task OnGetAsync()
        {
            BorrowRequest = await _context.BorrowRequest.ToListAsync();
        }
    }
}
