using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    class Warehouse
    {
        private List<Good> _goods = new List<Good>();
        private List<Good> _assortmentGoods = new List<Good>();

        public void DeliverGoods(Good good, int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException(paramName: "Количество должно быть больше 0.");
            }

            for (int i = 0; i < quantity; i++)
            {
                _goods.Add(good);
            }

            ChangeAssortmentGoods();
        }

        public bool ShipGoods(Good shippedGood, int quantity)
        {
            if (shippedGood == null)
            {
                return false;
                throw new ArgumentNullException(nameof(shippedGood));
            }

            var definiteGoods = _goods.Where(good => good.Label == shippedGood.Label).ToList();

            if (definiteGoods.Count <= 0)
            {
                Console.WriteLine($"\n{shippedGood.Label} нет на складе!");
                return false;
            }
            else if (definiteGoods.Count < quantity)
            {
                Console.WriteLine($"\n{shippedGood.Label} недостаточно на складе!");
                return false;
            }
            else
            {
                for (int i = 0; i < quantity; i++)
                {
                    _goods.Remove(shippedGood);
                }

                return true;
            }
        }

        public void ShowLeftovers()
        {
            foreach (var item in _assortmentGoods)
            {
                int quantitySameGoods = _goods.Count(good => good.Label == item.Label);
                Console.WriteLine($"{item.Label} - {quantitySameGoods}шт");
            }
        }

        private void ChangeAssortmentGoods()
        {
            _assortmentGoods = _goods.Distinct().ToList();
        }
    }
}
