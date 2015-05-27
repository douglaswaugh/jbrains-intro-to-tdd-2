using NSubstitute;
using NUnit.Framework;
using PointOfSale;

namespace point_of_sale.tests
{
    [TestFixture]
    public class PointOfSaleTests
    {
        [Test]
        public void Should_display_price_when_product_is_found()
        {
            var screen = Substitute.For<Screen>();

            var pointOfSale = new PointOfSale.PointOfSale(screen);

            pointOfSale.OnBarcode("12341234");

            screen.Received().Print("£9.95");
        }
    }
}
