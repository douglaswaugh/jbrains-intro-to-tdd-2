using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace PointOfSale.Tests
{
    [TestFixture]
    public class SellMultipleItemsTest
    {
        [Test]
        public void Should_display_no_sale_message_when_no_products_have_been_scanned()
        {
            var screen = Substitute.For<Screen>();
            var till = CreateTill(
                screen,
                AnyCatalogue()
            );

            till.OnTotal();

            screen.Received().Print("No sale in progress. Try scanning a product.");
        }

        [Test]
        public void Should_process_selling_one_found_item()
        {
            var screen = Substitute.For<Screen>();
            var till = CreateTill(
                screen, 
                CatalogueWithItem("123245678", 6.50m)
            );

            till.OnBarcode("123245678");
            till.OnTotal();

            screen.Received().Print("Total: £6.50");
        }

        [Test]
        public void Should_process_selling_one_not_found_item()
        {
            var screen = Substitute.For<Screen>();
            var till = CreateTill(
                screen,
                CatalogueWithoutItem("123245678")
            );

            till.OnBarcode("123245678");
            till.OnTotal();

            screen.Received().Print("No sale in progress. Try scanning a product.");
        }

        [Test]
        public void Should_process_selling_multiple_found_items()
        {
            var screen = Substitute.For<Screen>();
            var till = CreateTill(
                screen, 
                CatalogueWithItems(new Dictionary<string, decimal>
                {
                    {"12341234", 8.50m},
                    {"43214321", 12.75m},
                    {"12121212", 3.30m}
                })
            );

            till.OnBarcode("12341234");
            till.OnBarcode("43214321");
            till.OnBarcode("12121212");
            till.OnTotal();

            screen.Received().Print("Total: £24.55");
        }

        [Test]
        public void Should_process_selling_multiple_not_found_items()
        {
            var screen = Substitute.For<Screen>();
            var till = CreateTill(
                screen,
                CatalogueWithoutItems(
                    "product you won't find",
                    "another product you won't find",
                    "a thrid product you won't find"
                )
            );

            till.OnBarcode("product you won't find");
            till.OnBarcode("another product you won't find");
            till.OnBarcode("a thrid product you won't find");
            till.OnTotal();

            screen.Received().Print("No sale in progress. Try scanning a product.");
        }

        private Till CreateTill(Screen screen, DictionaryCatalogue catalogueWithItem)
        {
            return new Till(
                new Display(screen),
                catalogueWithItem
            );
        }

        private DictionaryCatalogue AnyCatalogue()
        {
            return new DictionaryCatalogue(new Dictionary<string, decimal>());
        }

        private DictionaryCatalogue CatalogueWithItem(string barcode, decimal price)
        {
            var dictionary = new Dictionary<string, decimal>
            {
                {barcode, price}
            };

            return new DictionaryCatalogue(dictionary);
        }

        private DictionaryCatalogue CatalogueWithItems(Dictionary<string, decimal> pricesByBarcode)
        {
            return new DictionaryCatalogue(pricesByBarcode);
        }

        private DictionaryCatalogue CatalogueWithoutItem(string barcode)
        {
            return new DictionaryCatalogue(new Dictionary<string, decimal>());
        }

        private DictionaryCatalogue CatalogueWithoutItems(params string[] products)
        {
            return new DictionaryCatalogue(new Dictionary<string, decimal>());
        }
    }
}
