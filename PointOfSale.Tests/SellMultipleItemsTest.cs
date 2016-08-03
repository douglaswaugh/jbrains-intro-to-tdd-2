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
    }
}
