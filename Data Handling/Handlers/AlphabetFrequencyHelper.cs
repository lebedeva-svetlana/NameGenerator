using System.Collections.Generic;
using System.Threading.Tasks;

namespace NameGenerator
{
    internal static class AlphabetFrequencyHelper
    {
        private static FrequencyRanges CreateRanges(List<int> frequency)
        {
            int[] start = new int[frequency.Count];
            int[] end = new int[frequency.Count];

            start[0] = 0;
            end[0] = frequency[0];

            int length = frequency.Count;

            for (int i = 1; i < length; ++i)
            {
                start[i] = end[i - 1] + 1;
                end[i] = start[i] + frequency[i];
            }

            return (new FrequencyRanges(start, end));
        }

        internal static async Task<AlphabetFrequencyRanges> GetRanges(int frequencyTypeId)
        {
            LetterFrequencyDto[] frequency = await DataReader.LoadLetterFrequency(frequencyTypeId);

            List<int> vowels = new();
            List<int> consonants = new();

            for (int i = 0; i < frequency.Length; ++i)
            {
                if (frequency[i].IsVowel)
                {
                    vowels.Add(frequency[i].Frequency);
                }
                else
                {
                    consonants.Add(frequency[i].Frequency);
                }
            }

            FrequencyRanges vowelRanges = CreateRanges(vowels);
            FrequencyRanges consonantRanges = CreateRanges(consonants);

            AlphabetFrequencyRanges alphabetRanges = new(vowelRanges, consonantRanges);

            return alphabetRanges;
        }
    }
}