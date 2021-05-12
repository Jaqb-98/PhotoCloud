using Microsoft.AspNetCore.Http;
using PhotoCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoCloud.ViewModels
{
    public class GalleryViewModel
    {

        public ICollection<PhotoModel> Photos { get; set; }
    }
}
