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

        [Test]
        public void Should_display_correct_price_for_different_products()
        {
            var screen = Substitute.For<Screen>();

            var pointOfSale = new Till(screen);

            pointOfSale.OnBarcode("56785678");

            screen.Received().Print("£20.00");
        }
    }
}
