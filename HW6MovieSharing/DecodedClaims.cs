using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HW6MovieSharing
{
    public static class ClaimsExtensions
    {
        /// <summary>
        /// The first the name.
        /// </summary>
        /// <param name="claimsPrincipal">The claims principal.</param>
        /// <returns>System.String.</returns>
        public static string FirstName(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname")?.Value ?? string.Empty;
        }
        /// <summary>
        /// The last the name.
        /// </summary>
        /// <param name="claimsPrincipal">The claims principal.</param>
        /// <returns>System.String.</returns>
        public static string LastName(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname")?.Value ?? string.Empty;
        }

        /// <summary>
        /// The first and last name
        /// </summary>
        /// <param name="claimsPrincipal">The claims principal</param>
        /// <returns>The first and last name</returns>
        public static string FirstAndLastName(this ClaimsPrincipal claimsPrincipal)
        {
            return $"{claimsPrincipal.FirstName()} {claimsPrincipal.LastName()}";
        }

        /// <summary>
        /// The first and last name and email address
        /// </summary>
        /// <param name="claimsPrincipal">The claims principal</param>
        /// <returns>The first and last name and email address</returns>
        public static string EmailFirstAndLastName(this ClaimsPrincipal claimsPrincipal)
        {
            return $"{claimsPrincipal.FirstAndLastName()} <{claimsPrincipal.EmailAddress()}>";
        }

        /// <summary>
        /// Emails the address.
        /// </summary>
        /// <param name="claimsPrincipal">The claims principal.</param>
        /// <returns>System.String.</returns>
        public static string EmailAddress(this ClaimsPrincipal claimsPrincipal)
        {

            return claimsPrincipal.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value ?? string.Empty;
        }

        /// <summary>
        /// Objects the identifier.
        /// </summary>
        /// <param name="claimsPrincipal">The claims principal.</param>
        /// <returns>System.String.</returns>
        public static string ObjectIdentifier(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier")?.Value ?? string.Empty;
        }

    }

    /// <summary>
    /// Provides access to claims values
    /// </summary>
    public class DecodedClaims
    {
        /// <summary>
        /// The claims principal
        /// </summary>
        private readonly ClaimsPrincipal _claimsPrincipal;

        public DecodedClaims(ClaimsPrincipal claimsPrincipal)
        {
            _claimsPrincipal = claimsPrincipal;
        }

        /// <summary>
        /// Gets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public string FirstName
        {
            get
            {
                return _claimsPrincipal.FirstName();
            }
        }

        /// <summary>
        /// Gets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string LastName
        {
            get
            {
                return _claimsPrincipal.LastName();
            }
        }


        /// <summary>
        /// Gets the email address.
        /// </summary>
        /// <value>The email address.</value>
        public string EmailAddress
        {
            get
            {
                return _claimsPrincipal.EmailAddress();
            }
        }

        /// <summary>
        /// Gets the object identifier.
        /// </summary>
        /// <value>The object identifier.</value>
        public string ObjectIdentifier
        {
            get
            {
                return _claimsPrincipal.ObjectIdentifier();
            }
        }

    }
}
