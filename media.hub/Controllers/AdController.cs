using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using media.hub.Data;
using media.hub.Entities;
using media.hub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace media.hub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdController : ControllerBase
    {
        private readonly MediaContext _context;

        public AdController(MediaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostAd([FromForm]AdModel ad)
        {   
            // mapper model to entity
            var mFiles = ad.Files.Select(GetImageEntity).ToList();

            var adEntity = new Ad()
            {
                Id = Guid.NewGuid(),
                Title = ad.Title,
                Description = ad.Description,
                Tags = string.Join(',', ad.Tags),
                Medias = mFiles

            };
            
            await _context.Ads.AddAsync(adEntity);
            await _context.SaveChangesAsync();
            return Ok();
            
        }


        // image ni IformFile dan Entuity ga parslayapti
        private Media GetImageEntity(IFormFile file)
        {
            var stream = new MemoryStream();

            file.CopyTo(stream);

            return new Media()
            {
                Id = Guid.NewGuid(),
                ContentType = file.ContentType,
                Data = stream.ToArray()

            };
        }

        [HttpGet]

        public async Task<IActionResult> GetAds()
        {
            var ads = await _context.Ads
                .AsNoTracking()
                .Include(ad => ad.Medias)
                .Select(ad => new
                {
                    Id = ad.Id,
                    Title = ad.Title,
                    Description = ad.Description,
                    Tags = ad.Tags.Split(',', StringSplitOptions.RemoveEmptyEntries),
                    Files = ad.Medias.Select(m => new
                        {
                            Id = m.Id,
                            ContentType = m.ContentType,
                            Size = m.SIzeInMb                            
                        })
                }).ToListAsync();

            return Ok(ads);
        }

        private List<(Guid Id, string ContentType, double Size)> GetFiles(Ad ad)
            => ad.Medias.Select(m => (m.Id, m.ContentType, m.SIzeInMb)).ToList();


        [HttpGet]
        [Route("/media/{id}")]
        public async Task<IActionResult> GetMedia(Guid id)
        {
            var file = await _context.Medias.FirstOrDefaultAsync(m => m.Id == id);

            var stream = new MemoryStream(file.Data);

            return File(stream, file.ContentType);
        }
    }   
    
}