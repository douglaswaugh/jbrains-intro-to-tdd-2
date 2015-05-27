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
        public void Should_display_product_not_found_error_if_barcode_not_known()
        {
            var screen = Substitute.For<Screen>();

            var pointOfSale = new Till(screen);

            pointOfSale.OnBarcode("00000000");

            screen.Received().Print("Error: Product not found");
        }
    }
}
