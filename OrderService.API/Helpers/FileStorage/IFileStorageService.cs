using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.API.Helpers.FileStorage
{
    public interface IFileStorageService
    {
        Task<string> SaveFile(IFormFile file, string container);
        Task DeleteFile(string routFile, string container);
        Task<string> UpdateFile(IFormFile file, string routFile, string container);
    }
}
