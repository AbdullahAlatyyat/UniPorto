using GraduationProject.UniPortoWebAPI.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniPortoWebAPI.EF;


namespace UniPortoWebAPI.Repository
{
    public class AttachmentRepository
    {
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