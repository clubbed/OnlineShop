using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace OnlineShop.Application.Interfaces
{
    public interface IUploadImageService
    {
        Task<string> UploadAsync(IFormFile file);
    }
}
