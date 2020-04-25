using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using OnlineShop.Application.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;

namespace OnlineShop.Web.Services
{
    public class UploadImageService : IUploadImageService
    {
        private readonly IHostingEnvironment _env;

        public UploadImageService(IHostingEnvironment env)
        {
            _env = env;
        }
        public async Task<string> UploadAsync(IFormFile file)
        {
            if(file.Length > 0)
            {
                try
                {
                    var path = _env.ContentRootPath + "\\ClientApp\\src\\images\\";

                    if(!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    var imageName = file.FileName;
                    var imagePath = $"{path}{imageName}";

                    using (FileStream stream = File.Create(imagePath))
                    {
                        await file.CopyToAsync(stream);
                        await stream.FlushAsync();

                        return imagePath;
                    }
                }
                catch (Exception ex)
                {
                    //return ex.Message;
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
