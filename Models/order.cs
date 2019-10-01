namespace shopApi.Models
{
    public class order
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string phone { get; set; }
        public string email { get; set; }

        public bool isSend { get; set; }
        public product product { get; set; }
        public int quantity { get; set; }

    }
}