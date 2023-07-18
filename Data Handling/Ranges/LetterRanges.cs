using System.Collections.Generic;

namespace NameGenerator
{
    internal sealed class LetterRanges
    {
        internal LetterRanges(List<char> vowels, List<char> consonants)
        {
            Vowels = vowels;
            Consonants = consonants;
        }

        internal List<char> Consonants { get; private set; }

        internal List<char> Vowels { get; private set; }
    }
}