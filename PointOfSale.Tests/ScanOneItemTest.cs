using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace PointOfSale.Tests
{
    [TestFixture]
    public class ScanOneItemTest
    {
        private Screen _screen;
        private Till _pointOfSale;

        [SetUp]
        public void SetUp()
        {
            _screen = Substitute.For<Screen>();

            var display = new ScreenDisplay(_screen);
            var pricesByBarcode = new Dictionary<string, decimal>
            {
                { "12341234", 9.95m },
                { "56785678", 20.00m }
            };
            var dictionaryCatalogue = new DictionaryCatalogue(pricesByBarcode);

            _pointOfSale = new Till(display, dictionaryCatalogue, new ListShoppingBasket());
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
            _pointOfSale = new Till(new ScreenDisplay(_screen), new DictionaryCatalogue(null), new ListShoppingBasket());

            _pointOfSale.OnBarcode(string.Empty);

            _screen.Received(1).Print(Arg.Any<string>());
            _screen.Received().Print("Barcode empty");
        }

        [Test]
        public void Should_add_found_product_to_shopping_list()
        {
            var shoppingBasket = Substitute.For<ShoppingBasket>();
            var pointOfSale = new Till(
                new ScreenDisplay(_screen), 
                new DictionaryCatalogue(
                    new Dictionary<string, decimal>
                    {
                        { "1", 6.23m }
                    }), 
                shoppingBasket
            );

            pointOfSale.OnBarcode("1");

            shoppingBasket.Received().AddProduct(new KeyValuePair<string, decimal>("1", 6.23m));
        }

        [Test]
        public void Should_not_add_product_to_shopping_list_if_product_not_found()
        {
            var shoppingBasket = Substitute.For<ShoppingBasket>();
            var pointOfSale = new Till(
                new ScreenDisplay(_screen),
                new DictionaryCatalogue(new Dictionary<string, decimal>()),
                shoppingBasket
            );

            pointOfSale.OnBarcode("1");

            shoppingBasket.DidNotReceive().AddProduct(Arg.Any<KeyValuePair<string, decimal>>());
        }

        [Test]
        public void Should_not_add_product_to_shopping_list_if_barcode_empty()
        {
            var shoppingBasket = Substitute.For<ShoppingBasket>();
            var pointOfSale = new Till(
                new ScreenDisplay(_screen),
                new DictionaryCatalogue(new Dictionary<string, decimal>()),
                shoppingBasket
            );

            pointOfSale.OnBarcode(string.Empty);

            shoppingBasket.DidNotReceive().AddProduct(Arg.Any<KeyValuePair<string, decimal>>());
        }
    }
}
