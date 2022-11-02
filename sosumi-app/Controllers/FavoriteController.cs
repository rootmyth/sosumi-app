using Microsoft.AspNetCore.Mvc;
using sosumi_app.Interfaces;
using sosumi_app.Models;
using sosumi_app.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sosumi_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private IFavoriteRepository _favoriteRepo;

        public FavoriteController(IFavoriteRepository favoriteRepo)
        {
            _favoriteRepo = favoriteRepo;
        }
        // GET: api/<FavoriteController>
        [HttpGet]

        public List<Item> GetFavorites()
        {
            return _favoriteRepo.GetTopFiveFavorites();
        }

        // GET api/<FavoriteController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FavoriteController>
        [HttpPost("addFavorite/{userid}/{itemid}")]
        public void Post(int userid, int itemid)
        {
            _favoriteRepo.AddFavorite(userid, itemid);
        }

        // PUT api/<FavoriteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FavoriteController>/5
        [HttpDelete("deleteFavorite/{userid}/{itemid}")]
        public void Delete(int userid, int itemid)
        {
            _favoriteRepo.RemoveFavorite(userid, itemid);
        }
    }
}
