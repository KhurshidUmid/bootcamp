using System;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pizza.Mappers;
using pizza.Models;
using pizza.Services;

namespace pizza.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaController : ControllerBase
    {

		private readonly IStorageService _pizzaStore;
		private readonly ILogger<PizzaController> _logger;

		public PizzaController(ILogger<PizzaController> logger, IStorageService pizzaStore)
        {
            _logger = logger;
            _pizzaStore = pizzaStore;
        }
		
		
        [HttpGet]
        public async Task<ActionResult> QueryTasks([FromQuery]pizzaQuery query)
        {
            var tasks = await _pizzaStore.GetALLAsync(title: query.Title, id: query.Id);

            if(tasks.Any())
            {
                return Ok(tasks);
            }

            return NotFound("No pizza exist!");
        }



		// GET - idsiga qarab pitsa qaytaradi
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetPizzaAsync([FromRoute]Guid id)
        {
            var getResult = await _pizzaStore.GetPizzaAsync(id);

                if(getResult.IsSuccess)
                {
                    return Ok();
                }

                return BadRequest(getResult.exception.Message);

                
            // var pizz = await _pizzaStore.Pizza
            //     .AsNoTracking()
            //     .FirstOrDefaultAsync(p => p.Id == id);

            // if(pizza is default(Pizza))
            // {
            //     return NotFound($"Pizza with ID {id} not found");
            // }

            // return Ok(pizza);
        }


		// POST - yangi pitsa turini yaratadi
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult> CreatePizzaAsync([FromBody]Models.Pizza pizza) 
        {            
            var taskEntity = pizza.ToPizzaEntity();
            var insertResult = await _pizzaStore.CreatePizzaAsync(taskEntity);

            if(insertResult.IsSuccess)
            {
                return CreatedAtAction("CreatePizza", taskEntity);
            }

            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = insertResult.exception.Message });
        
        }


		// PUT - berilgan pitsani o'zgartiradi
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> UpdatePizzaAsync([FromRoute]Guid id, [FromBody]Models.Pizza pizza) 
        {
            var entity = pizza.ToPizzaEntity();
            var updateResult = await _pizzaStore.UpdatePizzaAsync(entity);

            if(updateResult.IsSuccess)
            {
                return Ok();
            }

            return BadRequest(updateResult.exception.Message);



            // var pizz = await _pizzaStore.GetPizzaAsync
            //     .AsNoTracking()
            //     .FirstOrDefaultAsync(u => u.Id == id);

            // if(pizz is default(Pizza))
            // {
            //     return NotFound($"User with ID {id} not found");
            // }

            // if(!_updatePizzaAsyncValid(pizza))
            // {
            //     return BadRequest("You should change at least one property.");
            // }

            // pizz.Firstname = pizza.Firstname ?? pizz.Firstname;
            // pizz.Lastname = pizza.Lastname ?? pizz.Lastname;
            // pizz.Middlename = pizza.Middlename ?? pizz.Middlename;
            // pizz.Email = pizza.Email ?? pizz.Email;
            // pizz.Phone = pizza.Phone ?? pizz.Phone;
            // pizz.Username = pizza.Username ?? pizz.Username;
            // pizz.Password = pizza.Password ?? pizz.Password;

            // pizz.ModifiedAt = DateTimeOffset.UtcNow;

            // _context.Users.Update(pizz);
            // await _context.SaveChangesAsync();

            // return Ok();
        }


		// DELETE - berilgan idga ega pitsani o'chirib yuboradi
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteAsync([FromRoute]Guid id) 
        {
              var deleteResult = await _pizzaStore.DeletePizzaAsync(id);

                if(deleteResult.IsSuccess)
                {
                    return Ok();
                }

                return BadRequest(deleteResult.exception.Message);
        }
    }
}