﻿namespace sosumi_app.Models
{
    public class User
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string address { get; set; }
        public bool firstTime { get; set; }

        public List<Item> favorites;
    }
}
