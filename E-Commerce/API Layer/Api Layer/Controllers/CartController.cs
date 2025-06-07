using Microsoft.AspNetCore.Mvc;
using DTOS;
using Backend_ECommerce_App.Models;
using Microsoft.AspNetCore.Authorization;
using APILayer.Services.User;
namespace API_project.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService c)
        {
            _cartService = c;

        }
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Index");
        }






        [HttpPost("addtoCart")]
        public IActionResult AddToCart([FromBody] CartItemDTO itemdto)
        {
            if (itemdto == null)
            {
                return NotFound();
            }

            int currentID = itemdto.CartID;
            
            if (_cartService.GetCartById(itemdto.CartID) == null)
            {
                string userID = GetUserID();
               Cart cart = new Cart
                {
                    UserId = userID
                };
                _cartService.CreateCart(cart);
                currentID = cart.CartID;
            }

            CartItem item = new CartItem
            {
                CartID = currentID,
                ProductId = itemdto.ProductId
            };

            _cartService.AddToCart(item);
            return Ok();
        }

        [HttpGet("getthisusercartorsaved")]
        public IActionResult GetCartByUser()
        {
            string id = GetUserID();
            var s = _cartService.GetCartByUser(id);
            if (s == null)
            {
                return NotFound();
            }
            return Ok(s);
        }

        [HttpPut("resetCart/{id}")]

        public IActionResult ResetCart(int id)
        {

            _cartService.ResetCart(id);
            return Ok();
        }

        [HttpDelete("removefromcart/{userID}/{cartID}")]
        public IActionResult RemoveFromCart(string userID, int cartID)
        {
            _cartService.RemoveFromCart(userID, cartID);
            return Ok();
        }


        private string GetUserID()
        {
            return
                User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        }
    }
}
