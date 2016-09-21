using NSubstitute;
using NUnit.Framework;

namespace PointOfSale.Tests
{
    [TestFixture]
    public class TillOnTotalTests
    {
        private Till _till;
        private ShoppingBasket _shoppingBasket;
        private Display _display;

        [SetUp]
        public void SetUp()
        {
            _display = Substitute.For<Display>();
            _shoppingBasket = Substitute.For<ShoppingBasket>();
            _till = new Till(
                _display,
                null, // SMELL constructor parameter not needed in tests
                _shoppingBasket);
        }

        [Test]
        public void Should_display_no_sale_message_when_no_products_have_been_scanned()
        {
            _shoppingBasket.Empty.Returns(true);

            _till.OnTotal();

            _display.Received().DisplayNoSaleInProgressMessage();
        }

        [Test]
        public void Should_send_basket_total_to_display_on_total()
        {
            _shoppingBasket.Empty.Returns(false);
            _shoppingBasket.Total.Returns(6.50m);

            _till.OnTotal();

            _display.Received().DisplayTotal(6.50m);
        }
    }
}
