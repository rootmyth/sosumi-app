using Microsoft.AspNetCore.Mvc;
using sosumi_app.Interfaces;
using sosumi_app.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sosumi_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderRepository _orderRepo;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepo = orderRepository;
        }
        // GET: api/<OrderController>
        [HttpGet]
        public List<Order> Get()
        {
            return _orderRepo.GetAllOrders();
        }

        // GET api/<OrderController>/5
        [HttpGet("user{id}")]
        public List<Order> Get(int id)
        {
            return _orderRepo.GetOrdersByUserId(id);
        }

        // GET api/<OrderController>/5
        [HttpGet("user{id}/cart")]
        public List<Order> GetCart(int id)
        {
            return _orderRepo.GetCartByUserId(id);
        }

        // POST api/<OrderController>
        [HttpPost]
        public void Post(Order order)
        {
            try
            {
                _orderRepo.AddOrder(order);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
