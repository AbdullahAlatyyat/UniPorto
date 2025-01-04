using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniPortoWindowsPhone.Helper
{
    /// <summary>
    /// Class AccountHelper.
    /// </summary>
    public class AccountHelper
    {
        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        /// <value>The access token.</value>
        [JsonProperty(PropertyName = "access_token")]
        public string access_token { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        [JsonProperty(PropertyName = "userID")]
        public string userID { get; set; }
    }
}
