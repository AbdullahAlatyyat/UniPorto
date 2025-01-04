using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Uni_Porto_BlobStoage;

namespace UniPortoWebsite.Helpers
{
    public static class BlobHelper
    {
        public static string UplodeContent(HttpPostedFileBase AttachmentFile)
        {
            string AttachmentUrl = string.Empty;
            try
            {
                BlobManager manger = new BlobManager();
                HttpPostedFileBase fileContent = AttachmentFile;
                Stream attachmentStream = fileContent.InputStream;
                FileBlob attachment = new FileBlob
                {
                    FileGuidId = Guid.NewGuid().ToString(),
                    FileStream = attachmentStream,
                    ContentType = fileContent.ContentType
                };
                AttachmentUrl = manger.UploadBlob(attachment);
                return AttachmentUrl;
            }
            catch (Exception ex)
            {
                return AttachmentUrl;
            }
        }
        public static string UplodeContent(HttpPostedFileBase AttachmentFile, string FileName)
        {
            string AttachmentUrl = string.Empty;
            try
            {
                BlobManager manger = new BlobManager();
                HttpPostedFileBase fileContent = AttachmentFile;
                Stream attachmentStream = fileContent.InputStream;
                FileBlob attachment = new FileBlob
                {
                    FileGuidId = FileName,
                    FileStream = attachmentStream,
                    ContentType = fileContent.ContentType
                };
                AttachmentUrl = manger.UploadBlob(attachment);
                return AttachmentUrl;
            }
            catch (Exception ex)
            {
                return AttachmentUrl;
            }
        }
    }
}