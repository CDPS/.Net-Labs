using Microsoft.AspNetCore.Mvc;
using PieShop.Data.OrderRepository;
using PieShop.Entities.Orders;
using PieShop.Web.Models;
using System.Collections.Generic;

namespace PieShop.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingCart;

        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty, add some pies first");
            }

            if (ModelState.IsValid)
            {
                var shoppingCartItems = _shoppingCart.ShoppingCartItems;


                order.OrderDetails = new List<OrderDetail>();
                //adding the order with its details

                foreach (var shoppingCartItem in shoppingCartItems)
                {
                    var orderDetail = new OrderDetail
                    {
                        Amount = shoppingCartItem.Amount,
                        PieId = shoppingCartItem.Pie.PieId,
                        Price = shoppingCartItem.Pie.Price
                    };

                    order.OrderDetails.Add(orderDetail);
                }

                _orderRepository.Add(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }
            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order. You'll soon enjoy our delicious pies!";
            return View();
        }
    }
}
