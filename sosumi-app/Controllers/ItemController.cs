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
            var returnVar = _itemRepo.GetAllItems();
            return returnVar;
        }

        // GET: api/<ItemController>
        [HttpGet("special")]
        public List<Item> GetSpecials()
        {
            return _itemRepo.GetSpecials();
        }
    }
}
