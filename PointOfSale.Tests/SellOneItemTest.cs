using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace PointOfSale.Tests
{
    [TestFixture]
    public class SellOneItemTest
    {
        private Screen _screen;
        private Till _pointOfSale;

        [SetUp]
        public void SetUp()
        {
            _screen = Substitute.For<Screen>();

            var display = new Display(_screen);
            var pricesByBarcode = new Dictionary<string, string>
            {
                { "12341234", "£9.95" },
                { "56785678", "£20.00" }
            };
            var dictionaryCatalogue = new DictionaryCatalogue(pricesByBarcode);

            _pointOfSale = new Till(display, dictionaryCatalogue);
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
            _pointOfSale.OnBarcode("99999999");
            
            _screen.Received(1).Print(Arg.Any<string>());
            _screen.Received().Print("Product not found for 99999999");
        }

        [Test]
        public void Should_dispaly_empty_barcode_error()
        {
            _pointOfSale = new Till(new Display(_screen), new DictionaryCatalogue(null));

            _pointOfSale.OnBarcode(string.Empty);

            _screen.Received(1).Print(Arg.Any<string>());
            _screen.Received().Print("Barcode empty");
        }
    }
}
