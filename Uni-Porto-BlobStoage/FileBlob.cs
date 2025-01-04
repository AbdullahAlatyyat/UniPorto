using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uni_Porto_BlobStoage
{
    public class FileBlob
    {
        [DefaultValue("uniporto")]
        public string ContianerName { get; set; } = "uniporto";
        public string FileGuidId { get; set; }
        public Stream FileStream { get; set; }
        public string ContentType { get; set; }
    }
}
