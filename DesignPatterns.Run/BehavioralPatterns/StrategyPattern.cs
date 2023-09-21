using System;

namespace DesignPatterns.BehavioralPatterns.StrategyPattern
{
    // Define an interface for payment strategies
    public interface IPaymentStrategy
    {
        void PerformPayment();
    }

    // Concrete payment strategy: Credit Card Payment
    public class CreditCardPayment : IPaymentStrategy
    {
        public void PerformPayment()
        {
            Console.WriteLine("Payment performed using a credit card.");
        }
    }

    // Concrete payment strategy: Debit Card Payment
    public class DebitCardPayment : IPaymentStrategy
    {
        public void PerformPayment()
        {
            Console.WriteLine("Payment performed using a debit card.");
        }
    }

    // PaymentProcessor class
    public class PaymentProcessor
    {
        private IPaymentStrategy _paymentStrategy;

        // Constructor to initialize PaymentProcessor with a payment strategy
        public PaymentProcessor(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }

        // Method to change the payment strategy at runtime
        public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }

        // Method to process an order using the selected payment strategy
        public void ProcessOrder()
        {
            // Delegate the payment process to the selected strategy
            _paymentStrategy.PerformPayment();

            // Additional processing steps after payment
            Console.WriteLine("Payment processed.");
        }
    }

    // TestPaymentProcessor class (used for testing)
    public class TestPaymentProcessor
    {
        public void EntryPoint()
        {
            // Create a PaymentProcessor with an initial Debit Card Payment strategy
            var paymentProcessor = new PaymentProcessor(new DebitCardPayment());

            // Process an order using the current payment strategy (Debit Card)
            paymentProcessor.ProcessOrder();

            // Change the payment strategy to Credit Card and process another order
            paymentProcessor.SetPaymentStrategy(new CreditCardPayment());
            paymentProcessor.ProcessOrder();
        }
    }
}
