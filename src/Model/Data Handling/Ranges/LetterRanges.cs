using System.Collections.Generic;

namespace Model
{
    internal sealed class LetterRanges
    {
        internal LetterRanges(List<char> vowels, List<char> consonants)
        {
            Vowels = vowels;
            Consonants = consonants;
        }

        internal List<char> Vowels { get; private set; }

        internal List<char> Consonants { get; private set; }
    }
}