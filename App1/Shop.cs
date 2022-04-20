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

        public void ShowLeftovers(IReadOnlyList<Good> assortmentGoods, IReadOnlyList<Good> goods)
        {
            foreach (var good in assortmentGoods)
            {
                int quantity = goods.Count(selectedGood => selectedGood.Label == good.Label);
                Console.WriteLine($"{good.Label} - {quantity}шт");
            }
        }
    }
}
