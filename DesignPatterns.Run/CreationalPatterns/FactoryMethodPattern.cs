using System;

namespace DesignPatterns.CreationalPatterns.FactoryMethod
{
    #region Factory Method (Example 1)
    // 1.[Product] Define an interface for the products (file readers).
    public interface IFileReader
    {
        void Read(string filePath);
    }

    // 2.[Concrete Products] Create concrete product classes (PDF and Text file readers).
    public class PdfFileReader : IFileReader
    {
        public void Read(string filePath)
        {
            Console.WriteLine($"Reading PDF file: {filePath}");
            // Code to read PDF file
        }
    }

    public class TextFileReader : IFileReader
    {
        public void Read(string filePath)
        {
            Console.WriteLine($"Reading Word document: {filePath}");
            // Code to read Word document
        }
    }

    // 3.[Creator] Create an abstract creator class (FileProcessor).
    public abstract class FileProcessor
    {
        // 4. Declare a factory method for creating product objects.
        public abstract IFileReader CreateFileReader();

        // 5. Use the factory method to create products (file readers).
        public void ProcessFile(string filePath)
        {
            // 5a. Use the factory method to create a product (file reader).
            IFileReader fileReader = CreateFileReader();

            // 5b. Use the created product (file reader) to process the file.
            if (!string.IsNullOrEmpty(filePath))
            {
                fileReader.Read(filePath);
                // Additional processing logic
            }
            else
            {
                Console.WriteLine("Unsupported file format.");
            }
        }
    }

    // 6.[Concrete Creators] Create concrete creator classes (PdfFileProcessor and TextFileProcessor).
    public class PdfFileProcessor : FileProcessor
    {
        // 7. Implement the factory method to return a specific product (PDF file reader).
        public override IFileReader CreateFileReader()
        {
            // 7a. Create and return a specific product (PDF file reader).
            return new PdfFileReader();
        }
    }

    public class TextFileProcessor : FileProcessor
    {
        // 8. Implement the factory method to return a specific product (Text file reader).
        public override IFileReader CreateFileReader()
        {
            // 8a. Create and return a specific product (Text file reader).
            return new TextFileReader();
        }
    }

    public class TestFileProcessor
    {
        public void EntryPoint()
        {
            FileProcessor pdfProcessor = new PdfFileProcessor();
            FileProcessor wordProcessor = new TextFileProcessor();

            pdfProcessor.ProcessFile("sample.pdf");
            wordProcessor.ProcessFile("document.docx");
        }
    }
    #endregion

    #region Factory Method (Example 2)
    // Define an enumeration to represent different payment modes
    public enum PaymentMode
    {
        DebitCard,
        CreditCard
    }

    // Product: Payment Processor interface
    public interface IPaymentProcessor
    {
        void ProcessPayment(decimal amount);
    }

    // Concrete Products: Debit & Credit Card Processor
    public class DebitCardProcessor : IPaymentProcessor
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine("Processing Debit Card payment.");
            // Actual Debit Card processing logic here
        }
    }

    public class CreditCardProcessor : IPaymentProcessor
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine("Processing Credit Card payment.");
            // Actual Credit Card processing logic here
        }
    }

    // Creator: Payment Processor Factory
    public interface IPaymentProcessorFactory
    {
        public IPaymentProcessor CreatePaymentProcessor(PaymentMode paymentMode);
    }

    public class PaymentProcessorFactory: IPaymentProcessorFactory
    {
        // Factory method to create a payment processor based on the specified payment mode
        public IPaymentProcessor CreatePaymentProcessor(PaymentMode paymentMode)
        {
            switch (paymentMode)
            {
                case PaymentMode.DebitCard:
                    return new DebitCardProcessor(); // Create a Debit Card Processor

                case PaymentMode.CreditCard:
                    return new CreditCardProcessor(); // Create a Credit Card Processor

                default:
                    throw new NotImplementedException("Payment Processor not defined.");
            }
        }
    }

    // Test Class to Demonstrate Factory Usage
    public class TestPaymentProcessorFactory
    {
        public void EntryPoint()
        {
            IPaymentProcessorFactory factory = new PaymentProcessorFactory();

            // User selects a payment method (e.g., from user input or configuration)
            PaymentMode selectedPaymentMode = PaymentMode.DebitCard;

            // Create the appropriate payment processor using the factory
            IPaymentProcessor paymentProcessor = factory.CreatePaymentProcessor(selectedPaymentMode);
            // Process the payment using the selected payment processor
            paymentProcessor.ProcessPayment(100.0m);
        }
    }
    #endregion
}
