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

            _screen.Received().Print("£9.95");
        }

        [Test]
        public void Should_display_correct_price_for_different_products()
        {
            _catalogue.GetProduct("56785678").Returns("£20.00");

            _pointOfSale.OnBarcode("56785678");

            _screen.Received().Print("£20.00");
        }
    }
}
