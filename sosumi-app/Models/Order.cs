namespace sosumi_app.Models
{
    public class Order
    {
        public int orderId { get; set; }
        public int userId { get; set; }
        public DateTime date { get; set; }
        public bool delivery { get; set; }
        public bool paid { get; set; }
    }
}
