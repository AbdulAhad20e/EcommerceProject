using Backend_ECommerce_App.Models;
using Backend_ECommerce_App.Respostiories;

namespace APILayer.Services.User
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _repository;

        public CartService(ICartRepository r)
        {
            _repository = r;
        }

        public void AddToCart( CartItem cartItem)
        {
            _repository.AddToCart(cartItem);
        }

        public void CreateCart(Cart cart)
        {
            _repository.CreateCart(cart);
        }

        public Cart GetCartById(int id)
        {
            return _repository.GetCartById(id);
        }

        public Cart GetCartByUser(string userId)
        {
            return _repository.GetCartByUser(userId);
        }

        public void RemoveFromCart(string userId, int cartId)
        {
            _repository.RemoveFromCart(userId, cartId);
        }

        public void ResetCart(int cartID)
        {
            _repository.ResetCart(cartID);
        }
    }
}
