using Microsoft.AspNetCore.Mvc;
using WebApplication1.Abstractions;
using WebApplication1.Domain.Entity;

namespace WebApplication1.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IRepository<User> _userRepository;

        public UserController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            var users = await _userRepository.GetAllAsync();
            return users;
        }

        [HttpGet("{id}")]
        public async Task<User?> Get(Guid id)
        {
            var user = await _userRepository.GetAsync(id);
            return user;
        }

        [HttpPost]
        public async Task<User> Post([FromBody] User entity)
        {
            entity.Id = new Guid();
            await _userRepository.AddAsync(entity);
            return entity;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] User entity)
        {
            var user = await _userRepository.GetAsync(id);
            if (user != null)
            {
                return NotFound("Такой пользователь не существует");
            }

            await _userRepository.UpdateAsync(user);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _userRepository.GetAsync(id);
            if (user != null)
            {
                return NotFound("Такой пользователь не существует");
            }
            await _userRepository.DeleteAsync(id);
            return Ok();
        }


    }
}
