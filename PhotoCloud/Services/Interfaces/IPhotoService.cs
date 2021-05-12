using PhotoCloud.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotoCloud.Services
{
    public interface IPhotoService
    {
        void AddPhotos(string userId, List<PhotoModel> photos);
        Task<ICollection<PhotoModel>> GetUsersPhotos(string userId, int page = 0);
    }
}