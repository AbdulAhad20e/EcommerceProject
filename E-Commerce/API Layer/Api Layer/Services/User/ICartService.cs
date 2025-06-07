using Backend_ECommerce_App.Models;

namespace APILayer.Services.User
{
    public interface ICartService
    {
        public void CreateCart(Cart cart);
        public Cart GetCartById(int id);    
        public Cart GetCartByUser(string userId);
        public void AddToCart(CartItem cartItem);
        public void RemoveFromCart(string userId, int cartId);
        public void ResetCart(int cartID);
    }
}
