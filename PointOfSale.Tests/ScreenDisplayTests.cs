using NSubstitute;
using NUnit.Framework;

namespace PointOfSale.Tests
{
    [TestFixture]
    public class ScreenDisplayTests
    {
        [Test]
        public void Should_display_price_on_screen()
        {
            var screen = Substitute.For<Screen>();
            var display = new ScreenDisplay(screen);

            display.DisplayPrice(3.50m);

            screen.Received().Print("£3.50");
        }

        [Test]
        public void Should_display_product_not_found_message_on_screen()
        {
            var screen = Substitute.For<Screen>();
            var display = new ScreenDisplay(screen);

            display.DisplayProductNotFoundMessage("not found product barcode");

            screen.Received().Print("Product not found for not found product barcode");
        }

        [Test]
        public void Should_display_empty_barcode_message_on_screen()
        {
            var screen = Substitute.For<Screen>();
            var display = new ScreenDisplay(screen);

            display.DisplayEmptyBarcodeMessage();

            screen.Received().Print("Barcode empty");
        }

        [Test]
        public void Should_display_no_sale_in_progress_message_on_screen()
        {
            var screen = Substitute.For<Screen>();
            var display = new ScreenDisplay(screen);

            display.DisplayNoSaleInProgressMessage();

            screen.Received().Print("No sale in progress. Try scanning a product.");
        }
    }
}
