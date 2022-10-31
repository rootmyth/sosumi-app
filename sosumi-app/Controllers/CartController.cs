using Microsoft.AspNetCore.Mvc;
using sosumi_app.Interfaces;
using sosumi_app.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sosumi_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {

        private ICartRepository _cartRepo;

        public CartController(ICartRepository cartRepo)
        {
            _cartRepo = cartRepo;
        }


        // GET: api/<CartController>
        [HttpGet("{id}")]
        public Order GetItemsInCart(int id)
        {
            return _cartRepo.GetItemsInCart(id);
        }

        // GET api/<CartController>/5
        [HttpGet]
        public string Get()
        {
            return "value";
        }

        // POST api/<CartController>
        [HttpPost("{id}")]
        public void Post(int id)
        {
            //check if there is an active order
            //if no -> create new order
            //add item to orderitem table
            if (_cartRepo.checkForActiveOrder(id) == -1)
            {

            }
        }

        // PUT api/<CartController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CartController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
