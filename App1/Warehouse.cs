using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    class Warehouse : Container
    {
        public override void Deliver(Good good, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentOutOfRangeException(paramName: "Количество должно быть больше 0");

            Add(good, quantity);
            UpdateAssortmentGoods();
        }

        public bool Ship(Good selectedGood, int quantity)
        {
            if (selectedGood == null)
                throw new ArgumentNullException(nameof(selectedGood));

            if (Count(selectedGood.Label) <= 0)
            {
                Console.WriteLine($"\n{selectedGood.Label} нет на складе!");
            }
            else if (Count(selectedGood.Label) < quantity)
            {
                Console.WriteLine($"\n{selectedGood.Label} недостаточно на складе!");
            }
            else if (Count(selectedGood.Label) >= quantity)
            {
                Remove(selectedGood, quantity);
                return true;
            }

            return false;
        }
    }
}
