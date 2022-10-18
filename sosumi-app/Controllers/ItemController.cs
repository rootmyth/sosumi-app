using Microsoft.AspNetCore.Mvc;
using sosumi_app.Interfaces;
using sosumi_app.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sosumi_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {

        private IItemRepository _itemRepo;

        public ItemController(IItemRepository itemRepo)
        {
            _itemRepo = itemRepo;
        }
        // GET: api/<ItemController>
        [HttpGet]
        public List<Item> Get()
        {
            return _itemRepo.GetAllItems();
        }

        // GET api/<ItemController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ItemController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ItemController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ItemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
