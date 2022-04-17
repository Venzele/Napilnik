using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    class Cart
    {
        private Warehouse _warehouse;
        private List<Good> _goods;
        private List<Good> _assortmentGoods;

        public Cart (Warehouse warehouse)
        {
            _warehouse = warehouse;
            _goods = new List<Good>();
            _assortmentGoods = new List<Good>();
        }

        public void AddGoods(Good good, int quantity)
        {
            if (good == null)
                throw new ArgumentNullException(nameof(good));

            if (_warehouse.ShipGoods(good, quantity))
            {
                for (int i = 0; i < quantity; i++)
                {
                    _goods.Add(good);
                }

                ChangeAssortmentGoods();
            }
        }

        public void ShowGoods()
        {
            foreach (var item in _assortmentGoods)
            {
                int quantitySameGoods = _goods.Count(good => good.Label == item.Label);
                Console.WriteLine($"{item.Label} - {quantitySameGoods}шт");
            }
        }

        public Order Order()
        {
            return new Order();
        }

        private void ChangeAssortmentGoods()
        {
            _assortmentGoods = _goods.Distinct().ToList();
        }
    }
}
