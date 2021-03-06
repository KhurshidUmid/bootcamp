using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using movies.Entities;

namespace movies.Services
{
    public interface IMovieService
    {
        Task<(bool IsSuccess, Exception Exception, Movie Movie)> CreateAsync(Movie movie);
        Task<List<Movie>> GetAllAsync();
        Task<Movie> GetAsync(Guid id);
        Task<List<Movie>> GetAllAsync(string title);
        Task<(bool IsSuccess, Exception Exception)> DeleteAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);

        // TODO: Update

        Task<(bool IsSuccess, Exception Exception, Entities.Movie Movie)> UpdateAsync(Entities.Movie movie, Guid id);
    }

}