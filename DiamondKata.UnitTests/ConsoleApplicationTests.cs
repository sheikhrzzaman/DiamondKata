using DiamondKata.Services;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DiamondKata.UnitTests
{
    [TestClass]
    public class ConsoleApplicationTests
    {
        private Mock<IValidator<string>> _mockValidator;
        private Mock<ILogger<ConsoleApplication>> _mockLogger;
        private Mock<IDiamondService> _mockDiamondService;

        private IConsoleApplication _sut;

        [TestInitialize]
        public void TestInit()
        {
            _mockValidator = new Mock<IValidator<string>>();
            _mockValidator
                .Setup(x => x.Validate(It.IsAny<string>()))
                .Returns(new ValidationResult());
            _mockLogger = new Mock<ILogger<ConsoleApplication>>();
            _mockDiamondService = new Mock<IDiamondService>();

            var diamond = new string[] { "A" };
            _mockDiamondService
                .Setup(x => x.GetDiamond(It.IsAny<char>()))
                .Returns(diamond);

            _sut = new ConsoleApplication(
                _mockValidator.Object,
                _mockLogger.Object,
                _mockDiamondService.Object);
        }

        [TestMethod]
        public void Run_WhenValidationFails_ThenDiamondServiceNotCalled()
        {
            // Arrange
            char inputChar = 'C';

            var errorMessage = "Invalid character";
            var validationResults = new ValidationResult();
            validationResults.Errors.Add(new ValidationFailure("Invalid", errorMessage));

            _mockValidator.Reset();
            _mockValidator
                .Setup(x => x.Validate(It.IsAny<string>()))
                .Returns(validationResults);

            // Act
            _sut.Run(inputChar);

            // Assert
            _mockDiamondService.Verify(x => x.GetDiamond(It.IsAny<char>()), Times.Never);
        }

        [TestMethod]
        public void Run_WhenValidationPass_ThenDiamondServiceIsCalled()
        {
            // Arrange
            char inputChar = 'C';

            // Act
            _sut.Run(inputChar);

            // Assert
            _mockDiamondService.Verify(x => x.GetDiamond(inputChar), Times.Once);
        }
    }
}
