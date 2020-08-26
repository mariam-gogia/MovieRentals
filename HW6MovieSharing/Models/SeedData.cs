using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HW6MovieSharing.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HW6MovieSharing.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {

            using (var context = new HW6MovieSharingContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<HW6MovieSharingContext>>()))
            {
                // Check if there is any data
                if (context.Movie.Any())
                {
                    return; // DB has been seeded
                }

                // Create data
                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "Star Wars IV",
                        Category = "Science Fiction",
                        IsShareable = true

                    },
                    new Movie
                    {
                        Title = "The Matrix",
                        Category = "Science Fiction",
                        IsShareable = true
                    },
                    new Movie
                    {
                        Title = "The Social Network",
                        Category = "Drama",
                        IsShareable = true
                    },
                    new Movie
                    {
                        Title = "Star Trek First Contact",
                        Category = "Science Fiction",
                        IsShareable = true
                    },
                    new Movie
                    {
                        Title = "Captain Marvel",
                        Category = "Adventure",
                        IsShareable = false,
                    }); ;
                context.SaveChanges();
            }
        }
    }
}
