using System.Xml.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaHub.Data;
using MediaHub.Entities;
using Microsoft.EntityFrameworkCore;

namespace MediaHub.Services
{
    public class Service : IService
    {
        private readonly MediaContext _context;

        public Service(MediaContext context)
        {
            _context = context;
        }

        public async Task<(bool IsSuccess, Exception Exception, Ad Ad)> CreateAsync(Ad ad)
        {
            if(await ExistsAdAsync(ad.Id))
            {
                return (false, new ArgumentException($"There is no Ads with given ID: {ad.Id}"), null);
            }

            try
            {
                await _context.Addss.AddAsync(ad);
                await _context.SaveChangesAsync();

                return (true, null, ad);
            }
            catch(Exception e)
            {
                return (false, e, null);
            }
        }



        public Task<bool> ExistsAdAsync(Guid Id)
            => _context.Addss
                .AnyAsync(p => p.Id == Id);

        public Task<bool> ExistsMediaAsync(Guid Id)
            => _context.Mediass
                .AnyAsync(p => p.Id == Id);

        


        public Task<Media> QueryMediaAsync(Guid Id)
            => _context.Mediass.FirstOrDefaultAsync(p => p.Id == Id);



        public Task<Ad> QueryAdAsync(Guid Id)
            => _context.Addss.FirstOrDefaultAsync(p => p.Id == Id);
        




        public  Task<List<Ad>> QueryAllAsync()
            =>  _context.Addss.AsNoTracking()
                .Include(ad => ad.Medias).ToListAsync();




         
        

        public async Task<(bool IsSuccess, Exception Exception)> RemoveAdAsync(Guid Id)
        {


            // var ads = _context.Mediass.AsNoTracking().Where(ad => ad.Medias);

            // if(ads != null)
            // {
            //     _context.Addss.Remove(ads);                
            //     await _context.SaveChangesAsync();
            // }
            
            if(!await ExistsAdAsync(Id))
            {
                return (false, new ArgumentException($"There is no Media with given ID: {Id}"));
            }
            var result = await QueryAdAsync(Id);
            _context.Addss.Remove(result);
            await _context.SaveChangesAsync();

            return (true, null);
        }


        public async Task<(bool IsSuccess, Exception Exception)> RemoveMediaAsync(Guid Id)
        {
            if(!await ExistsMediaAsync(Id))
            {
                return (false, new ArgumentException($"There is no Media with given ID: {Id}"));
            }
            var result = await QueryMediaAsync(Id);
            _context.Mediass.Remove(result);
            await _context.SaveChangesAsync();

            return (true, null);
        }

        

        public Task<(bool IsSuccess, Exception Exception, Ad Ad)> UpdateAsync(Ad ad, Guid Id)
        {
            throw new NotImplementedException();
        }

        
    }
}