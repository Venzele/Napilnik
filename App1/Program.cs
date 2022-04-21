using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    class Program
    {
        static void Main(string[] args)
        {
            Good iPhone12 = new Good("IPhone 12");
            Good iPhone11 = new Good("IPhone 11");

            Warehouse warehouse = new Warehouse();

            Shop shop = new Shop(warehouse);

            warehouse.Deliver(iPhone12, 10);
            warehouse.Deliver(iPhone11, 1);

            Console.WriteLine("На складе:");
            shop.ShowLeftovers(warehouse.AssortmentGoods, warehouse.Goods);

            Cart cart = shop.Cart();
            cart.Deliver(iPhone12, 4);
            cart.Deliver(iPhone11, 3);

            Console.WriteLine("\nВ корзине:");
            shop.ShowLeftovers(cart.AssortmentGoods, cart.Goods);

            Console.WriteLine();
            Console.WriteLine(cart.Order().Paylink);

            cart.Deliver(iPhone12, 9);
        }
    }
}