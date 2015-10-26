using NSubstitute;
using NUnit.Framework;

namespace PointOfSale.Tests
{
    [TestFixture]
    public class PointOfSaleTest
    {
        private Screen _screen;
        private Till _pointOfSale;

        [SetUp]
        public void SetUp()
        {
            _screen = Substitute.For<Screen>();

            _pointOfSale = new Till(_screen);
        }

        [Test]
        public void Should_display_price_when_product_is_found()
        {
            _pointOfSale.OnBarcode("12341234");

            _screen.Received(1).Print(Arg.Any<string>());
            _screen.Received(1).Print("£9.95");
        }

        [Test]
        public void Should_display_correct_price_for_different_products()
        {
            _pointOfSale.OnBarcode("56785678");

            _screen.Received(1).Print(Arg.Any<string>());
            _screen.Received().Print("£20.00");
        }

        [Test]
        public void Should_display_not_found_message_if_product_not_found()
        {
            _pointOfSale.OnBarcode("43214321");
            
            _screen.Received(1).Print(Arg.Any<string>());
            _screen.Received().Print("Product not found");
        }

        [Test]
        public void Should_display_null_barcode_error()
        {
            _pointOfSale.OnBarcode(null);
            
            _screen.Received(1).Print(Arg.Any<string>());
            _screen.Received().Print("Barcode null");
        }

        [Test]
        public void Should_dispaly_empty_barcode_error()
        {
            _pointOfSale.OnBarcode(string.Empty);

            _screen.Received(1).Print(Arg.Any<string>());
            _screen.Received().Print("Barcode empty");
        }
    }
}
