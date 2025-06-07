using Backend_ECommerce_App.Models;
using Infrastructure;

namespace Backend_ECommerce_App.Respostiories
{
    public class CartRepository : ICartRepository
    {
        private readonly WebContext _studentDbContext;

        public CartRepository(WebContext context)
        {
            _studentDbContext = context;
        }

        public void CreateCart(Cart cart)
        {
            _studentDbContext.Carts.Add(cart);
            _studentDbContext.SaveChanges();
        }

        public void AddToCart( CartItem cartItem)
        {
            _studentDbContext.CartItems.Add(cartItem);
            _studentDbContext.SaveChanges();
        }

        public Cart GetCartByUser(string userId)
        {
            return _studentDbContext.Carts.Where(c => c.UserId == userId).Single();
        }

        public void RemoveFromCart(string userId, int cartItemId)
        {
            Cart cart = GetCartByUser(userId);
            cart.Items.Remove(cart.Items.Where(c => c.Id == cartItemId).Single());
            _studentDbContext.SaveChanges();
        }

        public void ResetCart(int cartID)
        {
            string userID = _studentDbContext.Carts.Where(c => c.CartID == cartID).Single().UserId;
            Cart cart = GetCartByUser(userID);
            _studentDbContext.Carts.Remove(cart);
            Cart EmptyCart = new Cart() { UserId = userID };
            _studentDbContext.Carts.Add(EmptyCart);
            _studentDbContext.SaveChanges();
        }

        public Cart GetCartById(int id)
        {
            return _studentDbContext.Carts.Where(c=>c.CartID == id).FirstOrDefault();
        }
    }
}
