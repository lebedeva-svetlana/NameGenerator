using System;
using System.Collections.Generic;

namespace Model
{
    internal class RootMask
    {
        internal RootMask(GeneratorOptions options)
        {
            this.options = options;
        }

        private const int minRootLengthForDouble = 4;

        private GeneratorOptions options;
        private Random random = new();

        internal string GenerateRootMask(int length, LetterType endingLetterType)
        {
            bool needDoubleVowel = false;
            bool needDoubleConsonant = false;

            if (options.DoubleVowelRequirement == Requirement.None && length >= minRootLengthForDouble)
            {
                needDoubleVowel = random.Next(GeneratorOptions.MaxDoubleLetterFrequency) <= options.DoubleLetterFrequencyPercent;
            }

            if (options.DoubleConsonantRequirement == Requirement.None && length >= minRootLengthForDouble)
            {
                needDoubleConsonant = random.Next(GeneratorOptions.MaxDoubleLetterFrequency) <= options.DoubleLetterFrequencyPercent;
            }

            length = ShortenWordLength(length, needDoubleVowel, needDoubleConsonant);

            string mask = GenerateBasicMask(length, endingLetterType);

            if (options.DoubleVowelRequirement == Requirement.Required | needDoubleVowel)
            {
                mask = InsertDoubleLetter(mask, MaskNumbers.Vowel);
            }

            if (options.DoubleConsonantRequirement == Requirement.Required | needDoubleConsonant)
            {
                mask = InsertDoubleLetter(mask, MaskNumbers.Consonant);
            }

            return ReverseMask(mask);
        }

        private string InsertDoubleLetter(string mask, char maskNumber)
        {
            int index = GenerateDoubleLetterIndex(mask, mask.Length, maskNumber);

            if (index != NoPlaceForDouble)
            {
                return mask.Insert(index, Convert.ToString(MaskNumbers.RepeatLast));
            }
            else
            {
                return mask;
            }
        }

        private const int NoPlaceForDouble = -1;

        private string GenerateBasicMask(int length, LetterType endingLetterType)
        {
            string mask = "";

            List<LetterType> types = new();

            int placedVowels = 0;
            int placedConsonants = 0;

            if (endingLetterType == LetterType.Vowel)
            {
                mask += MaskNumbers.Vowel;
                ++placedVowels;
                placedConsonants = 0;
            }
            else if (endingLetterType == LetterType.Consonant)
            {
                mask += MaskNumbers.Consonant;
                ++placedConsonants;
                placedVowels = 0;
            }

            for (int i = 0; i < length; ++i)
            {
                if (placedVowels != options.MaxVowelInRow)
                {
                    types.Add(LetterType.Vowel);
                }

                if (placedConsonants != options.MaxConsonantInRow)
                {
                    types.Add(LetterType.Consonant);
                }

                LetterType type = types[random.Next(types.Count)];

                types.Clear();

                if (type == LetterType.Vowel)
                {
                    mask += MaskNumbers.Vowel;
                    ++placedVowels;
                    placedConsonants = 0;
                }
                else
                {
                    mask += MaskNumbers.Consonant;
                    ++placedConsonants;
                    placedVowels = 0;
                }
            }

            return mask;
        }

        private string ReverseMask(string mask)
        {
            string reverseMask = "";
            bool needAddDouble = false;

            for (int i = mask.Length - 1; i > -1; --i)
            {
                if (mask[i] == MaskNumbers.RepeatLast)
                {
                    needAddDouble = true;
                    continue;
                }

                reverseMask += mask[i];

                if (needAddDouble)
                {
                    reverseMask += MaskNumbers.RepeatLast;
                    needAddDouble = false;
                }
            }

            return reverseMask;
        }

        private int GenerateDoubleLetterIndex(string mask, int length, char letterNumber)
        {
            List<int> letters = new();

            for (int i = 0; i < length; ++i)
            {
                if (mask[i] == letterNumber)
                {
                    letters.Add(i);
                }
            }

            int index;

            try
            {
                index = letters[random.Next(letters.Count)] + 1;
            }
            catch
            {
                index = NoPlaceForDouble;
            }

            return index;
        }

        private int ShortenWordLength(int length, bool needDoubleVowel, bool needDoubleConsonant)
        {
            if (options.DoubleVowelRequirement == Requirement.Required)
            {
                --length;
            }

            if (options.DoubleConsonantRequirement == Requirement.Required)
            {
                --length;
            }

            if (needDoubleVowel)
            {
                --length;
            }

            if (needDoubleConsonant)
            {
                --length;
            }

            return length;
        }
    }
}