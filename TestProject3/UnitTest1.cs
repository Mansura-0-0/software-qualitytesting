using NUnit.Framework;

using Moq;
using Project;
namespace TestProject3
{
    public class Tests
    {
        private Mock<IDiscountService> _mockDiscount;
        private ParkingService _service;
        [SetUp]
        public void Setup()
        {
            _mockDiscount = new Mock<IDiscountService>();
            _mockDiscount.Setup(d => d.GetDiscount()).Returns(1.0); 

            _service = new ParkingService(_mockDiscount.Object);

        }

        //STANDARD VEHICLE TESTS

        [Test]
        public void Standard_2Hours_Returns8()
        {
            var result = _service.CalculateFee(2, "standard");
            Assert.That(result, Is.EqualTo(8));
        }

        [Test]
        public void Standard_4Hours_Returns12()
        {
            var result = _service.CalculateFee(4, "standard");
            Assert.That(result, Is.EqualTo(12));
        }

        [Test]
        public void Standard_0Hours_Returns0()
        {
            var result = _service.CalculateFee(0, "standard");
            Assert.That(result, Is.EqualTo(0));
        }

        // BUG TEST (3 hours should be €12 but codee will fail)
        [Test]
        public void Standard_3Hours_BugTest()
        {
            var result = _service.CalculateFee(3, "standard");
            Assert.That(result, Is.EqualTo(12)); // this will FAIL (good for assignment)
        }

        // ELECTRIC VEHICLE TESTS

        [Test]
        public void Electric_3Hours_Returns9()
        {
            var result = _service.CalculateFee(3, "electric");
            Assert.That(result, Is.EqualTo(9));
        }

        [Test]
        public void Electric_6Hours_Returns12()
        {
            var result = _service.CalculateFee(6, "electric");
            Assert.That(result, Is.EqualTo(12));
        }

        [Test]
        public void Electric_0Hours_Returns0()
        {
            var result = _service.CalculateFee(0, "electric");
            Assert.That(result, Is.EqualTo(0));
        }

        //INVELID VEHICLE

        [Test]
        public void InvalidVehicle_Returns0()
        {
            var result = _service.CalculateFee(5, "truck");
            Assert.That(result, Is.EqualTo(0));
        }

            // CASE SENSITIVITY BUG
            [Test]
        public void Standard_CapitalS_BugTest()
        {
            var result = _service.CalculateFee(2, "Standard");
            Assert.That(result, Is.EqualTo(8)); // will FAIL
        }

        // DISCOUNT TEST

        [Test]
        public void Discount_Applied_WhenHoursAbove10()
        {
            _mockDiscount.Setup(d => d.GetDiscount()).Returns(0.5);

            var result = _service.CalculateFee(10, "standard");

            Assert.That(result, Is.EqualTo(10 * 3 * 0.5));
        }
    }
}