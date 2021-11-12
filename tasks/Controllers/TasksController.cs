using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using tasks.Mappers;
using tasks.Models;
using tasks.Services;

namespace tasks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ILogger<TasksController> _logger;
        private readonly IStorageService _storage;

        public TasksController(ILogger<TasksController> logger, IStorageService storage)
        {
            _logger = logger;
            _storage = storage;
        }


        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> CreateTaskAsync([FromBody]NewTask newTask)
        {
            var taskEntity = newTask.ToTaskEntity();
            var insertResult = await _storage.InsertTaskAsync(taskEntity);

            if(insertResult.IsSuccess)
            {
                return CreatedAtAction("CreateTask", taskEntity);
            }

            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = insertResult.exception.Message });
        }

        [HttpGet]
        public async Task<IActionResult> QueryTasks([FromQuery]TaskQuery query)
        {
            var tasks = await _storage.GetTasksAsync(title: query.Title, id: query.Id);

            if(tasks.Any())
            {
                return Ok(tasks);
            }

            return NotFound("No tasks exist!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTaskAsync([FromBody]tasks.Models.Task task)
        {
            var entity = task.ToTaskEntity();
            var updateResult = await _storage.UpdateTaskAsync(entity);

            if(updateResult.isSuccess)
            {
                return Ok();
            }

            return BadRequest(updateResult.exception.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromBody]Models.Task task)
        {
            var entity = task.ToTaskEntity();
            var deleteResult = await _storage.DeleteTask(entity);

            if(deleteResult.isSuccess)
            {
                return Ok();
            }

            return BadRequest(deleteResult.exception.Message);
        }
    }
}