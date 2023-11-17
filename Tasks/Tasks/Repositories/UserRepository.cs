using Microsoft.EntityFrameworkCore;
using Tasks.Data;
using Tasks.Models;
using Tasks.Repositories.Interfaces;

namespace Tasks.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TasksDBContex _dBContex;
        public UserRepository(TasksDBContex tasksDBContex)
        {
            _dBContex = tasksDBContex;        
        }
        public async Task<List<User>> GetAllUser()
        {
            return await _dBContex.Users.ToListAsync();
        }

        public async Task<User?> GetUserById(int Id)
        {
            return await _dBContex.Users.FirstOrDefaultAsync(x => x.Id == Id);          
        }

        public Task<User> Insert(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(User user, int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
