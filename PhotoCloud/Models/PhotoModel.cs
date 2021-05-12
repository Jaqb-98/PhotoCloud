using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoCloud.Models
{
    public class PhotoModel
    {
        public string Id { get; set; }
        public string PhotoName { get; set; }
        public DateTime UploadDate { get; set; }
    }
}
