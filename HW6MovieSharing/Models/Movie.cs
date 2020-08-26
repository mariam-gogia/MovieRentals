using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HW6MovieSharing.Models
{
    public class Movie
    {
        /// <summary>
        /// Automatically assigned ID by the database
        /// </summary>
        public long ID { get; set; }
        /// <summary>
        /// The title of the movie
        /// </summary>
        [Required]
        [MaxLength(1024)]
        public string Title { get; set; }
        /// <summary>
        /// The category of the movie
        /// </summary>
        [Required]
        [MaxLength(256)]
        public string Category { get; set; }

        /// <summary>
        /// The first name of the user the movie is shared with
        /// </summary>
        [MaxLength(256)]
        [Display(Name = "Borrower's Name")]
        public string SharedWithFirstName { get; set; }

        /// <summary>
        /// The last name of the user the movie is shared with
        /// </summary>
        [MaxLength(256)]
        [Display(Name = "Borrower's Last Name")]
        public string SharedWithLastName { get; set; }
        /// <summary>
        /// The email address of the user the movie is shared with
        /// </summary>
        [Display(Name = "Borrower's Email Address")]
        [MaxLength(256)]
        public string SharedwithEmailAddress { get; set; }

        /// <summary>
        /// The UTC date and time movie was shared
        /// </summary>
        [Display(Name ="Movie Borrowed At")]
        [DataType(DataType.Date)]
        public DateTime SharedDate { get; set; }
        /// <summary>
        /// user identifier
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// Property to indicate whether the movie is borrowed or not
        /// </summary>

        [Display(Name = "Is Sharable")]
        public bool IsShareable { get; set; }

        [Display(Name = "Status")]
        public string Request { get; set; }
    }
}
