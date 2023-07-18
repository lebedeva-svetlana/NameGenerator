using System;
using System.Collections.Generic;

namespace NameGenerator
{
    internal class RootMask
    {
        private const int MinRootLengthForDouble = 4;
        private const int NoPlaceForDouble = -1;
        private GeneratorOptions _options;
        private Random _random = new();

        internal RootMask(GeneratorOptions options)
        {
            _options = options;
        }

        internal string GenerateRootMask(int length, LetterType endingLetterType)
        {
            bool needDoubleVowel = false;
            bool needDoubleConsonant = false;

            if (_options.DoubleVowelRequirement == Requirement.None && length >= MinRootLengthForDouble)
            {
                needDoubleVowel = _random.Next(GeneratorOptions.MaxDoubleLetterFrequency) <= _options.DoubleLetterFrequencyPercent;
            }

            if (_options.DoubleConsonantRequirement == Requirement.None && length >= MinRootLengthForDouble)
            {
                needDoubleConsonant = _random.Next(GeneratorOptions.MaxDoubleLetterFrequency) <= _options.DoubleLetterFrequencyPercent;
            }

            length = ShortenWordLength(length, needDoubleVowel, needDoubleConsonant);

            string mask = GenerateBasicMask(length, endingLetterType);

            if (_options.DoubleVowelRequirement == Requirement.Required | needDoubleVowel)
            {
                mask = InsertDoubleLetter(mask, MaskNumbers.Vowel);
            }

            if (_options.DoubleConsonantRequirement == Requirement.Required | needDoubleConsonant)
            {
                mask = InsertDoubleLetter(mask, MaskNumbers.Consonant);
            }

            return ReverseMask(mask);
        }

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
                if (placedVowels != _options.MaxVowelInRow)
                {
                    types.Add(LetterType.Vowel);
                }

                if (placedConsonants != _options.MaxConsonantInRow)
                {
                    types.Add(LetterType.Consonant);
                }

                LetterType type = types[_random.Next(types.Count)];

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
                index = letters[_random.Next(letters.Count)] + 1;
            }
            catch
            {
                index = NoPlaceForDouble;
            }

            return index;
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

        private int ShortenWordLength(int length, bool needDoubleVowel, bool needDoubleConsonant)
        {
            if (_options.DoubleVowelRequirement == Requirement.Required)
            {
                --length;
            }

            if (_options.DoubleConsonantRequirement == Requirement.Required)
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