using System.Net;

namespace StudentAdmin_API.Repository
{
    public interface IImageRepository
    {
        Task<string> Upload(IFormFile file, string filename);
        
    }
}
