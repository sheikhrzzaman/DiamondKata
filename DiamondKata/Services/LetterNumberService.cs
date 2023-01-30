namespace DiamondKata.Services
{
    public class LetterNumberService : ILetterNumberService
    {
        private readonly char[] _letter = Constants.Letter;

        public int GetLetterNumber(char inputLetter)
        {
            int letter_number = 0;

            for (int i = 0; i < _letter.Length; i++)
            {
                if (_letter[i] == inputLetter)
                {
                    letter_number = i;
                    break;
                }
            }

            return letter_number;
        }
    }
}
