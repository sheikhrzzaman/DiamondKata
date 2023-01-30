using DiamondKata.Validations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiamondKata.UnitTests.Validations
{
    [TestClass]
    public class PrintDiamondValidatorTests
    {
        private PrintDiamondValidator _sut;

        [TestInitialize]
        public void TestInit()
        {
            _sut = new PrintDiamondValidator();
        }

        [TestMethod]
        [DataRow("A")]
        [DataRow("B")]
        [DataRow("C")]
        [DataRow("D")]
        [DataRow("E")]
        [DataRow("F")]
        [DataRow("G")]
        [DataRow("H")]
        [DataRow("I")]
        [DataRow("J")]
        [DataRow("K")]
        [DataRow("L")]
        [DataRow("M")]
        [DataRow("N")]
        [DataRow("O")]
        [DataRow("P")]
        [DataRow("Q")]
        [DataRow("R")]
        [DataRow("S")]
        [DataRow("T")]
        [DataRow("U")]
        [DataRow("V")]
        [DataRow("W")]
        [DataRow("X")]
        [DataRow("Y")]
        [DataRow("Z")]
        public void WhenRequestIsValid_ThenValidIsTrue(string request)
        {
            // Arrange

            // Act
            var result = _sut.Validate(request);

            // Assert
            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        [DataRow("aa")]
        [DataRow("BB")]
        [DataRow("1")]
        [DataRow("1b")]
        [DataRow(" ")]
        [DataRow("$")]
        public void WhenRequestIsInvalid_ThenValidIsFalse(string request)
        {
            // Arrange

            // Act
            var result = _sut.Validate(request);

            // Assert
            Assert.IsFalse(result.IsValid);
        }
    }
}
