namespace NameGenerator
{
    internal sealed class AlphabetFrequencyRanges
    {
        internal AlphabetFrequencyRanges(FrequencyRanges vowels, FrequencyRanges consonants)
        {
            Vowels = vowels;
            Consonants = consonants;
        }

        internal FrequencyRanges Consonants { get; private set; }

        internal FrequencyRanges Vowels { get; private set; }
    }
}