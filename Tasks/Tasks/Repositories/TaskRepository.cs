using Microsoft. EntityFrameworkCore;
using System.Threading.Tasks;
using Tasks.Data;
using Tasks.Models;
using Tasks.Repositories.Interfaces;

namespace Tasks.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TasksDBContex _dBContex;
        public TaskRepository(TasksDBContex tasksDBContex)
        {
            _dBContex = tasksDBContex;        
        }

        public async Task<List<Models.Task>> GetAllTasks()
        {
            return await _dBContex.Tasks.Include(x => x.User).ToListAsync();
        }

        public async Task<Models.Task?> GetTaskById(int Id)
        {
            return await _dBContex.Tasks.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == x.Id);
        }

        public async Task<Models.Task> Insert(Models.Task task)
        {
            await _dBContex.Tasks.AddAsync(task);
            await _dBContex.SaveChangesAsync();
            return task;
        }

        public async Task<Models.Task> Update(Models.Task task, int id)
        {
            Models.Task taskModel = await GetTaskById(id);
            if (taskModel == null) { 
                throw new Exception($"Tarefa com o ID: {id} não cadastrado"); 
            }

            taskModel.Name = task.Name;
            taskModel.Description = task.Description;
            taskModel.Status = task.Status;
            task.UserId = task.UserId;

            _dBContex.Tasks.Update(taskModel);
            await _dBContex.SaveChangesAsync();

            return taskModel;
        }

        public async Task<bool> Delete(int id)
        {
            Models.Task taskModel = await GetTaskById(id);
            if (taskModel == null)
            {
                throw new Exception($"Tarefa com o ID: {id} não cadastrado");
            }

            _dBContex.Tasks.Remove(taskModel);
            await _dBContex.SaveChangesAsync();

            return true;
        }
    }
}
