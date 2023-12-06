using Tasks.Models;

namespace Tasks.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<Models.Task>> GetAllTasks();
        Task<Models.Task?> GetTaskById(int Id);
        Task<Models.Task> Insert(Models.Task task);
        Task<Models.Task> Update(Models.Task task, int id);
        Task<bool> Delete(int id);
    }
}
