using Microsoft.AspNetCore.Mvc;
using sosumi_app.Interfaces;
using sosumi_app.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sosumi_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepo;
        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _userRepo.GetUserById(id);
        }

        [HttpGet("checkIfUserExists/{firebaseid}")]
        public Boolean GetUserIfExists(string firebaseid)
        {
            return _userRepo.GetUserByFireBaseId(firebaseid);
        }

        [HttpGet("getUserByFireBaseId/{firebaseid}")]
        public User GetUser(string firebaseid)
        {
            return _userRepo.GetCurrentUserByFireBaseId(firebaseid);
        }

        [HttpGet("favorites/{id}")]
        public List<Item> GetFavoritesByUserId(int id)
        {
            return _userRepo.GetFavoritesByUserId(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post(User user)
        {
            try
            {
                _userRepo.CreateUser(user);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
