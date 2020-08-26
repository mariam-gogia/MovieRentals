using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HW6MovieSharing.Models;

namespace HW6MovieSharing.Data
{
    public class HW6MovieSharingContext : DbContext
    {
        public HW6MovieSharingContext (DbContextOptions<HW6MovieSharingContext> options)
            : base(options)
        {
            // Ensuring database creation
            Database.EnsureCreated();
        }

        // Table for Movies
        public DbSet<HW6MovieSharing.Models.Movie> Movie { get; set; }

        //Table for borrow Request
        public DbSet<HW6MovieSharing.Models.BorrowRequest> BorrowRequest { get; set; }
    }
}
