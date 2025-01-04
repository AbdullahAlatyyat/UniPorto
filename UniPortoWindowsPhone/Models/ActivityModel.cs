using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniPortoWindowsPhone.Models
{
    /// <summary>
    /// Class ActivityModel.
    /// </summary>
    public class ActivityModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the profile identifier.
        /// </summary>
        /// <value>The profile identifier.</value>
        public int ProfileId { get; set; }
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public string Status { get; set; }
        /// <summary>
        /// Gets or sets the attachments type identifier.
        /// </summary>
        /// <value>The attachments type identifier.</value>
        public int? AttachmentsTypeId { get; set; }
        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>The created by.</value>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        /// <value>The created on.</value>
        public DateTime CreatedOn { get; set; }
        /// <summary>
        /// Gets or sets the attachment URL.
        /// </summary>
        /// <value>The attachment URL.</value>
        public string AttachmentUrl { get; set; }
        /// <summary>
        /// Gets or sets the date of activity.
        /// </summary>
        /// <value>The date of activity.</value>
        public string DateOfActivity { get; set; }
        /// <summary>
        /// Gets or sets all activities.
        /// </summary>
        /// <value>All activities.</value>
        public List<ActivityModel> allActivities { get; set; }
    }
}
