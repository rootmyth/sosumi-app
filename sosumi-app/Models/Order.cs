namespace sosumi_app.Models
{
    public class Order
    {
        private int orderId { get; set; }
        private int userId { get; set; }
        private DateTime date { get; set; }
        private bool delivery { get; set; }
        private bool paid { get; set; }
    }
}
