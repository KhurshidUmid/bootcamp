using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HubMedia.Entities;
using HubMedia.Mappers;
using HubMedia.Models;
using HubMedia.Services;
using Microsoft.AspNetCore.Mvc;

namespace HubMedia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdController : ControllerBase
    {
        private readonly IAdService _adService;
        public AdController(IAdService adService)
        {
            _adService = adService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromForm] AdModel ad)
        {
            var adEntity = ad.ToEntity();
            var result = await _adService.CreateAsync(adEntity);
            if (result.IsSuccess)
                return Ok();
            return BadRequest();
        }


        [HttpGet]
        [Route("/media/{id}")]
        public async Task<IActionResult> GetMedia(Guid id)
        {
            var file = await _adService.GetMediaAsync(id);

            var stream = new MemoryStream(file.Data);

            return File(stream, file.ContentType);
        }


        [HttpGet]
        [Route("/Ad/{id}")]
        public async Task<IActionResult> GetAddAsync(Guid id)
        {
            var ad = await _adService.GetAdAsync(id);
            
            return Ok(ad);
        }

        [HttpGet]
        public async Task<IActionResult> GetAds()
        {
            var ads = await _adService.GetAllAsync();
            
            return Ok(ads.Select(ad => 
            {
                return new
                {
                    Id = ad.Id,
                    Title = ad.Title,
                    Description = ad.Description,
                    Tags = ad.Tags.Split(',', StringSplitOptions.RemoveEmptyEntries),
                    Files = ad.Medias.Select(m => new
                        {
                            Id = m.Id,
                            ContentType = m.ContentType,
                            Size = m.SizeInMb                            
                        })
                };
            }));
        }

        [HttpPut]
        [Route("{id}")]
        [Consumes("application/json")]
        public async Task<IActionResult> PutAsync([FromRoute]Guid id, UpdateAd updatedAd) 
        {
           
            var entity = updatedAd.ToEntity();
            
            var updateResult = await _adService.UpdateAsync(entity);

            if(updateResult.isSuccess)
                return Ok(updateResult.Ad);
            return BadRequest(updateResult.exception.Message);
        }

        
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid Id)
        {
            var result = await _adService.DeleteAsync(Id);
            if (result.IsSuccess)
                return Ok();
            return BadRequest();
        }
       


    }
}
