using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    class Order
    {
        public string Paylink { get; private set; }

        public Order()
        {
            Paylink = "Пустая ссылка.";
        }
    }
}
