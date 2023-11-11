using System;

namespace DesignPatterns.StructuralPatterns.Adapter
{
    // Step 1: Define the standard payment processing interface
    public interface IPaymentProcessor
    {
        void ProcessPayment(decimal amount);
    }

    // Step 2: Create concrete payment processor for the system
    public class PaymentProcessor : IPaymentProcessor
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing payment of {amount:C} using the standard payment processor.");
        }
    }

    // Step 3: Define the interface of an incompatible payment gateway
    public interface IThirdPartyPaymentGateway
    {
        void Pay(decimal amount);
    }

    // Step 4: Create an adapter to make the third-party gateway compatible
    public class ThirdPartyPaymentGatewayAdapter : IPaymentProcessor
    {
        private readonly IThirdPartyPaymentGateway gateway;

        public ThirdPartyPaymentGatewayAdapter(IThirdPartyPaymentGateway gateway)
        {
            this.gateway = gateway;
        }

        public void ProcessPayment(decimal amount)
        {
            // Adapt the ProcessPayment method to call Pay on the third-party gateway
            gateway.Pay(amount);
        }
    }

    // Step 5: Implement the third-party payment gateways
    public class PayPalGateway : IThirdPartyPaymentGateway
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid {amount:C} via PayPal.");
        }
    }

    public class StripeGateway : IThirdPartyPaymentGateway
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid {amount:C} via Stripe.");
        }
    }

    // Step 6: Client code that uses the payment processing system
    class TestAdapterPattern
    {
        static void EntryPoint()
        {
            // Create a standard payment processor
            IPaymentProcessor standardProcessor = new PaymentProcessor();

            // Create adapters for third-party payment gateways
            IPaymentProcessor paypalAdapter = new ThirdPartyPaymentGatewayAdapter(new PayPalGateway());
            IPaymentProcessor stripeAdapter = new ThirdPartyPaymentGatewayAdapter(new StripeGateway());

            // Process payments using different processors
            standardProcessor.ProcessPayment(100.0m);
            paypalAdapter.ProcessPayment(50.0m);
            stripeAdapter.ProcessPayment(75.0m);
        }
    }

}