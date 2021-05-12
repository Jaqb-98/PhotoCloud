using Microsoft.EntityFrameworkCore;
using PhotoCloud.Data;
using PhotoCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoCloud.Services
{
    public class PhotoService : IPhotoService
    {

        private ApplicationDbContext _context;

        public PhotoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddPhotos(string userId, List<PhotoModel> photos)
        {
            var user = _context.Users.Where(x => x.Id == userId).Include(x => x.Photos).FirstOrDefault();
            foreach (var photo in photos)
            {
                user.Photos.Add(photo);
            }

            _context.SaveChanges();

        }


        public async Task<ICollection<PhotoModel>> GetUsersPhotos(string userId, int page = 0)
        {
            var user = await _context.Users.Where(x => x.Id == userId).Include(x => x.Photos).FirstOrDefaultAsync();

            var photos = user.Photos
                .OrderByDescending(x => x.UploadDate)
                .Skip(20 * page)
                .Take(20)
                .ToList();

            return photos;
        }
    }
}
