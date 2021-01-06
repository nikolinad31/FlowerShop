using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FlowerShop.Models;
using FlowerShop.Data;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(ApplicationDbContext context, ShoppingCart shoppingCart)
        {
            _context = context;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Index(bool isValidAmount = true)
        {
            _shoppingCart.GetShoppingCartItems();

            var model = new ShoppingCartIndexModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal(),
            };

            if(!isValidAmount) ViewData["InvalidAmountText"] = "The item is out of stock";

            return View("Index",model);
        }
        
        public async Task<IActionResult> Add(int? id, int amount=1)
        {
             if (id == null)
            {
                return NotFound();
            }

            var flower = await _context.Flower.FirstOrDefaultAsync(m => m.Id == id);
            if (flower == null)
            {
                return NotFound();
            }
            
            bool isValidAmount = false;
            if (flower != null)
            {
                isValidAmount = _shoppingCart.AddToCart(flower, amount);
            }

            return Index(isValidAmount);
        }
    }
}
