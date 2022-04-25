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
            OrderForm orderForm = new OrderForm();
            string systemId = orderForm.ShowForm();

            PaySystem paySystem = new PaySystem(systemId);
            PaymentHandler paymentHandler = new PaymentHandler(paySystem);

            paySystem.ShowPaymentPay();
            paymentHandler.ShowPaymentResult(systemId);
        }
    }

    public enum PaymentType
    {
        Qiwi,
        WebMoney,
        Card
    }

    public class OrderForm
    {
        public string ShowForm()
        {
            Console.WriteLine("Мы принимаем: QIWI, WebMoney, Card");

            //симуляция веб интерфейса
            Console.WriteLine("Какое системой вы хотите совершить оплату?");
            return Console.ReadLine().ToLower();
        }
    }

    public class PaymentHandler
    {
        private PaySystem _paySystem;

        public PaymentHandler(PaySystem paySystem)
        {
            _paySystem = paySystem;
        }

        public void ShowPaymentResult(string systemId)
        {
            Console.WriteLine($"Вы оплатили с помощью {systemId}");
            _paySystem.ShowPaymentResult();
            Console.WriteLine("Оплата прошла успешно!");
        }
    }

    public class PaySystem
    {
        private string _systemId;

        public PaySystem(string systemId)
        {
            _systemId = systemId;
        }

        public void ShowPaymentPay()
        {
            Console.WriteLine($"{GetMassage()} {_systemId}...");
        }

        public void ShowPaymentResult()
        {
            Console.WriteLine($"Проверка платежа через {_systemId}...");
        }

        private string GetMassage()
        {
            if (_systemId == PaymentType.Qiwi.ToString().ToLower())
                return "Перевод на страницу";

            if (_systemId == PaymentType.WebMoney.ToString().ToLower())
                return "Вызов API";

            if (_systemId == PaymentType.Card.ToString().ToLower())
                return "Вызов API банка эмитера карты";

            throw new ArgumentOutOfRangeException(nameof(_systemId));
        }
    }

    public class Qiwi : PaySystem
    {
        public Qiwi(string systemId) : base(systemId) { }
    }

    public class WebMoney : PaySystem
    {
        public WebMoney(string systemId) : base(systemId) { }
    }

    public class Card : PaySystem
    {
        public Card(string systemId) : base(systemId) { }
    }
}