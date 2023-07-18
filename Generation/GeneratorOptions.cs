using System.Threading.Tasks;

namespace NameGenerator
{
    public sealed class GeneratorOptions
    {
        internal const int MaxDoubleLetterFrequency = 100;
        private int _doubleLetterFrequencyPercent = 25;
        private int _length = 5;
        private int _maxConsonantInRow = 1;
        private int _maxVowelInRow = 1;

        private GeneratorOptions()
        {
        }

        public Requirement DoubleConsonantRequirement { get; set; } = Requirement.Forbidden;

        public int DoubleLetterFrequencyPercent
        {
            get => _doubleLetterFrequencyPercent;
            set
            {
                if (value > 0 && value <= MaxDoubleLetterFrequency)
                {
                    _doubleLetterFrequencyPercent = value;
                }
            }
        }

        public Requirement DoubleVowelRequirement { get; set; } = Requirement.Forbidden;

        public int Length
        {
            get => _length;
            set
            {
                if (value > 0)
                {
                    _length = value;
                }
            }
        }

        public int MaxConsonantInRow
        {
            get => _maxConsonantInRow;
            set
            {
                if (value > 0)
                {
                    _maxConsonantInRow = value;
                }
            }
        }

        public int MaxVowelInRow
        {
            get => _maxVowelInRow;
            set
            {
                if (value > 0)
                {
                    _maxVowelInRow = value;
                }
            }
        }

        public SexEnding SexEnding { get; set; }

        internal LetterRanges Alphabet { get; private set; }

        internal EndingsRanges Endings { get; private set; }

        internal AlphabetFrequencyRanges LetterFrequencyRanges { get; private set; }

        public static Task<GeneratorOptions> CreateAsync(int alphabetId, int frequencyTypeId, int endingsTypeId)
        {
            GeneratorOptions options = new();

            return options.InitializeAsync(alphabetId, frequencyTypeId, endingsTypeId);
        }

        private async Task<GeneratorOptions> InitializeAsync(int alphabetId, int frequencyTypeId, int endingsTypeId)
        {
            Alphabet = await AlphabetHelper.GetAlphabet(alphabetId);

            LetterFrequencyRanges = await AlphabetFrequencyHelper.GetRanges(frequencyTypeId);

            Endings = await EndingsHelper.GetEndings(endingsTypeId);

            return this;
        }
    }
}