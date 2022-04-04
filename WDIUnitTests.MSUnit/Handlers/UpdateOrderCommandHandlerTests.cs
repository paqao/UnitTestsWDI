using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDIUnitTests.Clients;
using WDIUnitTests.DatabaseLayer.Data;
using WDIUnitTests.Handlers;
using WDIUnitTests.Repository;

namespace WDIUnitTests.MSUnit.Handlers
{
    [TestClass]
    internal class UpdateOrderCommandHandlerTests
    {
        private UpdateOrderCommandHandler _updateOrderCommandHandler;
        private Mock<ISalesApiClient> _salesApiClient;
        private Mock<IDataRepository<Order>> _orderDataRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            _salesApiClient = new Mock<ISalesApiClient>();
            _orderDataRepository = new Mock<IDataRepository<Order>>();
            _updateOrderCommandHandler = new UpdateOrderCommandHandler(_salesApiClient.Object, _orderDataRepository.Object);
        }

        [TestMethod]
        public async Task TestThat_CallToDbIsMade()
        {
            // Arrange
            var command = new UpdateOrderCommand
            {
                Id = "1"
            };
            _orderDataRepository.Setup(s => s.GetByIdAsync("1"))
                .ReturnsAsync((Order?)null);

            // Act
            var exception = await Assert.ThrowsExceptionAsync<Exception>(() => _updateOrderCommandHandler.HandleAsync(command));

            // Assert
            Assert.AreEqual("Not found order", exception.Message);
            _orderDataRepository.Verify(x => x.GetByIdAsync("1"), Times.Once());
        }

        [TestMethod]
        public async Task TestThat_CorrectOrderIsSentThroughClient()
        {
            // Arrange
            var command = new UpdateOrderCommand
            {
                Id = "1",
                CompletedStatus = true
            };
            var order = new Order("1", 15.0f, false);

            _orderDataRepository.Setup(s => s.GetByIdAsync("1"))
                .ReturnsAsync(order)
                .Verifiable();
            Order? orderData = default;
            _salesApiClient.Setup(s => s.UpdateAsync(It.IsAny<Order>()))
                .Callback<Order>(o => orderData = o);

            // Act
            await _updateOrderCommandHandler.HandleAsync(command);

            // Assert
            Assert.AreEqual(true, orderData.IsCompleted);
            Assert.AreEqual("1", orderData.Id);
            Assert.AreEqual(15.0f, orderData.Amount);
            _orderDataRepository.VerifyAll();
            _orderDataRepository.VerifyNoOtherCalls();
        }
    }
}
