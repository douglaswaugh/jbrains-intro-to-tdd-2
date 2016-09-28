using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace PointOfSale.Tests
{
    [TestFixture]
    public class ScanOneItemTest
    {
        [Test]
        public void Should_display_price_when_product_is_found()
        {
            var display = Substitute.For<Display>();
            var basket = Substitute.For<ShoppingBasket>();
            var catalogue = new DictionaryCatalogue(new Dictionary<string, decimal>
            {
                { "12341234", 9.95m }
            });

            var till = new Till(display, catalogue, basket);

            till.OnBarcode("12341234");

            display.Received().DisplayPrice(9.95m);
            basket.Received().AddProduct(NewProduct("12341234", 9.95m));
        }

        [Test]
        public void Should_display_correct_price_for_different_products()
        {
            var display = Substitute.For<Display>();
            var basket = Substitute.For<ShoppingBasket>();
            var catalogue = new DictionaryCatalogue(new Dictionary<string, decimal>
            {
                { "12341234", 9.95m },
                { "56785678", 20.00m }
            });

            var till = new Till(display, catalogue, basket);

            till.OnBarcode("56785678");

            display.Received().DisplayPrice(20.00m);
            basket.Received().AddProduct(NewProduct("56785678", 20.00m));
        }

        [Test]
        public void Should_display_not_found_message_if_product_not_found()
        {
            var display = Substitute.For<Display>();
            var basket = Substitute.For<ShoppingBasket>();
            var catalogue = new DictionaryCatalogue(new Dictionary<string, decimal>
            {
                { "12341234", 9.95m }
            });

            var till = new Till(display, catalogue, basket);

            till.OnBarcode("99999999");

            display.Received().DisplayProductNotFoundMessage("99999999");
        }

        [Test]
        public void Should_dispaly_empty_barcode_error()
        {
            var display = Substitute.For<Display>();
            var basket = Substitute.For<ShoppingBasket>();
            var catalogue = new DictionaryCatalogue(new Dictionary<string, decimal>
            {
                { "12341234", 9.95m }
            });

            var till = new Till(display, catalogue, basket);

            till.OnBarcode(string.Empty);

            display.Received().DisplayEmptyBarcodeMessage();
        }

        [Test]
        public void Should_not_add_product_to_shopping_list_if_product_not_found()
        {
            var display = Substitute.For<Display>();
            var shoppingBasket = Substitute.For<ShoppingBasket>();
            var pointOfSale = new Till(
                display,
                new DictionaryCatalogue(new Dictionary<string, decimal>()),
                shoppingBasket
            );

            pointOfSale.OnBarcode("1");

            shoppingBasket.DidNotReceive().AddProduct(Arg.Any<Product>());
        }

        [Test]
        public void Should_not_add_product_to_shopping_list_if_barcode_empty()
        {
            var display = Substitute.For<Display>();
            var shoppingBasket = Substitute.For<ShoppingBasket>();
            var pointOfSale = new Till(
                display,
                new DictionaryCatalogue(new Dictionary<string, decimal>()),
                shoppingBasket
            );

            pointOfSale.OnBarcode(string.Empty);

            shoppingBasket.DidNotReceive().AddProduct(Arg.Any<Product>());
        }

        private static Product NewProduct(string barcode, decimal price)
        {
            return new Product(barcode, price);
        }
    }
}
