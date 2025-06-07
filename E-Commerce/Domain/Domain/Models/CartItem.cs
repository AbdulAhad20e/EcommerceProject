namespace Backend_ECommerce_App.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CartID { get; set; }
        public Product Product { get; set; }
        public Cart Cart { get; set; }
    }
}
