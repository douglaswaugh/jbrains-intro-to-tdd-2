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
            var till = new Till(new Display(screen), null);

            till.OnTotal();

            screen.Received().Print("No sale in progress. Try scanning a product.");
        }

        [Test]
        public void Should_process_selling_one_found_item()
        {
            var screen = Substitute.For<Screen>();
            var pricesByBarcode = new Dictionary<string, string>
            {
                {"123245678", "£6.50"}
            };
            var catalogue = new DictionaryCatalogue(pricesByBarcode);
            var till = new Till(new Display(screen), catalogue);

            till.OnBarcode("123245678");
            till.OnTotal();

            screen.Received().Print("Total: £6.50");
        }
    }
}
