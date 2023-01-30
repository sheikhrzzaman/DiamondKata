using DiamondKata.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiamondKata.UnitTests.Services
{
    [TestClass]
    public class LetterNumberServiceTests
    {
        [TestMethod]
        [DataRow('A', 0)]
        [DataRow('B', 1)]
        [DataRow('C', 2)]
        [DataRow('M', 12)]
        [DataRow('Z', 25)]
        public void GetLetterNumber_ThenReturnCorrectNumber(char letter, int letterNumber)
        {
            // Arrange
            var sut = new LetterNumberService();

            // Act
            var result = sut.GetLetterNumber(letter);

            // Assert
            Assert.AreEqual(letterNumber, result);
        }
    }
}
