using GraduationProject.UniPortoWebsite.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniPortoWebsite.EF;
using UniPortoWebsite.Repository.Context;

namespace UniPortoWebsite.Repository
{
    /// <summary>
    /// Class AttachmentRepository.
    /// </summary>
    public class AttachmentRepository
    {
        /// <summary>
        /// Adds the attachment.
        /// </summary>
        /// <param name="newAttachment">The new attachment.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE ADDING NEW ACTIVITY ATTACHMENT
        /// or
        /// UNEXPECTED EXCEPTION WHILE ADDING NEW ACTIVITY ATTACHMENT
        /// </exception>
        public bool AddAttachment(ActivityAttachment newAttachment)
        {
           
            try
            {
                var model = new UniPorto();
                model.ActivityAttachments.Add(newAttachment);
                model.SaveChanges();
                return true;


            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE ADDING NEW ACTIVITY ATTACHMENT ", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE ADDING NEW ACTIVITY ATTACHMENT", ex);
            }
        }
    }
}