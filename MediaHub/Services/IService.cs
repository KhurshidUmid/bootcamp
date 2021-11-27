using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediaHub.Entities;

namespace MediaHub.Services
{
    public interface IService
    {
        Task<List<Ad>> QueryAllAsync();
        Task<Ad> QueryAdAsync(Guid Id);
        Task<Media> QueryMediaAsync(Guid Id);
        Task<(bool IsSuccess, Exception Exception, Ad Ad)> CreateAsync(Ad ad);
        Task<bool> ExistsAdAsync(Guid Id);
        Task<bool> ExistsMediaAsync(Guid Id);
        Task<(bool IsSuccess, Exception Exception, Ad Ad)> UpdateAsync(Ad ad, Guid Id);
        Task<(bool IsSuccess, Exception Exception)> RemoveAdAsync(Guid Id);
        Task<(bool IsSuccess, Exception Exception)> RemoveMediaAsync(Guid Id);
    }
}