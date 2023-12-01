using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tasks.Models;
using Tasks.Repositories.Interfaces;

namespace Tasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            List<User> listUser = await _userRepository.GetAllUser();
            return listUser;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int Id)
        {
            User user = await _userRepository.GetUserById(Id);
            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Insert([FromBody] User user)
        {
            User newUser = await _userRepository.Insert(user);
            return user;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Insert([FromBody] User user, int id)
        {
            user.Id = id;
            User userUpdate = await _userRepository.Update(user, id);
            return userUpdate;
        }

        [HttpDelete("{id}")]
        public async Task<Boolean> Delete(int id)
        {
            Boolean delete = await _userRepository.Delete(id);
            return delete;
        }
    }
}
