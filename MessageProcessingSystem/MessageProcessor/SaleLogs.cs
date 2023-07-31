using System;
using System.Collections.Generic;
using System.Linq;
namespace MessageProcessingSystem.MessageProcessor
{
    public class SaleLogs
    {
        //dictionary to maintain alkl the products list
        private Dictionary<string, Product> ProductsList = new Dictionary<string, Product>();
        // Used to total the sale value of the product. @note: does not store total
        // value of the all products
        private double TotalSalesValue;
        // Logs all sales notifications.
        private List<string> SalesNotificationsList;
        // Logs all the adjustment reports of the sale orders.
        private List<string> AdjustmentReports;
        // Constructor
        public SaleLogs()
        {
            this.SalesNotificationsList = new List<string>();
            this.AdjustmentReports = new List<string>();
            this.TotalSalesValue = 0.0;
        }

        // Get the product from line item based on their type e.g, apple
        public Product GetProduct(string type)
        {
            ProductsList.TryGetValue(type, out var value);
            return value == null ? new Product(type) : value;
        }
        
        // Get all the adjustment report as an array list
        public List<string> GetAdjustmentReports()
        {
            return AdjustmentReports;
        }
        // Set an adjustment log string to the adjustmentReports list
        public void SetAdjustmentReports(string adjustmentReport)
        {
            this.AdjustmentReports.Add(adjustmentReport);
        }
        // Append any given value to the totalSalesValue field
        public void AppendTotalSalesValue(double productTotalPrice)
        {
            TotalSalesValue += productTotalPrice;
        }
        // Set total sales value with the given value
        public void SetTotalSalesValue(double productTotalPrice)
        {
            TotalSalesValue = productTotalPrice;
        }
        public void AddSaleNotificationAndUpdateProduct(string saleNotification, Product product)
        {
            AddSalesNotifications(saleNotification);
            UpdateProduct(product);
        }
        // Update the line item product with new details.
        private void UpdateProduct(Product product)
        {
            if (!ProductsList.ContainsKey(product.GetProductType()))
                ProductsList.Add(product.GetProductType(), product);
            else
                ProductsList[product.GetProductType()] = product;
        }
        private void AddSalesNotifications(string saleNotification)
        {
            this.SalesNotificationsList.Add(saleNotification);
        }
        //This method will generate report after 10th message and stop execution after 50th message
        public void PrintReport()
        {
            // Report after 10th message.
            if ((SalesNotificationsList.Count() % 10) == 0 && SalesNotificationsList.Count() != 0)
            {
                SetTotalSalesValue(0.0);
                Console.WriteLine("10 sales appended to log");
                Console.WriteLine("*************** Sales Log Report *****************");
                Console.WriteLine("|Product           |Quantity   |Value      |");
                foreach (var item in ProductsList)
                    FormatReports(item.Key, item.Value);
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine(string.Format("|{0,-30}|{1:00000.00}|", "Total Sales", TotalSalesValue));
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("End\n\n");
            }
            // Report adjustments and stop execution after 50 messages
            if ((SalesNotificationsList.Count() % 50) == 0 && SalesNotificationsList.Count() != 0)
            {
                Console.WriteLine(
                        "Limit of 50 messages reached. The system cannot process further.\n");
                // Display all the adjustment reports.
                GetAdjustmentReports().ForEach(x => Console.WriteLine(x));
                Console.WriteLine("Pausing the application.....");
                Console.ReadLine();
            }
        }
        // Format the report with padding
        public void FormatReports(string type, Product product)
        {
            string lineItem = string.Format("|{0,-18}|{1,-11}|{2:000000.00}|", product.GetProductType(), product.GetTotalQuantity(),
                    product.GetTotalPrice());
            AppendTotalSalesValue(product.GetTotalPrice());
            Console.WriteLine(lineItem);
        }
    }
}