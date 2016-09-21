using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace PointOfSale.Tests
{
    [TestFixture]
    public class SellMultipleItemsTest
    {
        private Screen _screen;
        private Dictionary<string, decimal> _products;
        private Till _till;

        [SetUp]
        public void SetUp()
        {
            _screen = Substitute.For<Screen>();
            _products = new Dictionary<string, decimal>();
            var catalogue = new DictionaryCatalogue(_products);
            _till = new Till(
                new Display(_screen),
                catalogue,
                new ListShoppingBasket());
        }

        [Test]
        public void Should_display_no_sale_message_when_no_products_have_been_scanned()
        {
            _till.OnTotal();

            _screen.Received().Print("No sale in progress. Try scanning a product.");
        }

        [Test]
        public void Should_send_basket_total_to_display_on_total()
        {
            _products.Add("1", 6.50m);

            _till.OnBarcode("1");
            _till.OnTotal();

            _screen.Received().Print("Total: £6.50");
        }

        [Test]
        public void Should_process_selling_one_found_product()
        {
            _products.Add("1", 6.50m);

            _till.OnBarcode("1");
            _till.OnTotal();

            _screen.Received().Print("Total: £6.50");
        }
    }
}
