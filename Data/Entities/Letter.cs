namespace NameGenerator
{
    public sealed class Letter
    {
        public int LetterId { get; set; }

        public int LanguageId { get; set; }

        public Language Language { get; set; }

        public char Char { get; set; }

        public bool IsVowel { get; set; }
    }
}