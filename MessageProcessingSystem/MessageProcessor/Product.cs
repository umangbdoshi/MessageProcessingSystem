namespace MessageProcessingSystem.MessageProcessor
{
    public class Product
    {
        private double _productPrice;
        private int _productQuantity;
        // A single product sale entry adjustment request e.g. Add or Subtract or Multiply
        private string _adjustmentOperator;
        // A single product sale entry type e.g apples or oranges, etc.
        private string _productType;
        // The entire product type quantity e.g., apples = 20;
        private int _totalQuantity;
        // The entire product type price total value e.g., apples = 6.300000;
        private double _totalPrice;
        // Constructor
        public Product(string type)
        {
            _totalPrice = 0.0;
            _totalQuantity = 0;
            _productType = type;
            _adjustmentOperator = null;
        }

        // Calculate the given quantity with given price and return the value
        public double CalculatePrice(int productQuantity, double productPrice)
        {
            return productQuantity * productPrice;
        }
        // Set the total price of the sale to the given value
        public void SetTotalPrice(double totalPrice)
        {
            _totalPrice = totalPrice;
        }
        // Add the given value to the existing total price of the requested product.
        public void AppendTotalPrice(double productPrice)
        {
            _totalPrice += productPrice;
        }
        // Add the given quantity to the existing total quantity.
        public void SetTotalQuantity(int quantity)
        {
            _totalQuantity += quantity;
        }
        // Get the total quantity of the requested product.
        public int GetTotalQuantity()
        {
            return _totalQuantity;
        }

        // Get the total price of the requested product.
        public double GetTotalPrice()
        {
            return _totalPrice;
        }
        // Get the type of the requested product.
        public string GetProductType()
        {
            return _productType;
        }
        // Set the type of product with the requested type. NOT USED
        public void SetProductType(string type)
        {
            _productType = type;
        }
        // Get the price of the requested product
        public double GetProductPrice()
        {
            return _productPrice;
        }
        // Set the price of the requested product
        public void SetProductPrice(double productPrice)
        {
            _productPrice = productPrice;
        }
        // Get the product quantity
        public int GetProductQuantity()
        {
            return _productQuantity;
        }
        // Set the product quantity to the given value
        public void SetProductQuantity(int productQuantity)
        {
            _productQuantity = productQuantity;
        }
        public string GetAdjustmentOperator()
        {
            return _adjustmentOperator;
        }
        // Set the product adjustmentOperator to the provided operator e.g, Add, Subtract, or Multiply.
        public void SetAdjustmentOperator(string adjustmentOperator)
        {
            _adjustmentOperator = adjustmentOperator;
        }
    }
}