namespace NameGenerator
{
    internal sealed class LetterDto
    {
        public int LetterId { get; set; }

        public int LanguageId { get; set; }

        public char Char { get; set; }

        public bool IsVowel { get; set; }
    }
}