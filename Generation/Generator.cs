namespace NameGenerator
{
    public partial class Generator
    {
        private GeneratorOptions _options;
        private RootMask _rootMask;
        private Ending _wordEnding;
        private Root _wordRoot;

        public Generator(GeneratorOptions options)
        {
            _options = options;
            _rootMask = new(options);
            _wordEnding = new(options);
            _wordRoot = new(options);
        }

        public string Generate()
        {
            string ending = _wordEnding.GenerateEnding(_options.SexEnding);
            LetterType rootLastLetter;

            if (_options.Alphabet.Vowels.Contains(ending[0]))
            {
                rootLastLetter = LetterType.Consonant;
            }
            else
            {
                rootLastLetter = LetterType.Vowel;
            }

            string mask = _rootMask.GenerateRootMask(_options.Length - ending.Length, rootLastLetter);
            string root = _wordRoot.GenerateRootByMask(mask);
            root += ending;

            return root;
        }
    }
}