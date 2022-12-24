namespace Model
{
    public partial class Generator
    {
        public Generator(GeneratorOptions options)
        {
            this.options = options;

            rootMask = new(options);
            wordEnding = new(options);
            wordRoot = new(options);
        }

        private GeneratorOptions options;

        private Ending wordEnding;
        private Root wordRoot;
        private RootMask rootMask;

        public string Generate()
        {
            string ending = wordEnding.GenerateEnding(options.SexEnding);
            LetterType rootLastLetter;

            if (options.Alphabet.Vowels.Contains(ending[0]))
            {
                rootLastLetter = LetterType.Consonant;
            }
            else
            {
                rootLastLetter = LetterType.Vowel;
            }

            string mask = rootMask.GenerateRootMask(options.Length - ending.Length, rootLastLetter);
            string root = wordRoot.GenerateRootByMask(mask);
            root += ending;

            return root;
        }
    }
}