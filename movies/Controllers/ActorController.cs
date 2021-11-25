using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using movies.Mappers;
using movies.Models;
using movies.Services;

namespace movies.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ActorController : ControllerBase
    {
        private readonly IActorService _as;

        public ActorController(IActorService actorService)
        {
            _as = actorService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(NewActor actor)
        {
            var result = await _as.CreateAsync(actor.ToEntity());

            if(result.IsSuccess)
            {
                return Ok();
            }

            return BadRequest(result.Exception.Message);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            if(await _as.ExistsAsync(id))
            {
                return Ok(await _as.GetAsync(id));
            }

            return NotFound();
        }


        [HttpGet]
        public async Task<IActionResult> GetAsync()
            => Ok(await _as.GetAllAsync());



        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> UpdatePizzaAsync([FromRoute]Guid id, [FromBody]NewActor actor) 
        {
            var entity = actor.ToEntity();
            var updateResult = await _as.UpdateAsync(entity, id);

            
            return Ok(updateResult.Actor);
        }



        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteAsync([FromRoute]Guid id) 
        {
              var deleteResult = await _as.DeleteAsync(id);

                if(deleteResult.IsSuccess)
                {
                    return Ok();
                }

                return BadRequest(deleteResult.Exception.Message);
        }



    }
}
