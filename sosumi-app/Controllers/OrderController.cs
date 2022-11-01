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
            return _orderRepo.GetOrderItem();
        }


        [HttpGet("getOrderItem")]
        public List<OrderItem> GetOrderItem()
        {
            return _orderRepo.GetOrderItemTable();
            //add qantinty

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
        [HttpPost("{id}/{itemId}")]
        public void Post(int id, int itemId)
        {
            if(!(_orderRepo.GetCartByUserId(id).Count > 0))
            {
                _orderRepo.AddOrder(id);
            }
            int orderId = _orderRepo.GetCartByUserId(id)[0].Id;
            int quantity = _orderRepo.CheckForItemInCart(orderId, itemId);
            if(quantity == 0)
            {
                _orderRepo.AddOrderToOrderItem(orderId, itemId);
            } else
            {
                _orderRepo.AddOrderToOrderItem(orderId, itemId, quantity);
            }
        }

        // PUT api/<OrderController>/5
        [HttpPost("decrementQuantity/{userId}/{itemId}")]
        public void Put(int userId, int itemId)
        {
            int orderId = _orderRepo.GetCartByUserId(userId)[0].Id;
            _orderRepo.RemoveItemFromCart(orderId, itemId);
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{userId}/{itemId}")]
        public void Delete(int userId, int itemId)
        {
            
        }
    }
}
