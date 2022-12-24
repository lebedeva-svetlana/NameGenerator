using System.Threading.Tasks;

namespace Model
{
    public sealed class GeneratorOptions
    {
        private int _doubleLetterFrequencyPercent = 25;

        private int _maxConsonantInRow = 1;
        private int _maxVowelInRow = 1;

        private int _length = 5;

        internal const int MaxDoubleLetterFrequency = 100;

        internal LetterRanges Alphabet { get; private set; }

        internal AlphabetFrequencyRanges LetterFrequencyRanges { get; private set; }

        internal EndingsRanges Endings { get; private set; }

        public Requirement DoubleConsonantRequirement { get; set; } = Requirement.Forbidden;

        public Requirement DoubleVowelRequirement { get; set; } = Requirement.Forbidden;

        public SexEnding SexEnding { get; set; }

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

        private async Task<GeneratorOptions> InitializeAsync(int alphabetId, int frequencyTypeId, int endingsTypeId)
        {
            Alphabet = await AlphabetHandler.GetAlphabet(alphabetId);

            LetterFrequencyRanges = await AlphabetFrequencyHandler.GetRanges(frequencyTypeId);

            Endings = await EndingsHandler.GetEndings(endingsTypeId);

            return this;
        }

        public static Task<GeneratorOptions> CreateAsync(int alphabetId, int frequencyTypeId, int endingsTypeId)
        {
            GeneratorOptions options = new();

            return options.InitializeAsync(alphabetId, frequencyTypeId, endingsTypeId);
        }
    }
}