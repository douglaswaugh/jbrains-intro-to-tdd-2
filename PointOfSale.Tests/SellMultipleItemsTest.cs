using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace PointOfSale.Tests
{
    [TestFixture]
    public class SellMultipleItemsTest
    {
        private Screen _screen;
        private Till _till;
        private Dictionary<string, decimal> _pricesByBarcode;

        [SetUp]
        public void SetUp()
        {
            _screen = Substitute.For<Screen>();
            _pricesByBarcode = new Dictionary<string, decimal>();
            _till = new Till(
                new Display(_screen), 
                new DictionaryCatalogue(_pricesByBarcode));
        }

        [Test]
        public void Should_display_no_sale_message_when_no_products_have_been_scanned()
        {
            _till.OnTotal();

            _screen.Received().Print("No sale in progress. Try scanning a product.");
        }

        [Test]
        public void Should_process_selling_one_found_item()
        {
            _pricesByBarcode.Add("123245678", 6.50m);

            _till.OnBarcode("123245678");
            _till.OnTotal();

            _screen.Received().Print("Total: £6.50");
        }

        [Test]
        public void Should_process_selling_one_not_found_item()
        {
            _till.OnBarcode("123245678");
            _till.OnTotal();

            _screen.Received().Print("No sale in progress. Try scanning a product.");
        }
    }
}
