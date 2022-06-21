using GameShop.Data;
using GameShop.Data.Interfaces;
using GameShop.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace GameShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders _allOrders;
        private readonly ShopCart _cart;
        private readonly IOrderProcess _orderProcess;
        private bool valid;

        public OrderController(IAllOrders allOrders, ShopCart cart, IOrderProcess proc)
        {
            _allOrders = allOrders;
            _cart = cart;
            _orderProcess = proc;
            valid = false;
        }

        private Order GetData(Order order)
        {
            _cart.ListShopItems = _cart.getShopItems();
            if (_cart.ListShopItems.Count == 0)
            {
                ModelState.AddModelError("", "Отсутствуют товары в корзине"); 
            }

            if (ModelState.IsValid)
            {
                _allOrders.createOrder(order);
                string message = order.ClientName + ", благодарим вас за покупку в магазине GameStore! \nВаш заказ был сформирован:"; 
                foreach (var item in order.OrderDetails)
                {
                    message += "\n" + item.game.Name;
                }
                _orderProcess.SendEmail(order.Email, "Заказ #" + order.Id, message);
                valid = true;
            }
            return order;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            GetData(order);
            if(valid) return RedirectToAction("Paid");   // redirection to page "Paid"
            return View(order);
        }

        public IActionResult Paid()   // page that notifies about successful payment
        { 
            return View();
        }

    }
}
