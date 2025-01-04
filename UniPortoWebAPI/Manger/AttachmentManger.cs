using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniPortoWebAPI.EF;
using UniPortoWebAPI.Repository;

namespace UniPortoWebAPI.Manager
{
    public static class AttachmentManger
    {
        static AttachmentRepository repository = new AttachmentRepository();
        public static bool AddAttachment(ActivityAttachment newAttachment)
        {
            var res = repository.AddAttachment(newAttachment);
            return res;
        }
    }
}