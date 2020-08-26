using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HW6MovieSharing.Models
{
    public class BorrowRequest
    {
        public long ID { get; set; }
        /// <summary>
        /// The title of the movie asked to borrow
        /// </summary>

        public string Title { get; set; }
        /// <summary>
        /// The category of the movie asked to borrow
        /// </summary>

        public string Category { get; set; }

        /// <summary>
        /// The first name of the user the movie is shared with
        /// </summary>

        [Display(Name = "Borrower's Name")]
        public string SharedWithFirstName { get; set; }

        /// <summary>
        /// The last name of the user the movie is shared with
        /// </summary>

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
        [Display(Name = "Requested at")]
        [DataType(DataType.Date)]
        public DateTime RequestDate { get; set; }
        /// <summary>
        /// user identifier
        /// </summary>
        public string UserID { get; set; }

        [Display(Name ="Request Status")]
        public string RequestStatus { get; set; }
    }
}
