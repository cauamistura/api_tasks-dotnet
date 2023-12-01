using Tasks.Models;

namespace Tasks.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUser();
        Task<User?> GetUserById(int Id);
        Task<User> Insert(User user);
        Task<User> Update(User user, int id);
        Task<bool> Delete(int id);
    }
}
