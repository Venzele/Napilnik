using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    class Shop
    {
        private readonly Warehouse _warehouse;
        private readonly Cart _cart;

        public Shop (Warehouse warehouse)
        {
            _warehouse = warehouse;
            _cart = new Cart(warehouse);
        }

        public Cart Cart()
        {
            return _cart;
        }

        public void ShowLeftovers()
        {
            foreach (var label in _warehouse.GiveLablesAssortment())
                Console.WriteLine($"{label} - {_warehouse.Count(label)}шт");
        }

        public void ShowGoods()
        {
            foreach (var label in _cart.GiveLablesAssortment())
                Console.WriteLine($"{label} - {_cart.Count(label)}шт");
        }
    }
}
