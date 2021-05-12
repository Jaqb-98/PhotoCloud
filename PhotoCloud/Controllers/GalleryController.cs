using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using PhotoCloud.Services;
using PhotoCloud.ViewModels;
using PhotoCloud.Models;

namespace PhotoCloud.Controllers
{
    public class GalleryController : Controller
    {

        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IPhotoService _photoService;

        public GalleryController(IWebHostEnvironment hostEnvironment, IPhotoService photoService)
        {
            webHostEnvironment = hostEnvironment;
            _photoService = photoService;
        }
        public async Task<IActionResult> Index()
        {
            var claims = User.Claims.ToList();
            var userId = claims[0].Value;
            var photos = await _photoService.GetUsersPhotos(userId);

            var vm = new GalleryViewModel
            {
                Photos = photos
            };

            return View(vm);
        }

        [HttpPost]
        public ActionResult UploadFiles(IEnumerable<IFormFile> photos)
        {
            var names = UploadFilesToServer(photos);
            var claims = User.Claims.ToList();
            var userId = claims[0].Value;

            var photoModels = new List<PhotoModel>();

            foreach (var name in names)
            {
                photoModels.Add(new PhotoModel
                {
                    Id = Guid.NewGuid().ToString(),
                    PhotoName = name,
                    UploadDate =  DateTime.Now
                }) ;
            }
            _photoService.AddPhotos(userId, photoModels);
            return RedirectToAction("Index");
        }

        private ICollection<string> UploadFilesToServer(IEnumerable<IFormFile> photos)
        {
            string uniqueFileName = null;
            List<string> photosNames = new List<string>();
            if (photos != null)
            {
                foreach (var photo in photos)
                {

                    string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "photos");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        photo.CopyTo(fileStream);
                    }

                    photosNames.Add(uniqueFileName);
                }
            }
            return photosNames;
        }



    }
}
