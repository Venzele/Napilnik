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

        public abstract void Deliver(Good good, int quantity);

        public int Count(string label)
        {
            return _goods.Count(good => good.Label == label);
        }

        public List<string> GiveLablesAssortment()
        {
            List<string> assortmentLabel = new List<string>();

            for (int i = 0; i < _assortmentGoods.Count; i++)
                assortmentLabel.Add(_assortmentGoods[i].Label);

            return assortmentLabel;
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

            if (quantity > _goods.Count)
                throw new ArgumentOutOfRangeException(paramName: "Количество должно быть не больше списка");

            for (int i = 0; i < quantity; i++)
                _goods.Remove(good);
        }
    }
}
