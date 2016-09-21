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
                catalogue
                );
        }

        [Test]
        public void Should_display_no_sale_message_when_no_products_have_been_scanned()
        {
            _till.OnTotal();

            _screen.Received().Print("No sale in progress. Try scanning a product.");
        }

        [Test]
        public void Should_process_selling_one_found_product()
        {
            _products.Add("1", 6.50m);

            _till.OnBarcode("1");
            _till.OnTotal();

            _screen.Received().Print("Total: £6.50");
        }

        [Test]
        public void Should_process_selling_one_not_found_products()
        {
            _products.Remove("product you won't find");

            _till.OnBarcode("product you won't find");
            _till.OnTotal();

            _screen.Received().Print("No sale in progress. Try scanning a product.");
        }

        [Test]
        public void Should_process_selling_multiple_found_products()
        {
            _products.Add("1", 8.50m);
            _products.Add("2", 12.75m);
            _products.Add("3", 3.30m);

            _till.OnBarcode("1");
            _till.OnBarcode("2");
            _till.OnBarcode("3");
            _till.OnTotal();

            _screen.Received().Print("Total: £24.55");
        }

        [Test]
        public void Should_process_selling_multiple_not_found_products()
        {
            _products.Remove("product you won't find");
            _products.Remove("another product you won't find");
            _products.Remove("a thrid product you won't find");

            _till.OnBarcode("product you won't find");
            _till.OnBarcode("another product you won't find");
            _till.OnBarcode("a thrid product you won't find");
            _till.OnTotal();

            _screen.Received().Print("No sale in progress. Try scanning a product.");
        }
    }
}
