using CabInvoicegenerator;

namespace CabinInvoicegeneratorTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            InvoiceGenerator invoice = new InvoiceGenerator(RideType.Normal);
            double distance = 12.0;
            int time = 10;

            double fare=invoice.CalculateFare(distance,time);
            double expected = 130;


            Assert.AreEqual(expected, fare);
        }
    }
}