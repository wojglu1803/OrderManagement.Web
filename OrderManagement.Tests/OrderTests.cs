using NUnit.Framework;
using OrderManagement.Data.Models;

namespace OrderManagement.Tests
{
    [TestFixture]
    public class OrderTests
    {
        [Test]
        public void Order_ShouldHaveCorrectProperties_WhenInitialized()
        {
            // Arrange
            var orderDate = new DateTime(2025, 1, 29);
            var customerId = 1;

            // Act
            var order = new Order
            {
                OrderDate = orderDate,
                CustomerId = customerId
            };

            // Assert
            Assert.AreEqual(orderDate, order.OrderDate);
            Assert.AreEqual(customerId, order.CustomerId);
            Assert.IsNotNull(order.OrderProducts); // Lista produktów powinna być zainicjalizowana
        }
    }
}
