using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.CreationalPatterns.Prototype
{
    // Step 1: Define a prototype interface
    public interface IReportPrototype
    {
        IReportPrototype Clone();
        void GenerateReport();
    }

    // Step 2: Create concrete classes that implement the prototype interface
    public class SalesReport : IReportPrototype
    {
        public string ReportType { get; set; }

        public SalesReport(string reportType)
        {
            ReportType = reportType;
        }

        public IReportPrototype Clone()
        {
            // Create a new SalesReport object by copying this instance's data
            return new SalesReport(ReportType);
        }

        public void GenerateReport()
        {
            Console.WriteLine($"Generating {ReportType} Sales Report...");
            // Generate the report with specific formatting and data retrieval logic
        }
    }

    public class FinancialReport : IReportPrototype
    {
        public string ReportName { get; set; }

        public FinancialReport(string reportName)
        {
            ReportName = reportName;
        }

        public IReportPrototype Clone()
        {
            // Create a new FinancialReport object by copying this instance's data
            return new FinancialReport(ReportName);
        }

        public void GenerateReport()
        {
            Console.WriteLine($"Generating {ReportName} Financial Report...");
            // Generate the report with specific formatting and data retrieval logic
        }
    }

    // Step 3: Create a report manager that uses prototypes to create and manage reports
    public class ReportManager
    {
        private Dictionary<string, IReportPrototype> reportPrototypes = new Dictionary<string, IReportPrototype>();

        public void RegisterReport(string key, IReportPrototype prototype)
        {
            reportPrototypes[key] = prototype;
        }

        public IReportPrototype CreateReport(string key)
        {
            if (reportPrototypes.ContainsKey(key))
            {
                return reportPrototypes[key].Clone();
            }
            else
            {
                throw new ArgumentException($"Report prototype with key '{key}' not found.");
            }
        }
    }

    public class TestPrototypePattern
    {
        public void EntryPoint()
        {
            // Initialize the report manager
            ReportManager reportManager = new ReportManager();

            // Register report prototypes
            reportManager.RegisterReport("Sales", new SalesReport("Sales"));
            reportManager.RegisterReport("Financial", new FinancialReport("Financial"));

            // Create and generate reports using prototypes
            var salesReport = reportManager.CreateReport("Sales");
            var financialReport = reportManager.CreateReport("Financial");

            salesReport.GenerateReport();
            financialReport.GenerateReport();
        }
    }
}