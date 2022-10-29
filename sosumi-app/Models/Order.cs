namespace sosumi_app.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public bool Delivery { get; set; }
        public bool Paid { get; set; }
    }
}
