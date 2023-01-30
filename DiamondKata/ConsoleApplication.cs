using System;
using System.Linq;
using DiamondKata.Services;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace DiamondKata
{
    public class ConsoleApplication : IConsoleApplication
    {
        private readonly IValidator<string> _validator;
        private readonly ILogger _logger;
        private readonly IDiamondService _diamondService;

        public ConsoleApplication(
            IValidator<string> validator,
            ILogger<ConsoleApplication> logger,
            IDiamondService diamondService)
        {
            _validator = validator;
            _logger = logger;
            _diamondService = diamondService;
        }

        public void Run(char inputChar)
        {
            var validationResults = _validator.Validate(inputChar.ToString());

            if (!validationResults.IsValid)
            {
                string errorMessage = string.Join(
                                      Environment.NewLine,
                                      validationResults.Errors.Select(e => e.ErrorMessage).ToArray());
                _logger.LogError(errorMessage);

                return;
            }

            var diamond = _diamondService.GetDiamond(inputChar);

            foreach (var row in diamond)
            {
                Console.WriteLine(row);
            }
        }
    }
}
