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

            warehouse.DeliverGoods(iPhone12, 10);
            warehouse.DeliverGoods(iPhone11, 1);

            Console.WriteLine("На складе:");
            warehouse.ShowLeftovers();

            Cart cart = shop.Cart();
            cart.AddGoods(iPhone12, 4);
            cart.AddGoods(iPhone11, 3);

            Console.WriteLine("\nВ корзине:");
            cart.ShowGoods();

            Console.WriteLine();
            Console.WriteLine(cart.Order().Paylink);

            cart.AddGoods(iPhone12, 9);
        }
    }
}
