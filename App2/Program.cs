using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2
{
    class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order(1234567890, 12000, "RUB");

            PaymentSystem payPal = new PaymentSystem(new PayPal(new PayPalHash()));
            PaymentSystem webMoney = new PaymentSystem(new WebMoney(new WebMoneyHash()));
            PaymentSystem rapida = new PaymentSystem(new Rapida(new RapidaHash()));

            Console.WriteLine(payPal.Show(order));
            Console.WriteLine();
            Console.WriteLine(webMoney.Show(order));
            Console.WriteLine();
            Console.WriteLine(rapida.Show(order));
        }
    }

    public class Order
    {
        private readonly int _id;
        private readonly int _amount;
        private readonly string _currency;

        public Order(int id, int amount, string currency) => (_id, _amount, _currency) = (id, amount, currency);

        public int Id => _id;

        public int Amount => _amount;

        public string Currency => _currency;
    }

    public interface IPaymentSystem
    {
        string GetPayingLink(Order order);
    }

    public interface IHash
    {
        string Create(Order order);
    }

    public class PaymentSystem
    {
        private readonly IPaymentSystem _paymentSystem;

        public PaymentSystem(IPaymentSystem paymentSystem)
        {
            _paymentSystem = paymentSystem;
        }

        public string Show(Order order)
        {
            return _paymentSystem.GetPayingLink(order);
        }
}

    public class PayPal : IPaymentSystem
    {
        private readonly IHash _hash;
        private readonly string _address;

        public PayPal(IHash hash)
        {
            _hash = hash;
            _address = "pay.system1.ru/order?";
        }

        public string GetPayingLink(Order order)
        {
            return _address + "amount=" + order.Amount + order.Currency + "&hash={" + _hash.Create(order) + "}";
        }
    }

    public class WebMoney : IPaymentSystem
    {
        private readonly IHash _hash;
        private readonly string _address;

        public WebMoney(IHash hash)
        {
            _hash = hash;
            _address = "order.system2.ru/pay?";
        }

        public string GetPayingLink(Order order)
        {
            return _address + "hash={" + _hash.Create(order) + "}";
        }
    }

    public class Rapida : IPaymentSystem
    {
        private readonly IHash _hash;
        private readonly string _address;

        public Rapida(IHash hash)
        {
            _hash = hash;
            _address = "system3.com/pay?";
        }

        public string GetPayingLink(Order order)
        {
            return _address + "amount=" + order.Amount + "&curency=" + order.Currency + "&hash={" + _hash.Create(order) + "}";
        }
    }

    public class PayPalHash : IHash
    {
        public string Create(Order order)
        {
            return $"{order.Id}";
        }
    }

    public class WebMoneyHash : IHash
    {
        public string Create(Order order)
        {
            return $"{order.Id} + {order.Amount}{order.Currency}";
        }
    }

    public class RapidaHash : IHash
    {
        private readonly string _secretKey;

        public RapidaHash()
        {
            _secretKey = "SecretKey";
        }

        public string Create(Order order)
        {
            return $"{order.Amount}{order.Currency} + {order.Id} + {_secretKey}";
        }
    }
}