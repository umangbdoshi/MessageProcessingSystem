using System;
namespace MessageProcessingSystem.MessageProcessor
{
    public class AdjustPrice
    {
        // adjustedPrice holds the adjusted price value
        private double _adjustedPrice;
        // product holds the Product object.
        private Product _product;
        // Constructor takes Product as argument.
        public AdjustPrice(Product product)
        {
            this._product = product;
            this._adjustedPrice = 0.0;
        }
        public double GetAdjustedPrice()
        {
            try
            {
                switch (_product.GetAdjustmentOperator())
                {
                    case "Add":
                        AddPrice();
                        break;
                    case "Subtract":
                        SubtractPrice();
                        break;
                    case "Multiply":
                        MultiplyPrice();
                        break;
                    default:
                        throw new Exception("invalid Operator");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return _adjustedPrice;
        }
        // void transaction. Adds product totalprice with the requested price value.
        public void AddPrice()
        {
            this._adjustedPrice = this._product.GetTotalPrice()
                    + (this._product.GetTotalQuantity() * this._product.GetProductPrice());
        }
        // void transaction. Subtracts product totalprice with the requested price
        // value.
        public void SubtractPrice()
        {
            this._adjustedPrice = this._product.GetTotalPrice()
                    - (this._product.GetTotalQuantity() * this._product.GetProductPrice());
        }
        // void transaction. Multiplies product total price and quantity with the requested price and appends to existing total value.
        public void MultiplyPrice()
        {
            this._adjustedPrice = this._product.GetTotalPrice()
                    + (this._product.GetTotalPrice() * this._product.GetProductPrice())
                    + (this._product.GetTotalQuantity() * this._product.GetProductPrice());
        }
        // return string with the details of adjustment made to the product
        public string AdjustmentReport()
        {
            string adjustmentReport = string.Format("Performed {0} {1}p to {2} {3} and price adjusted from {4}p to {5}p",
                    this._product.GetAdjustmentOperator(), this._product.GetProductPrice(), this._product.GetTotalQuantity(),
                    this._product.GetProductType(), this._product.GetTotalPrice(), this._adjustedPrice);
            return adjustmentReport;
        }
    }
}