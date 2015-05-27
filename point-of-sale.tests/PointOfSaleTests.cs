using System;
using NUnit.Framework;

namespace point_of_sale.tests
{
    [TestFixture]
    public class PointOfSaleTests
    {
        [Test]
        public void Should_display_price_when_product_is_found()
        {
            string sendToScreen = String.Empty;

            var pointOfSale = new PointOfSale(sendToScreen);

            pointOfSale.OnBarcode("12341234");

            Assert.That(sendToScreen, Is.EqualTo("£9.95"));
        }
    }

    public class PointOfSale
    {
        public PointOfSale(string screen)
        {
        }

        public void OnBarcode(string barcode)
        {
        }
    }
}
