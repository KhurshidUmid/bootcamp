using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HubMedia.Entities;
using Microsoft.AspNetCore.Http;

namespace HubMedia.Services
{
    public interface IAdService
    {
        Task<bool> ExistsAsync(Guid id);
        // Task<Media> GetImageAsync(IFormFile file);
        Task<Ad> GetAdAsync(Guid id);
        Task<List<Ad>> GetAllAsync();
        Task<Media> GetMediaAsync(Guid id);
        Task<(bool IsSuccess, Exception Exception)> CreateAsync(Ad ad);
        Task<(bool IsSuccess, Exception Exception)> DeleteAsync(Guid id);

        Task<(bool isSuccess, Exception exception,Ad Ad)> UpdateAsync(Ad ad);
        
    }
}