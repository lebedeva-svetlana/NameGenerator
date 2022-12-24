using System;
using System.Collections.Generic;

namespace Model
{
    internal class Root
    {
        internal Root(GeneratorOptions options)
        {
            this.options = options;
        }

        private GeneratorOptions options;
        private Random random = new();

        private char GetLetterFromRange(int number, List<char> letters, FrequencyRanges lettersFrequencyRanges)
        {
            char letter = default;

            for (int i = 0; i < lettersFrequencyRanges.Start.Length; ++i)
            {
                if (number <= lettersFrequencyRanges.End[i] && number >= lettersFrequencyRanges.Start[i])
                {
                    letter = letters[i];
                }
            }

            return letter;
        }

        private char GenerateLetter(LetterType letterType)
        {
            if (letterType != LetterType.Vowel && letterType != LetterType.Consonant)
            {
                throw new ArgumentException($"{letterType} is not valid letter type.");
            }

            if (letterType == LetterType.Vowel)
            {
                int randomNumber = random.Next(0, options.LetterFrequencyRanges.Vowels.End[^1]);
                return GetLetterFromRange(randomNumber, options.Alphabet.Vowels, options.LetterFrequencyRanges.Vowels);
            }
            else
            {
                int randomNumber = random.Next(0, options.LetterFrequencyRanges.Consonants.End[^1]);
                return GetLetterFromRange(randomNumber, options.Alphabet.Consonants, options.LetterFrequencyRanges.Consonants);
            }
        }

        internal string GenerateRootByMask(string mask)
        {
            string letters = "";

            int length = mask.Length;

            for (int i = 0; i < length; ++i)
            {
                char letter;

                if (mask[i] == MaskNumbers.Vowel)
                {
                    if (i > 0)
                    {
                        do
                        {
                            letter = GenerateLetter(LetterType.Vowel);
                        }
                        while (letter == letters[i - 1]);
                    }
                    else
                    {
                        letter = GenerateLetter(LetterType.Vowel);
                    }
                }
                else if (mask[i] == MaskNumbers.Consonant)
                {
                    if (i > 0)
                    {
                        do
                        {
                            letter = GenerateLetter(LetterType.Consonant);
                        }
                        while (letter == letters[i - 1]);
                    }
                    else
                    {
                        letter = GenerateLetter(LetterType.Consonant);
                    }
                }
                else
                {
                    letter = letters[i - 1];
                }

                letters += letter;
            }

            return letters;
        }
    }
}