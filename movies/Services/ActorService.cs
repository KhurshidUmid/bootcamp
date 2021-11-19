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
    public class ActorService : IActorService
    {
        private readonly MoviesContext _ctx;
        private readonly ILogger<GenreService> _logger;

        public ActorService(MoviesContext context, ILogger<GenreService> logger)
        {
            _ctx = context;
            _logger = logger;
        }
        
        public async Task<(bool IsSuccess, Exception Exception, Actor Actor)> CreateAsync(Actor actor)
        {
            try
            {
                await _ctx.Actors.AddAsync(actor);
                await _ctx.SaveChangesAsync();

                return (true, null, actor);
            }
            catch(Exception e)
            {
                return (false, e, null);
            }
        }

        public async Task<(bool IsSuccess, Exception Exception)> DeleteAsync(Guid id)
        {
            try
            {
                var actor = await GetAsync(id);

                if(actor == default(Actor))
                {
                    return (false, new Exception("Not found"));
                }

                _ctx.Actors.Remove(actor);
                await _ctx.SaveChangesAsync();

                return (true,  null);
            }
            catch(Exception e)
            {
                return (false, e);
            }
        }

        public Task<bool> ExistsAsync(Guid id)
            => _ctx.Actors.AnyAsync(a => a.Id == id);

        public Task<List<Actor>> GetAllAsync()
            => _ctx.Actors.ToListAsync();

        public Task<List<Actor>> GetAllAsync(string fullname)
            => _ctx.Actors
                .AsNoTracking()
                .Where(a => a.Fullname == fullname)
                .ToListAsync();

        public Task<Actor> GetAsync(Guid id)
            => _ctx.Actors.FirstOrDefaultAsync(a => a.Id == id);



        public async Task<(bool IsSuccess, Exception Exception, Entities.Actor Actor)> UpdateAsync(Entities.Actor actor, Guid id)
        {
            var act =  _ctx.Actors.FirstOrDefault(p => p.Id == id);
            if(act != null)
            {
                act.Fullname = actor.Fullname ?? act.Fullname;
                                       
            }

            if(!_updatedValid(actor))
            {
                return (false, new Exception($"You should change at least one property."), null);
            }

            act.Birthdate = DateTimeOffset.UtcNow;
            act.Movies = actor.Movies;
            

            _ctx.Actors.Update(act);
            await _ctx.SaveChangesAsync();

            return (true, null, actor);
        }

        private bool _updatedValid(Actor actor)
        {
            return !(actor.Fullname == null &&
                    actor.Birthdate == null &&
                    actor.Movies == null);
        }

          
    }

}