namespace DiamondKata.Services
{
    public class DiamondService : IDiamondService
    {
        private readonly char[] _letter = Constants.Letter;

        private readonly ILetterNumberService _letterNumberService;

        public DiamondService(ILetterNumberService letterNumberService)
        {
            _letterNumberService = letterNumberService;
        }

        public string[] GetDiamond(char inputLetter)
        {
            var letterNumber = _letterNumberService.GetLetterNumber(inputLetter);

            var totalRow = (letterNumber * 2) + 1;

            string[] diamond = new string[totalRow];

            for (int i = 0; i <= letterNumber; i++)
            {
                for (int j = 0; j < letterNumber - i; j++)
                {
                    diamond[i] += " ";
                }

                diamond[i] += _letter[i];

                if (_letter[i] != 'A')
                {
                    for (int j = 0; j < (2 * i) - 1; j++)
                    {
                        diamond[i] += " ";
                    }

                    diamond[i] += _letter[i];
                }
            }

            ////2nd half of the diamond
            for (int i = 0; i < letterNumber; i++)
            {
                diamond[totalRow - 1 - i] = diamond[i];
            }

            return diamond;
        }
    }
}
