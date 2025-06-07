namespace Backend_ECommerce_App.Models
{
    // This will also work as saved items for user.
    public class Cart
    {
        public int CartID { get; set; }
        public string UserId { get; set; }  
        public List<CartItem> Items { get; set; } = new List<CartItem>();
         
    }
}
