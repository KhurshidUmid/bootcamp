using System;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using MediaHub.Data;
using MediaHub.Entities;
using MediaHub.Mappers;
using MediaHub.Models;
using MediaHub.Services;
using Microsoft.AspNetCore.Mvc;

namespace MediaHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdController : ControllerBase
    {
        private readonly IService _context;

        public AdController(IService context)
        {
            _context = context;
        }

        [HttpPost]
        
        public async Task<IActionResult> PostAd([FromForm]AdModel ad)
        {                           
            // return CreatedAtAction(nameof(PostAd), await _context.CreateAsync(ad.ToEntit()));
            var sad = ad.ToEntit();
            var result = await _context.CreateAsync(sad);   
            if(result.IsSuccess)
            {
                return Ok();
            }
            return BadRequest(result.Exception.Message);
        }


        [HttpGet]
        public async Task<IActionResult> GetAds()
        {
            var ads = await _context.QueryAllAsync();
                
               

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
                            Size = m.SIzeInMb                            
                        })
                };
            }));
        }

        
        [HttpGet]
        [Route("/media/{id}")]
        public async Task<IActionResult> GetMedia(Guid id)
        {
            var file = await _context.QueryMediaAsync(id);

            var stream = new MemoryStream(file.Data);

            return File(stream, file.ContentType);
        }




        // [HttpPut]
        // [Route("{id}")]
        // public async Task<ActionResult> UpdateAsync([FromRoute]Guid id, [FromBody]Ad ad) 
        // {
        //     var entity = ad.ToEntit();
        //     var updateResult = await _context.UpdateAsync(entity, id);

            
        //     return Ok(updateResult.Ad);
        // }

        
		
        [HttpDelete]
        [Route("/media/{Id}")]
        public async Task<ActionResult> DeleteMediaAsync([FromRoute]Guid Id) 
        {
            var deleteResult = await _context.RemoveMediaAsync(Id);

            if(deleteResult.IsSuccess)
            {
                return Ok();
            }

            return BadRequest(deleteResult.Exception.Message);
        }


        [HttpDelete]
        [Route("/ad/{Id}")]
        public async Task<ActionResult> DeleteAdAsync([FromRoute]Guid Id) 
        {
            
            var deleteResult = await _context.RemoveAdAsync(Id);

            if(deleteResult.IsSuccess)
            {
                return Ok();
            }

            return BadRequest(deleteResult.Exception.Message);
        }

        
    }   
    
}