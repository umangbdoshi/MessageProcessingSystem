using System;
using System.Text.RegularExpressions;
namespace MessageProcessingSystem.MessageParser
{
    public class SaleMessageParser
    {
        // Parsed product type
        private string ProductType;
        // Parsed product price
        private double ProductPrice;
        // Parsed product quantity
        private int ProductQuantity;
        // Parsed product operatorType e.g Add, Subtract
        private string OperatorType;
        public SaleMessageParser(string message)
        {
            this.ProductType = "";
            this.ProductPrice = 0.0;
            this.ProductQuantity = 0;
            this.OperatorType = "";
            ParseMessage(message);
        }

        private bool ParseMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return false;
            }
            string[] messageArray = message.Trim().Split(' ');
            string firstWord = messageArray[0];
            if (firstWord.Equals("Add") || firstWord.Equals("Subtract") || firstWord.Equals("Multiply"))
            {
                return ParseMessageType3(messageArray);
            }
            else if (Regex.IsMatch(firstWord, @"^\d+$"))
            {
                return ParseMessageType2(messageArray);
            }
            else if (messageArray.Length == 3 && messageArray[1].Contains("at"))
            {
                return ParseMessageType1(messageArray);
            }
            else
            {
                Console.WriteLine("Incorrect Message Format");
            }
            return true;
        }
        // Parse message type 1
        private bool ParseMessageType1(string[] messageArray)
        {
            if (messageArray.Length == 3)
            {
                ProductType = messageArray[0];
                ProductPrice = ParsePrice(messageArray[2]);
                ProductQuantity = 1; // Will always be 1
                return true;
            }
            return false;
        }

        // Parse message type 2
        private bool ParseMessageType2(string[] messageArray)
        {
            if (messageArray.Length == 7)
            {
                ProductType = messageArray[3];
                ProductPrice = ParsePrice(messageArray[5]);
                ProductQuantity = Convert.ToInt32(messageArray[0]);
                return true;
            }
            return false;
        }
        // Parse message type 3
        private bool ParseMessageType3(string[] messageArray)
        {
            if (messageArray.Length == 3)
            {
                OperatorType = messageArray[0];
                ProductType = messageArray[2];
                ProductQuantity = 0;
                ProductPrice = ParsePrice(messageArray[1]);
                return true;
            }
            return false;
        }
        // Parse the price and get only the value
        // @return[double] e.g "20p" will become 0.20
        public double ParsePrice(string rawPrice)
        {
            double price = Convert.ToDouble(rawPrice.Replace("p", ""));
            if (!rawPrice.Contains("."))
            {
                price = price / 100;
            }
            return price;
        }
        // Get the product type
        public string GetProductType()
        {
            return ProductType;
        }
        // Get the product price
        public double GetProductPrice()
        {
            return ProductPrice;
        }
        // Get the operator type
        public string GetOperatorType()
        {
            return OperatorType;
        }
        // Get the product quantity
        public int GetProductQuantity()
        {
            return ProductQuantity;
        }
    }
}