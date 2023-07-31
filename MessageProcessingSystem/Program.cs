using MessageProcessingSystem.MessageProcessor;
using System;
using System.IO;
namespace MessageProcessingSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SaleProcessor saleProcessor = new SaleProcessor();
            try
            {
                string line = "";
                // Attached a test data file in the project. We assume that we'll receive this file from third party
                using (var reader = new StreamReader("TestData.txt"))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        //process sales message line by line
                        saleProcessor.ProcessSalesMessage(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Message: {ex.Message} StackTrace: {ex.StackTrace}");
            }
            
        }
    }
}