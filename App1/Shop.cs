using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    class Shop
    {
        private Warehouse _warehouse;
        private Cart _cart;

        public Shop (Warehouse warehouse)
        {
            _warehouse = warehouse;
            _cart = new Cart(warehouse);
        }

        public Cart Cart()
        {
            return _cart;
        }
    }
}
