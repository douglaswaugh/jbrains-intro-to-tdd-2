using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace PointOfSale.Tests
{
    [TestFixture]
    public class TillOnTotalTests
    {
        private Screen _screen;
        private Till _till;
        private ShoppingBasket _shoppingBasket;

        [SetUp]
        public void SetUp()
        {
            _screen = Substitute.For<Screen>();
            _shoppingBasket = Substitute.For<ShoppingBasket>();
            _till = new Till(
                new ScreenDisplay(_screen),
                new DictionaryCatalogue(new Dictionary<string, decimal>()),
                _shoppingBasket);
        }

        [Test]
        public void Should_display_no_sale_message_when_no_products_have_been_scanned()
        {
            _shoppingBasket.Empty.Returns(true);

            _till.OnTotal();

            _screen.Received().Print("No sale in progress. Try scanning a product.");
        }

        [Test]
        public void Should_send_basket_total_to_display_on_total()
        {
            _shoppingBasket.Empty.Returns(false);
            _shoppingBasket.Total.Returns(6.50m);

            _till.OnTotal();

            _screen.Received().Print("Total: £6.50");
        }
    }
}
