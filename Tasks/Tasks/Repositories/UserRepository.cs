using Microsoft. EntityFrameworkCore;
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

        public async Task<User> Insert(User user)
        {
            await _dBContex.Users.AddAsync (user);
            await _dBContex.SaveChangesAsync();
            return user;
        }

        public async Task<User> Update(User user, int id)
        {
            User userModel = await GetUserById(id); 
            if (userModel == null) { throw new Exception($"Úsuario com o ID: {id} não cadastrado"); }
            
            userModel.Name = user.Name;
            userModel.Email = user.Email;

            _dBContex?.Update(userModel);
            await _dBContex.SaveChangesAsync();

            return userModel;
        }
      
        public async Task<bool> Delete(int id)
        {
            User userModel = await GetUserById(id);
            if (userModel == null) { throw new Exception($"Úsuario com o ID: {id} não cadastrado"); }

            _dBContex.Users.Remove(userModel);
            await _dBContex.SaveChangesAsync();

            return true;
        }
    }
}
