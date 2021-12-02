using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HubMedia.Data;
using HubMedia.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HubMedia.Services
{
    public class AdService : IAdService
    {
        private readonly HubMediaContext _context;
        private readonly ILogger<AdService> _logger;

        public AdService(HubMediaContext context, ILogger<AdService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<(bool IsSuccess, Exception Exception)> CreateAsync(Ad ad)
        {
            try
            {
                await _context.AAds.AddAsync(ad);
                // await _context.MMedias.AddRangeAsync(ad.Medias);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Advertisement is created with ID: {ad.Id}");

                return (true, null);
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Creating failed.");
                return (false, e);
            }
        }

        public async Task<(bool IsSuccess, Exception Exception)> DeleteAsync(Guid id)
        {
            var ad = await GetAsync(id);

            try
            {

                try
                {

                    var medias = ad.Medias;
                        
                        foreach(var media in medias)
                        {
                            _context.MMedias.Remove(media);
                            await _context.SaveChangesAsync();
                        }
                    
            
                    _context.AAds.Remove(await GetAsync(id));
                    await _context.SaveChangesAsync();
                    _logger.LogInformation($"Ad removed from DB: {id}");
            
                }
                catch
                {
                    _context.AAds.Remove(await GetAsync(id));
                    await _context.SaveChangesAsync();
                    _logger.LogInformation($"Ad removed from DB: {id}");
                }
                return (true, null);
            }

            catch(Exception e)
            {
                return (false, e);
            }




            // var bad = await GetAsync(id);
            // // bad.Medias = _context.MMedias.ToList();
            // if (bad == default(Ad))
            // {
            //     return (false, new Exception("Not found."));
            // }
            // try
            // {
            //     _context.AAds.Remove(bad);
            //     await _context.SaveChangesAsync();

            //     _logger.LogInformation($"media with ID: {bad.Id} deleted from DB.");

            //     return (true, null);
            // }
            // catch (Exception e)
            // {
            //     _logger.LogInformation($"Deleting media from DB failed.");
            //     return (false, e);
            // }
        }

        public Task<bool> ExistsAsync(Guid id)
            => _context.AAds.AnyAsync(a => a.Id == id);

        

        public Task<List<Ad>> GetAllAsync()
            => _context.AAds.Include(m => m.Medias).ToListAsync();
          

        public Task<Ad> GetAsync(Guid id)
            => _context.AAds.AsNoTracking().FirstOrDefaultAsync(ad => ad.Id == id);
       
       
        public async Task<Ad> GetAdAsync(Guid id)
        {
            var ad = await GetAsync(id);
            ad.Medias = _context.MMedias.ToList();
            return (ad);
            

        }


       

        public Task<Media> GetMediaAsync(Guid id)
            => _context.MMedias.FirstOrDefaultAsync(m => m.Id == id);




        // public async Task<(bool isSuccess, Exception exception)> UpdateAsync(Entities.Ad ad, Guid id)
        // {
        //     var act =  _context.AAds.FirstOrDefault(p => p.Id == id);
        //     // var act = await GetAdAsync(id);
        //     // act.Medias = _context.MMedias.ToList();
        //     System.Console.WriteLine($"{act.Title}\n\n");
        //     if(act != default(Ad))
        //     {
        //         act.Description = ad.Description ?? act.Description; 
        //         act.Tags = ad.Tags ?? act.Tags; 
        //         act.Title = ad.Title ?? act.Title; 
        //         System.Console.WriteLine($"{act.Title}\n\n");                        
        //     }

        //     if(!_updatedValid(ad))
        //     {
        //         _logger.LogError("Failed to update");
        //         return (false, new Exception($"You should change at least one property."));
        //     }

        //     _context.AAds.Update(act);
        //     await _context.SaveChangesAsync();

        //     return (true, null);
        // }



        public async Task<(bool isSuccess, Exception exception,Ad Ad)> UpdateAsync(Entities.Ad ad)
        {
            try
            {
                if(await _context.AAds.AnyAsync(t => t.Id == ad.Id))
                {
                    _context.AAds.Update(ad);
                    await _context.SaveChangesAsync();

                    return (true, null,ad);
                }
                else
                {
                    return (false, new Exception($"Task with given ID: {ad.Id} doesnt exist!"),null);
                }
            }
            catch(Exception e)
            {
                return (false, e,null);
            }
        }

        // private bool _updatedValid(Ad ad)
        // {
        //     return !(ad.Title == null &&
        //             ad.Description == null &&
        //             ad.Tags == null &&
        //             ad.Id == null);
        //             // ad.Medias == null);
        // }

        
    }
}