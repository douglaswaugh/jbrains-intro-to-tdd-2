using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace PointOfSale.Tests
{
    [TestFixture]
    public class TillTests
    {
        [Test]
        public void Should_display_price_when_product_is_found()
        {
            var display = Substitute.For<Display>();
            var catalogue = DictionaryCatalogueWithProduct("1", 9.95m);
            var shoppingBasket = new ShoppingBasket();

            var till = new Till(display, catalogue, shoppingBasket);

            till.OnBarcode("1");

            display.Received().DisplayPrice(9.95m);
        }

        [Test]
        public void Should_display_correct_price_for_different_products()
        {
            var display = Substitute.For<Display>();
            var catalogue = DictionaryCatalogue(new Dictionary<string, decimal>
            {
                { "1", 9.95m },
                { "2", 20.00m }
            });

            var till = new Till(display, catalogue, new ShoppingBasket());

            till.OnBarcode("2");

            display.Received().DisplayPrice(20.00m);
        }

        [Test]
        public void Should_display_not_found_message_if_product_not_found()
        {
            var display = Substitute.For<Display>();
            var catalogue = DictionaryCatalogueWithoutProduct("product not found barcode");
            var shoppingBasket = new ShoppingBasket();

            var till = new Till(display, catalogue, shoppingBasket);

            till.OnBarcode("product not found barcode");

            display.Received().DisplayProductNotFoundMessage("product not found barcode");
        }

        [Test]
        public void Should_dispaly_empty_barcode_error()
        {
            var display = Substitute.For<Display>();
            var catalogue = DictionaryCatalogueWithProduct(string.Empty, 9.95m);
            var shoppingBasket = new ShoppingBasket();

            var till = new Till(display, catalogue, shoppingBasket);

            till.OnBarcode(string.Empty);

            display.Received().DisplayEmptyBarcodeMessage();
        }

        [Test]
        public void Should_display_no_sale_message_when_no_products_have_been_scanned()
        {
            var display = Substitute.For<Display>();
            var catalogue = AnyDictionaryCatalogue();
            var shoppingBasket = new ShoppingBasket();

            var till = new Till(display, catalogue, shoppingBasket);

            till.OnTotal();

            display.Received().DisplayNoSaleInProgressMessage();
        }

        [Test]
        public void Should_send_basket_total_to_display_on_total()
        {
            var display = Substitute.For<Display>();
            var catalogue = DictionaryCatalogueWithProduct("1", 6.50m);
            var shoppingBasket = new ShoppingBasket();

            var till = new Till(display, catalogue, shoppingBasket);

            till.OnBarcode("1");
            till.OnTotal();

            display.Received().DisplayTotal(6.50m);
        }

        private static DictionaryCatalogue AnyDictionaryCatalogue()
        {
            return EmptyDictionaryCatalogue();
        }

        private static DictionaryCatalogue DictionaryCatalogueWithProduct(string barcode, decimal price)
        {
            return DictionaryCatalogue(new Dictionary<string, decimal> { { barcode, price } });
        }

        private static DictionaryCatalogue DictionaryCatalogueWithoutProduct(string barcode)
        {
            var dictionary = new Dictionary<string, decimal>();
            dictionary.Remove(barcode);
            return DictionaryCatalogue(dictionary);
        }

        private static DictionaryCatalogue EmptyDictionaryCatalogue()
        {
            return DictionaryCatalogue(new Dictionary<string, decimal>());
        }

        private static DictionaryCatalogue DictionaryCatalogue(Dictionary<string, decimal> dictionary)
        {
            return new DictionaryCatalogue(dictionary);
        }
    }
}
