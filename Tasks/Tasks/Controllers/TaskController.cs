using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tasks.Models;
using Tasks.Repositories.Interfaces;

namespace Tasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Models.Task>>> GetAllTasks()
        {
            List<Models.Task> listTask = await _taskRepository.GetAllTasks();
            return listTask;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Task>> GetTaskById(int Id)
        {
            Models.Task task = await _taskRepository.GetTaskById(Id);
            return task;
        }

        [HttpPost]
        public async Task<ActionResult<Models.Task>> Insert([FromBody] Models.Task task)
        {
            Models.Task newTask = await _taskRepository.Insert(task);
            return newTask;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Models.Task>> Insert([FromBody] Models.Task task, int id)
        {
            task.Id = id;
            Models.Task taskUpdate = await _taskRepository.Update(task, id);
            return taskUpdate;
        }

        [HttpDelete("{id}")]
        public async Task<Boolean> Delete(int id)
        {
            Boolean delete = await _taskRepository.Delete(id);
            return delete;
        }
    }
}
