using Microsoft.AspNetCore.Mvc;
using Task_Manager_API.Services;
using Task_Manager_API.Models;

namespace Task_Manager_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly TaskService _taskService;

        public TasksController(TaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskItem>>> GetAll()
        {
            var tasks = await _taskService.GetAllTasksAsync();
            return Ok(tasks);
        }


        public class CreateTaskDto
        {
            public string Title { get; set; }
            public int Seconds { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> AddTask([FromBody] CreateTaskDto request)
        {
            await _taskService.AddTaskAsync(request.Title,request.Seconds);
            return Ok();
        }

        [HttpPut("{id}/complete")]
        public async Task<IActionResult> CompleteTask(int id)
        {
            var success = _taskService.CompleteTaskAsync(id);
            if (!await success) return NotFound();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var success = _taskService.DeleteTaskAsync(id);
            if (!await success) return NotFound();
            return Ok();
        }
    }
}
