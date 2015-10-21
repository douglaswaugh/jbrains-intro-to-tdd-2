using System.Linq;
using NSubstitute;
using NUnit.Framework;

namespace PointOfSale.Tests
{
    [TestFixture]
    public class PointOfSaleTest
    {
        private Screen _screen;
        private Catalogue _catalogue;
        private Till _pointOfSale;

        [SetUp]
        public void SetUp()
        {
            _screen = Substitute.For<Screen>();

            _catalogue = Substitute.For<Catalogue>();

            _pointOfSale = new Till(_screen, _catalogue);
        }

        [Test]
        public void Should_display_price_when_product_is_found()
        {
            _catalogue.GetProduct("12341234").Returns("£9.95");

            _pointOfSale.OnBarcode("12341234");

            _screen.Received(1).Print(Arg.Any<string>());
            _screen.Received(1).Print("£9.95");
        }

        [Test]
        public void Should_display_correct_price_for_different_products()
        {
            _catalogue.GetProduct("56785678").Returns("£20.00");

            _pointOfSale.OnBarcode("56785678");

            _screen.Received(1).Print(Arg.Any<string>());
            _screen.Received().Print("£20.00");
        }

        [Test]
        public void Should_display_not_found_message_if_product_not_found()
        {
            _catalogue.GetProduct(Arg.Any<string>()).Returns(p => null);

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
