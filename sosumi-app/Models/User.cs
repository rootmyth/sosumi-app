namespace sosumi_app.Models
{
    public class User
    {
        private int id { get; set; }
        private string firstName { get; set; }
        private string lastName { get; set; }
        private string email { get; set; } 
        private string password { get; set; }
        private string address { get; set; }
        private bool firstTime { get; set; }

        public List<Item> favorites;
    }
}
