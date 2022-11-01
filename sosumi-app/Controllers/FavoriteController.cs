﻿using Microsoft.AspNetCore.Mvc;
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

        public Dictionary<int, int> GetFavoritesSortedByMostPopular()
        {
            return _favoriteRepo.GetAllFavorites();
        }

        // GET api/<FavoriteController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FavoriteController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FavoriteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FavoriteController>/5
        [HttpDelete("{UserId}/{ItemId}")]
        public void Delete(int UserId, int ItemId)
        {
            _favoriteRepo.DeleteFavorite(UserId, ItemId);
        }
    }
}
