using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WDIUnitTests.Fibonacci;

namespace WDIUnitTests.MSUnit
{
    [TestClass]
    public class IdGeneratorTests
    {
        private IdGenerator _idGenerator;
        private Mock<IFibonacciGenerator> _fibonacciGenerator;

        [TestInitialize]
        public void TestInitialie()
        {
            _fibonacciGenerator = new Mock<IFibonacciGenerator>();
            _idGenerator = new IdGenerator(_fibonacciGenerator.Object);
        }

        [TestMethod]
        public void TestThat_Generate_CreatesValidIds()
        {
            // Arrange
            _fibonacciGenerator.Setup(s => s.GetNext()).Returns(1);

            // Act
            var id = _idGenerator.GenerateId();

            // Assert
            Assert.AreEqual("code-1", id);
            id.Should().Be("code-1");
        }

        [TestCategory("Unique")]
        [TestCategory("Sequential")]
        [TestMethod]
        public void TestThat_Generate_CreatesUniqueIds()
        {
            // Arrange
            _fibonacciGenerator.SetupSequence(s => s.GetNext())
                .Returns(1)
                .Returns(1)
                .Returns(2); ;

            // Act
            var id1 = _idGenerator.GenerateId();
            var id2 = _idGenerator.GenerateId();
            var id3 = _idGenerator.GenerateId();

            // Assert
            id1.Should().Be("code-1");
            id2.Should().Be("code-1");
            id3.Should().Be("code-2");
        }
    }
}