namespace shopApi.Models
{
    public class product
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public string imageUrl { get; set; }
        public string description { get; set; }
        public string category { get; set; }
    }
}
