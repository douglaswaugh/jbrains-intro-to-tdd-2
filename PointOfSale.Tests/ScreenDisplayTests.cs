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
    }
}
