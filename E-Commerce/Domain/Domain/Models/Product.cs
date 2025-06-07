namespace Backend_ECommerce_App.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int Ratings { get; set; }
        public string ImagePath { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }

    }
}
