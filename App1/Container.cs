using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    abstract class Container
    {
        private List<Good> _goods;
        private List<Good> _assortmentGoods;

        public Container()
        {
            _goods = new List<Good>();
            _assortmentGoods = new List<Good>();
        }

        public IReadOnlyList<Good> Goods => _goods;
        public IReadOnlyList<Good> AssortmentGoods => _assortmentGoods;

        public abstract void Deliver(Good good, int quantity);

        public int Count(string label)
        {
            return _goods.Count(good => good.Label == label);
        }

        protected void UpdateAssortmentGoods()
        {
            _assortmentGoods = _goods.Distinct().ToList();
        }

        protected void Add(Good good, int quantity)
        {
            if (good == null)
                throw new ArgumentNullException(nameof(good));

            for (int i = 0; i < quantity; i++)
                _goods.Add(good);
        }

        protected void Remove(Good good, int quantity)
        {
            if (good == null)
                throw new ArgumentNullException(nameof(good));

            if (quantity > Count(good.Label))
                throw new ArgumentOutOfRangeException(paramName: "Количество должно быть не больше списка");

            for (int i = 0; i < quantity; i++)
                _goods.Remove(good);
        }
    }
}
