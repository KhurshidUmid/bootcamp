using System;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pizza.Entities;
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
        public async Task<ActionResult> QueryTasks()
        {
            var tasks = await _pizzaStore.QueryPizzasAsync();

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
            var getResult = await _pizzaStore.QueryPizzaAsync(id);

                if(getResult is default(Pizza))
                {
                    return NotFound($"Pizza with ID {id} not found");
                }

                return Ok(getResult);            
        
        }


		// POST - yangi pitsa turini yaratadi
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult> PostPizza([FromBody]Models.UpdatePizza pizza) 
        {            
            // var taskEntity = pizza.ToPizzaEntity();
            // var insertResult = await _pizzaStore.CreatePizzaAsync(taskEntity);

            // if(insertResult.IsSuccess)
            // {
            //     return CreatedAtAction("CreatePizza", taskEntity);
            // }

            // return StatusCode((int)HttpStatusCode.InternalServerError, new { message = insertResult.Exception.Message });

            return CreatedAtAction(nameof(PostPizza), await _pizzaStore.CreatePizzaAsync(pizza.ToPizzaEntity()));
        }


		// PUT - berilgan pitsani o'zgartiradi
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdatePizzaAsync([FromRoute]Guid id, [FromBody]UpdatePizza pizza) 
        {
            var entity = pizza.ToPizzaEntity();
            var updateResult = await _pizzaStore.UpdatePizzaAsync(entity, id);

            if(!_updatePizzaValid(pizza))
            {
                return BadRequest("you shoud");
            }
            return Ok(updateResult.Pizza);
        }

        private bool _updatePizzaValid(UpdatePizza updatedPizza)
        {
            return !(updatedPizza.Title == null &&
                     updatedPizza.Ingradients == null &&
                     updatedPizza.ShortName == null);
                    //  updatedPizza.StockStatus == null);
        }
            
        


		// DELETE - berilgan idga ega pitsani o'chirib yuboradi
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteAsync([FromRoute]Guid id) 
        {
              var deleteResult = await _pizzaStore.RemovePizzaAsync(id);

                if(deleteResult.IsSuccess)
                {
                    return Ok();
                }

                return BadRequest(deleteResult.Exception.Message);
        }
    }
}