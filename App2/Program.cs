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

            SetterPaySystem setterPaySystem = new SetterPaySystem();
            PaymentHandler paymentHandler = new PaymentHandler(setterPaySystem.Create(systemId));

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
            _paySystem.ShowOutputResult();
            Console.WriteLine($"Вы оплатили с помощью {systemId}");
            _paySystem.ShowPaymentResult();
            Console.WriteLine("Оплата прошла успешно!");
        }
    }

    public class SetterPaySystem
    {
        public PaySystem Create(string systemId)
        {
            {
                if (systemId == PaymentType.Qiwi.ToString().ToLower())
                    return new Qiwi();

                if (systemId == PaymentType.WebMoney.ToString().ToLower())
                    return new WebMoney();

                if (systemId == PaymentType.Card.ToString().ToLower())
                    return new Card();

                throw new ArgumentOutOfRangeException(nameof(systemId));
            }
        }
    }

    public class PaySystem
    {
        protected string SystemId;
        protected string Message;

        public void ShowOutputResult()
        {
            Console.WriteLine($"{Message} {SystemId}...");
        }

        public void ShowPaymentResult()
        {
            Console.WriteLine($"Проверка платежа через {SystemId}...");
        }
    }

    public class Qiwi : PaySystem
    {
        public Qiwi()
        {
            SystemId = PaymentType.Qiwi.ToString();
            Message = "Перевод на страницу";
        }
    }

    public class WebMoney : PaySystem
    {
        public WebMoney()
        {
            SystemId = PaymentType.WebMoney.ToString();
            Message = "Вызов API";
        }
    }

    public class Card : PaySystem
    {
        public Card()
        {
            SystemId = PaymentType.Card.ToString();
            Message = "Вызов API банка эмитера карты";
        }
    }
}