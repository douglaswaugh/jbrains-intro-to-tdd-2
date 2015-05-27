using NSubstitute;
using NUnit.Framework;

namespace PointOfSale.Tests
{
    [TestFixture]
    public class PointOfSaleTest
    {
        [Test]
        public void Should_display_price_when_product_is_found()
        {
            var screen = Substitute.For<Screen>();

            var pointOfSale = new Till(screen);

            pointOfSale.OnBarcode("12341234");

            screen.Received().Print("£9.95");
        }
    }
}
