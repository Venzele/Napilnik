using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    class Cart : Container
    {
        private readonly Warehouse _warehouse;

        public Cart (Warehouse warehouse)
        {
            _warehouse = warehouse;
        }

        public override void Deliver(Good good, int quantity)
        {
            if (good == null)
                throw new ArgumentNullException(nameof(good));

            if (_warehouse.Ship(good, quantity))
            {
                Add(good, quantity);
                UpdateAssortmentGoods();
            }
        }

        public Order Order()
        {
            return new Order();
        }
    }
}
