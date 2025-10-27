using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.API.Helpers.FileStorage
{
    public class AppLocalStorageService : IFileStorageService
    {
        private readonly IWebHostEnvironment env;
        private readonly IHttpContextAccessor httpContextAccessor;

        public AppLocalStorageService(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            env = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
        }

        public Task DeleteFile(string routFile, string container)
        {
            if (string.IsNullOrEmpty(routFile))
            {
                return Task.CompletedTask;
            }
            var fileName = Path.GetFileName(routFile);


            var fileDirectory = Path.Combine(env.WebRootPath, container, fileName).Replace("\\", "/"); ;
            File.Delete(fileDirectory);
            return Task.CompletedTask;


        }

        public async Task<string> SaveFile(IFormFile file, string container)
        {
            var extension = Path.GetExtension(file.FileName);
            var fileName = $"{Guid.NewGuid()}{extension}";
            var folder = Path.Combine(env.WebRootPath, container);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            var route = Path.Combine(folder, fileName);
            using (var ms = new MemoryStream())
            {
                await file.CopyToAsync(ms);
                var content = ms.ToArray();
                await File.WriteAllBytesAsync(route, content);
            }
            var url = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}";
            var routeForDb = Path.Combine(url, container, fileName).Replace("\\", "/");
            return routeForDb;
        }

        public async Task<string> UpdateFile(IFormFile file, string routFile, string container)
        {
            await DeleteFile(routFile, container);
            var routeForDb = await SaveFile(file, container);
            return routeForDb;
        }
    }
}
