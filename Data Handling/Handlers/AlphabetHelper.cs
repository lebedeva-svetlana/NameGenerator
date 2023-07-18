using System.Collections.Generic;
using System.Threading.Tasks;

namespace NameGenerator
{
    public static class AlphabetHelper
    {
        internal static async Task<LetterRanges> GetAlphabet(int alphabetId)
        {
            LetterDto[] letters = await DataReader.LoadLetters(alphabetId);

            List<char> vowels = new();
            List<char> consonants = new();

            for (int i = 0; i < letters.Length; ++i)
            {
                if (letters[i].IsVowel)
                {
                    vowels.Add(letters[i].Char);
                }
                else
                {
                    consonants.Add(letters[i].Char);
                }
            }

            return new LetterRanges(vowels, consonants);
        }
    }
}