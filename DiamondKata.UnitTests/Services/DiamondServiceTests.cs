using DiamondKata.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DiamondKata.UnitTests.Services
{
    [TestClass]
    public class DiamondServiceTests
    {
        private IDiamondService _sut;

        private Mock<ILetterNumberService> _mockLetterNumberService;

        [TestInitialize]
        public void TestInit()
        {
            _mockLetterNumberService = new Mock<ILetterNumberService>();
            _sut = new DiamondService(_mockLetterNumberService.Object);
        }

        [TestMethod]
        [DataRow('A', 0, 1)]
        [DataRow('B', 1, 3)]
        [DataRow('C', 2, 5)]
        [DataRow('M', 12, 25)]
        [DataRow('Z', 25, 51)]
        public void GetDiamond_ThenCorrectDiamondLength(char inputChar, int letterNumber, int expectedDiamondLength)
        {
            // Arrange
            _mockLetterNumberService
                .Setup(x => x.GetLetterNumber(inputChar))
                .Returns(letterNumber);

            // Act
            var diamond = _sut.GetDiamond(inputChar);

            // Assert
            Assert.AreEqual(expectedDiamondLength, diamond.Length);
        }

        [TestMethod]
        [DataRow(1, 1)]
        [DataRow(2, 3)]
        [DataRow(3, 5)]
        [DataRow(4, 7)]
        public void GetDiamond_ThenCorrectSpacesBetweenLetters(int letterNumber, int expectedNumberOfSpaces)
        {
            // Arrange
            var inputChar = 'Z';
            _mockLetterNumberService
                .Setup(x => x.GetLetterNumber(inputChar))
                .Returns(25);

            // Act
            var diamond = _sut.GetDiamond(inputChar);

            // Assert
            Assert.AreEqual(expectedNumberOfSpaces, diamond[letterNumber].Trim().Length - 2);
        }

        [TestMethod]
        [DataRow(0, "A")]
        [DataRow(1, "B B")]
        [DataRow(2, "C   C")]
        [DataRow(48, "C   C")]
        [DataRow(49, "B B")]
        [DataRow(50, "A")]
        public void GetDiamond_ThenCorrectLetterInDiamondSequence(int rowNumber, string expectedValue)
        {
            // Arrange
            var inputChar = 'Z';
            _mockLetterNumberService
                .Setup(x => x.GetLetterNumber(inputChar))
                .Returns(25);

            // Act
            var diamond = _sut.GetDiamond(inputChar);

            // Assert
            Assert.AreEqual(expectedValue, diamond[rowNumber].Trim());
        }

        [TestMethod]
        [DataRow('A', 0, 2)]
        [DataRow('A', 4, 2)]
        [DataRow('B', 1, 1)]
        [DataRow('B', 3, 1)]
        [DataRow('C', 2, 0)]
        public void GetDiamond_ThenCorrectStartingLetterPositionInDiamondSequence(
            char charcter,
            int rowNumber,
            int expectedStartPosition)
        {
            // Arrange
            var inputChar = 'C';
            var inputLetterNumber = 2;
            _mockLetterNumberService
                .Setup(x => x.GetLetterNumber(inputChar))
                .Returns(inputLetterNumber);

            // Act
            var diamond = _sut.GetDiamond(inputChar);

            // Assert
            int characterStartPosition = diamond[rowNumber].IndexOf(charcter);
            Assert.AreEqual(expectedStartPosition, characterStartPosition);
        }

        [TestMethod]
        public void GetDiamond_ThenLetterNumberServiceIsCalled()
        {
            // Arrange
            var inputChar = 'C';
            var inputLetterNumber = 2;
            _mockLetterNumberService
                .Setup(x => x.GetLetterNumber(inputChar))
                .Returns(inputLetterNumber);

            // Act
            var diamond = _sut.GetDiamond(inputChar);

            // Assert
            _mockLetterNumberService
                   .Verify(x => x.GetLetterNumber(inputChar), Times.Once);
        }
    }
}
