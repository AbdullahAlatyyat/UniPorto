using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniPortoWindowsPhone.Models;

namespace UniPortoWindowsPhone.Helper
{
    /// <summary>
    /// Class UniPortoMobileContext.
    /// </summary>
    public static class UniPortoMobileContext
    {
        /// <summary>
        /// Gets or sets the logged in user.
        /// </summary>
        /// <value>The logged in user.</value>
        public static string LoggedInUser
        {
            get;
            set;

        }
        /// <summary>
        /// Gets or sets the security identifier.
        /// </summary>
        /// <value>The security identifier.</value>
        public static string SecurityID
        {
            get;
            set;

        }
        /// <summary>
        /// Gets or sets the profile.
        /// </summary>
        /// <value>The profile.</value>
        public static ProfileModel profile { get; set; }
    }
}

