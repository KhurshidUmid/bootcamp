using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using movies.Data;
using movies.Entities;

namespace movies.Services
{
    public class MovieService : IMovieService
    {
        private readonly MoviesContext _ctx;
        private readonly ILogger<MovieService> _logger;

        public MovieService(MoviesContext context, ILogger<MovieService> logger)
        {
            _ctx = context;
            _logger = logger;
        }
        
        public async Task<(bool IsSuccess, Exception Exception, Movie Movie)> CreateAsync(Movie movie)
        {
            try
            {
                await _ctx.Movies.AddAsync(movie);
                await _ctx.SaveChangesAsync();

                return (true, null, movie);
            }
            catch(Exception e)
            {
                return (false, e, null);
            }
        }

        public async Task<(bool IsSuccess, Exception Exception)> DeleteAsync(Guid id)
        {
            var movie = await GetAsync(id);
            if(movie == default(Movie))
            {
                return (false, new Exception("Not found."));
            }

            try
            {
                _ctx.Movies.Remove(movie);
                await _ctx.SaveChangesAsync();

                return (true, null);
            }
            catch(Exception e)
            {
                return (false, e);
            }
        }

        public Task<bool> ExistsAsync(Guid id)
            => _ctx.Movies.AnyAsync(g => g.Id == id);

        public Task<Movie> GetAsync(Guid id)
            => _ctx.Movies.FirstOrDefaultAsync(g => g.Id == id);

        public Task<List<Movie>> GetAllAsync()
            => _ctx.Movies
                .AsNoTracking()
                .Include(m => m.Actors)
                .Include(m => m.Genres)
                .ToListAsync();

        public Task<List<Movie>> GetAllAsync(string title)
            => _ctx.Movies
                .AsNoTracking()
                .Where(a => a.Title == title)
                .Include(m => m.Actors)
                .Include(m => m.Genres)
                .ToListAsync();


        public async Task<(bool IsSuccess, Exception Exception, Entities.Movie Movie)> UpdateAsync(Entities.Movie movie, Guid id)
        {
            var mov =  _ctx.Movies.FirstOrDefault(p => p.Id == id);
            if(mov != null)
            {
                mov.Title = movie.Title ?? mov.Title;
                mov.Description = movie.Description ?? mov.Description;
                
                
                                       
            }

            if(!_updatedValid(movie))
            {
                return (false, new Exception($"You should change at least one property."), null);
            }

            mov.Rating = movie.Rating;
            mov.ReleaseDate = movie.ReleaseDate;
            

            _ctx.Movies.Update(mov);
            await _ctx.SaveChangesAsync();

            return (true, null, movie);
        }

        private bool _updatedValid(Movie movie)
        {
            return !(movie.Title == null &&
                    movie.Description == null &&
                    movie.ReleaseDate == null);
                    // movie.Rating == null);
        }        
    }

}