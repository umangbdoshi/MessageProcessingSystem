using MessageProcessingSystem.MessageParser;
namespace MessageProcessingSystem.MessageProcessor
{
    public class SaleProcessor
    {
        // Log to store sales messages and product details
        private SaleLogs _salesLog;
        // Adjustment of product price is handled within this object e.g. add 20p,
        // subtract 20p, etc.
        private AdjustPrice _adjustPrice;
        // This has product information
        private Product _product;
        public SaleProcessor()
        {
            _salesLog = new SaleLogs();
        }
        //Process sales notification and return false if message is empty
        public bool ProcessSalesMessage(string saleNotification)
        {
            // Extract the notification message
            SaleMessageParser messageParser = new SaleMessageParser(saleNotification);
            string productType = messageParser.GetProductType();
            // Check if product type is empty, return false and ignore.
            if (string.IsNullOrEmpty(productType))
                return false;
            // Returns an existing product else returns a new Product object
            _product = _salesLog.GetProduct(productType);
            // Prepare the product details for adjustment
            _adjustPrice = new AdjustPrice(_product);
            // Extract and set the product details from the parsed message
            _product.SetProductQuantity(messageParser.GetProductQuantity());
            _product.SetTotalQuantity(messageParser.GetProductQuantity());
            _product.SetProductPrice(messageParser.GetProductPrice());
            _product.SetAdjustmentOperator(messageParser.GetOperatorType());
            // Set the total value of the product.
            SetProductTotalPrice();
            // Set the sale log reports and Update the product with the new details 
            _salesLog.AddSaleNotificationAndUpdateProduct(saleNotification, _product);

            //This will generate report after 10th message and stop execution after 50th message
            _salesLog.PrintReport();
            return true;
        }
         // Add Total product price based on adjustment
        // Also add the log for adjustments made.
        private void SetProductTotalPrice()
        {
            double adjustedPrice;
            double productValue;
            if (!string.IsNullOrEmpty(_product.GetAdjustmentOperator()))
            {
                adjustedPrice = _adjustPrice.GetAdjustedPrice();
                _salesLog.SetAdjustmentReports(_adjustPrice.AdjustmentReport());
                _product.SetTotalPrice(adjustedPrice);
            }
            else
            {
                productValue = _product.CalculatePrice(_product.GetProductQuantity(), _product.GetProductPrice());
                _product.AppendTotalPrice(productValue);
            }
        }
    }
}