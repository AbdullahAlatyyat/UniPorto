using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniPortoWebsite.EF;
using UniPortoWebsite.Repository;

namespace UniPortoWebsite.Manager
{
    /// <summary>
    /// Class AttachmentManger.
    /// </summary>
    public static class AttachmentManger
    {
        /// <summary>
        /// The repository
        /// </summary>
        static AttachmentRepository repository = new AttachmentRepository();
        /// <summary>
        /// Adds the attachment.
        /// </summary>
        /// <param name="newAttachment">The new attachment.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool AddAttachment(ActivityAttachment newAttachment)
        {
            var res = repository.AddAttachment(newAttachment);
            return res;
        }
    }
}